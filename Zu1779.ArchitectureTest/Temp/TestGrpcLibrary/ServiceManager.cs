namespace TestGrpcLibrary
{
    using Grpc.Core;
    using System;

    public static class ServiceManager
    {
        static readonly Server server;
        static ServiceManager()
        {
            server = new Server
            {
                Services = { GrpcTestService.BindService(new GrpcTestServiceEndpoint()) },
                Ports = { new ServerPort("localhost", 1779, ServerCredentials.Insecure) },
            };
        }

        public static void StartService()
        {
            server.Start();
        }

        public static void StopService()
        {
            server.ShutdownAsync().Wait();
        }
    }
}
