namespace TestGrpcLibrary
{
    using System;
    using System.Threading.Tasks;

    using Grpc.Core;

    using Zu1779.ArchTest.BL.MainEngine;

    public class GrpcTestServiceEndpoint : GrpcTestService.GrpcTestServiceBase
    {
        public override Task<EmployeeName> GetEmployeeName(EmployeeNameRequest request, ServerCallContext context)
        {
            var (firstName, lastName) = new EmployeeInfo().GetEmployeeName(request.EmpId);
            var employee = new EmployeeName
            {
                FirstName = firstName,
                LastName = lastName,
            };
            var response = Task.FromResult(employee);
            return response;
        }
    }
}
