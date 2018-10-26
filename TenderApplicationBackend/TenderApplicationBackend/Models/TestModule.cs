using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models
{
    public class TestModule
    {
        private readonly TestRepository _testRepository;

        public TestModule(TestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public TestRequest RefactorObject(TestRequest testRequest)
        {
            //testRequest.TestStr = "Changed";
            testRequest.TestInt = 2;

            var employee = new Employee
            {
                FName = testRequest.TestStr,
                LName = testRequest.TestStr
            };

            _testRepository.SaveEmployee(employee);

            return testRequest;
        }
    }
}
