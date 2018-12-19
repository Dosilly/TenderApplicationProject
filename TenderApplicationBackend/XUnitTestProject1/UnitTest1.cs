using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Modules;
using TenderApplicationBackend.Models.Repositories;
using Xunit;
using Xunit.Sdk;

namespace XUnitTestProject1
{

    public class TenderModuleTest
    {
        [Fact]
        public void IsWorkhoursEqual()
        {
            
            //Arrange
            var reqMock = new Mock<IRequirementRepository>();
            var tenderMock = new Mock<ITenderRepository>();
            var empMock = new Mock<IEmployeeRepository>();
            var whMock = new Mock<IWorkhourRepository>();

            reqMock.Setup(x => x.SelectRequirementsByTenderId(1)).Returns(() => new List<Requirement>
            {
                new Requirement{Description = "abc",Explanation = "abc", Id = 1, Name = "abc", TenderId = 1}
            });

            whMock.Setup(x => x.SelectWorkhoursByRequirementId(1)).Returns(() => new List<Workhour>
            {
                new Workhour{EmployeeId = 1,Id = 1,ReqId = 1,Workhours = 30},
                new Workhour{EmployeeId = 1,Id = 2,ReqId = 1,Workhours = 70}
            });

            var tenderModule = new TenderModule(tenderMock.Object, empMock.Object, reqMock.Object, whMock.Object);

            // Act
            var result =  tenderModule.EstimateTotalWorkhours(1);

            //Assert
            result.Should().BeOfType(typeof(int));
            result.Should().Be(50);
            result.Should().NotBe(null);
        }
    }
}
