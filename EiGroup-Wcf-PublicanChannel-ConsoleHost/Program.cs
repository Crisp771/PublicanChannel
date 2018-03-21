using EiGroupPlc.Application.PublicanChannel.Services;
using EiGroupPlc.Services.Contracts.PromotionalContent;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EiGroup_Wcf_PublicanChannel_ConsoleHost
{
    class Program
    {
        private static List<ServiceHost> _serviceHosts = new List<ServiceHost>();

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Service...");

            foreach (var serviceHost in _serviceHosts)
            {
                serviceHost?.Close();
            }


            // Here's where I'd like to be registering services using reflection.   I don't think we' should have to explicitly tell the host what to serve.

            RegisterLocalService("PromotionalContentService", 9001, typeof(PromotionalContentService), typeof(IPromotionalContentService));

            foreach (var serviceHost in _serviceHosts)
            {
                foreach(var baseAddress in serviceHost.BaseAddresses)
                    Console.WriteLine($"Opening service {baseAddress}");
                serviceHost.Open();
            }

            Console.WriteLine("Service Running...");
            Console.ReadLine();
        }

        private static void RegisterLocalService(string serviceName, int port, Type serviceType, Type contractType)
        {
            Console.WriteLine($"Registering {serviceName} service on port {port}");
            Console.WriteLine($"netsh http add urlacl url=http://localhost:{port}/{serviceName} user=domain\\user\n");
            // To be added to package and deploy script;
            // netsh http add urlacl url=http://localhost:9001/RetailService user=cris-pc\cris
            var strAdrHttp = $"http://localhost:{port}/{serviceName}Service";

            Uri[] adrbase = { new Uri(strAdrHttp) };
            var serviceHost = new ServiceHost(serviceType, adrbase);

            var mBehave = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(mBehave);

            var httpb = new BasicHttpBinding();
            serviceHost.AddServiceEndpoint(contractType, httpb, strAdrHttp);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            _serviceHosts.Add(serviceHost);
        }

        private void Stop()
        {
            foreach (var serviceHost in _serviceHosts)
            {
                serviceHost?.Close();
                _serviceHosts.Remove(serviceHost);
            }

            _serviceHosts = null;
        }
    }
}
