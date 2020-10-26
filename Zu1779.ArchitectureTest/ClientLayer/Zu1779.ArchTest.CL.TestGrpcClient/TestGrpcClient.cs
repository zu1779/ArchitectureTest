namespace Zu1779.ArchTest.CL.TestGrpcClient
{
    using System;
    using System.Threading.Tasks;

    using Grpc.Core;

    public class TestGrpcClient
    {
        public async Task<(string firstName, string lastName)> GetEmployeeName(string empId)
        {
            Channel channel = new Channel("127.0.0.1:1779", ChannelCredentials.Insecure);
            var client = new GrpcTestService.GrpcTestServiceClient(channel);

            var request = new EmployeeNameRequest { EmpId = "1", };
            var response = client.GetEmployeeName(request);

            await channel.ShutdownAsync();

            return (response.FirstName, response.LastName);
        }
    }
}
