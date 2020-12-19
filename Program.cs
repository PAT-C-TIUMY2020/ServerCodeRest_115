using ServiceRest_20180140115_NurFajarIsmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServerCodeRest_20180140115_NurFajarIsmail
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost hostObjek = null;
           Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/ServiceRest_20180140115_NurFajarIsmail/Service1/");
            WebHttpBinding bind = new WebHttpBinding();
            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY), address);
                //ALAMAT BASE ADDRESS
                hostObjek.AddServiceEndpoint(typeof(ITI_UMY), bind, "");


                //ALAMAT ENDPOINT
                //wsdl
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl (dibuka saat development, tidak untuk dibuka)
                hostObjek.Description.Behaviors.Add(smb);
                //mex
                Binding mexbind =MetadataExchangeBindings.CreateMexHttpBinding();
                hostObjek.AddServiceEndpoint(typeof(IMetadataExchange),mexbind, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObjek.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObjek.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObjek.Close();
            }
            catch (Exception ex)
            {
                hostObjek = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
