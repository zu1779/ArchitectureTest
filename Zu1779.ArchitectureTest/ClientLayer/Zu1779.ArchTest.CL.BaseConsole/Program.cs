namespace Zu1779.ArchTest.CL.BaseConsole
{
    using System;
    using System.Threading.Tasks;

    using LightInject;
    using NLog;

    using Zu1779.ArchTest.CL.TestGrpcClient;

    class Program
    {
        static async Task Main()
        {
            var log = LogManager.GetCurrentClassLogger();
            try
            {
                log.Debug($"static Main");

                var container = new ServiceContainer();
                container.RegisterFrom<CompositionRoot>();

                var program = container.GetInstance<Program>();
                await program.Execute();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Exception in static Main");
                throw;
            }
            finally
            {
                log.Debug($"shutdown before void Main exit");
                LogManager.Shutdown();
            }
        }

        private readonly ILogger log;
        public Program(ILogger log)
        {
            this.log = log;
        }

        public async Task Execute()
        {
            log.Info("Execute BEGIN");

            Console.WriteLine("Hello World!");
            Console.WriteLine("Testing gRPC");

            var client = new TestGrpcClient();
            string empId = "1";
            Console.WriteLine($"empId = {empId}");
            var (firstName, lastName) = await client.GetEmployeeName(empId);
            Console.WriteLine($"First name = {firstName}, Last name = {lastName}");

            Console.WriteLine("gRPC tested");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            log.Info("Execute END");
        }
    }
}
