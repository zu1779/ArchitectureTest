namespace Zu1779.ArchTest.BL.MainEngine
{
    using System;

    public class EmployeeInfo
    {
        public (string firstName, string lastName) GetEmployeeName(string empId)
        {
            string firstName = null, lastName = null;
            switch (empId)
            {
                case "1":
                    firstName = "John";
                    lastName = "Doe";
                    break;
                case "2":
                    firstName = "Dave";
                    lastName = "Williams";
                    break;
                default:
                    break;
            }
            return (firstName, lastName);
        }
    }
}
