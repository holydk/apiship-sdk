using Bambins.ApiShip.Api;
using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Tests.Api
{
    public class ListsApiTests
    {
        private ListsApi _subject;

        [SetUp]
        public async Task InitAsync()
        {
            var httpClient = new HttpClient();
            var account = TestAccount.Create(true);
            var usersApi = new UsersApi(true, null, () => httpClient);
            var tokenResponse = await usersApi.LoginAsync(new LoginRequest
            {
                Login = account.Login,
                Password = account.Password,
            });
            var credentials = new ApiShipCredentials
            {
                AccessToken = tokenResponse.Payload.Token
            };
            _subject = new ListsApi(true, () => credentials, () => httpClient);
        }

        [Test]
        public async Task GetStatusesAsync_with_paged_query_should_return_status_code_200()
        {
            var response = await _subject.GetStatusesAsync(limit: 1, offset: 1);

            response.Payload.Rows.Should().HaveCount(1);
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetProvidersAsync_with_paged_query_should_return_status_code_200()
        {
            var response = await _subject.GetProvidersAsync(limit: 1, offset: 1);

            response.Payload.Rows.Should().HaveCount(1);
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetPointsAsync_should_return_status_code_200()
        {
            var response = await _subject.GetPointsAsync(stateCheckOff: true);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetDeliveryTypesAsync_should_return_status_code_200()
        {
            var response = await _subject.GetDeliveryTypesAsync();

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetPickupTypesAsync_should_return_status_code_200()
        {
            var response = await _subject.GetPickupTypesAsync();

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetPointTypesAsync_should_return_status_code_200()
        {
            var response = await _subject.GetPointTypesAsync();

            response.StatusCode.Should().Be(200);
        }
    }
}