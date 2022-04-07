using Bambins.ApiShip.Api;
using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Tests.Api
{
    public class CalculatorApiTests
    {
        private CalculatorApi _subject;

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
            _subject = new CalculatorApi(true, () => credentials, () => httpClient);
        }

        [Test]
        public async Task CalculateAsync_should_return_status_code_200()
        {
            var response = await _subject.CalculateAsync(new CalculatorRequest
            {
                AssessedCost = 500,
                CodCost = 500,
                SkipTariffRules = false,
                PromoCode = "SALE25",
                CustomCode = "test.com",
                DeliveryTypes = new[] { 1, 2 },
                PickupTypes = new[] { 1, 2 },
                IncludeFees = true,
                Timeout = 20000,
                PickupDate = DateTime.Now,
                To = new CalculatorDirection
                {
                    CountryCode = "RU",
                    Index = "105066",
                    AddressString = "г Москва, ул Нижняя Красносельская, д 35",
                    Region = "г Москва",
                    City = "г Москва",
                    CityGuid = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5",
                    Lat = 55.755318M,
                    Lng = 37.594265M,
                },
                From = new CalculatorDirection
                {
                    CountryCode = "RU",
                    Index = "105066",
                    AddressString = "г Москва, ул Нижняя Красносельская, д 35",
                    Region = "г Москва",
                    City = "г Москва",
                    CityGuid = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5",
                    Lat = 55.755318M,
                    Lng = 37.594265M,
                },
                Places = new[]
                {
                    new CalculatorPlace
                    {
                        Height = 45,
                        Length = 30,
                        Width = 20,
                        Weight = 20,
                    }
                },
                ProviderKeys = new[]
                {
                    "dpd", "cdek"
                }
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task CalculateAsync_without_access_token_throw_api_exception_with_status_code_401()
        {
            var subject = new CalculatorApi(true, null, () => new HttpClient());
            Func<Task> calculateTariffs = () => subject.CalculateAsync(new CalculatorRequest());

            var exceptionAssertion = await calculateTariffs.Should().ThrowAsync<ApiException>();
            exceptionAssertion.And.ErrorCode.Should().Be(401);
        }

        [Test]
        public async Task CalculateAsync_without_addresses_should_throw_api_exception_with_status_code_400()
        {
            Func<Task> calculateTariffs = () => _subject.CalculateAsync(new CalculatorRequest
            {
                AssessedCost = 500,
                DeliveryTypes = new[] { 1, 2 },
                PickupTypes = new[] { 1, 2 },
                IncludeFees = true,
            });

            var exceptionAssertion = await calculateTariffs.Should().ThrowAsync<ApiException>();
            exceptionAssertion.And.ErrorCode.Should().Be(400);
        }
    }
}