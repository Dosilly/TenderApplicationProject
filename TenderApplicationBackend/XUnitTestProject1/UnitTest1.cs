using System.Collections.Generic;
using Castle.Core.Configuration;
using FluentAssertions;
using Moq;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Interfaces;
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
            var grMock = new Mock<IGroupRepository>();

            reqMock.Setup(x => x.SelectRequirementsByTenderId(1)).Returns(() => new List<Requirement>
            {
                new Requirement{Description = "abc",Explanation = "abc", Id = 1, Name = "abc", TenderId = 1}
            });

            reqMock.Setup(x => x.SelectRequirementsByTenderId(2)).Returns(() => new List<Requirement>
            {
                new Requirement{Description = "abc",Explanation = "abc", Id = 2, Name = "abc2", TenderId = 2},
                new Requirement{Description = "abc",Explanation = "abc", Id = 3, Name = "abc2", TenderId = 2}
            });

            whMock.Setup(x => x.SelectWorkhoursByRequirementId(1)).Returns(() => new List<Workhour>
            {
                new Workhour{EmployeeId = 1,Id = 1,ReqId = 1,Workhours = 30},
                new Workhour{EmployeeId = 1,Id = 2,ReqId = 1,Workhours = 70}
            });

            whMock.Setup(x => x.SelectWorkhoursByRequirementId(2)).Returns(() => new List<Workhour>
            {
                new Workhour{EmployeeId = 1,Id = 4,ReqId = 2,Workhours = 50},
                new Workhour{EmployeeId = 1,Id = 3,ReqId = 2,Workhours = 50}
            });

            grMock.Setup(x => x.SelectGroupsByRequirementId(3)).Returns(() => new List<Group>
            {
                new Group{EmployeeId = 1,Id = 1,Name = "abc", Workhours = 150}
            }); 

            var tenderModule = new TenderModule(tenderMock.Object, empMock.Object, reqMock.Object, whMock.Object, grMock.Object);

            // Act
            var result =  tenderModule.EstimateTotalWorkhours(1);
            var result2 = tenderModule.EstimateTotalWorkhours(2);

            //Assert
            result.Should().BeOfType(typeof(int));
            result.Should().Be(50);
            result.Should().NotBe(null);

            result2.Should().BeOfType(typeof(int));
            result2.Should().Be(200);
            result2.Should().NotBe(null);
        }
    }
}
