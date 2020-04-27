using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using RandomMeCore.Api.IntegrationTests.Infrastructure;
using RandomMeCore.Core.Services;
using Xunit;

namespace RandomMeCore.Api.IntegrationTests
{
    [Collection(nameof(TestServerClientCollection))]
    public class UsersTests
    {
        private readonly HttpClient _client;

        public UsersTests(TestServerClientFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Check_users_all_endpoint()
        {
            var result = await _client.GetAsync($"api/users/all/12");

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var str = await result.Content.ReadAsStringAsync();
            var content = await result.Content.ReadAsJsonAsync<List<GeneratedUser>>();

            content.Count.Should().Be(12);
        }

        [Fact]
        public async Task Check_users_single_endpoint()
        {
            var result = await _client.GetAsync($"api/users/single");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
