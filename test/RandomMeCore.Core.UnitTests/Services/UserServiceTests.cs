using FluentAssertions;
using Moq;
using RandomMeCore.Core.Models;
using RandomMeCore.Core.Repositories;
using RandomMeCore.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RandomMeCore.Core.UnitTests.Services
{
    public class UserServiceTests
    {  
        [Fact]
        public async Task UserService_GenerateRandomUserTest()
        {
            var repoMock = new Mock<INameRepository>();

            var service = new UserService(repoMock.Object);
            var titles = new List<Title>() { new Title { Gender = Gender.M, Value = "Mr" }, new Title { Gender = Gender.F, Value = "Mrs" } };

            var user = await service.GenerateRandomUser(titles, new FirstName { Value = "Alex", Gender = Gender.M }, new LastName { Value = "Brown" }, default);

            user.Title.Should().Be("Mr");
            user.FirstName.Should().Be("Alex");
            user.LastName.Should().Be("Brown");
            user.Gender.Should().BeEquivalentTo(Gender.M);
            user.Phone.Should().NotBeEmpty();
            user.Email.Should().NotBeEmpty();
            user.DateOfBirth.Should().BeAfter(DateTime.MinValue);
        }
    }
}
