namespace Zu1779.ArchTest.CL.BaseConsole
{
    using System;
    using System.Threading.Tasks;

    using Zu1779.ArchTest.CL.TestGrpcClient;

    class Program
    {
        static async Task Main(string[] args)
        {
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
        }
    }
}
