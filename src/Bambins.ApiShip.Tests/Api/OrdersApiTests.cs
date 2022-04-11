using Bambins.ApiShip.Api;
using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Tests.Api
{
    public class OrdersApiTests
    {
        private OrdersApi _subject;

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
            _subject = new OrdersApi(true, () => credentials, () => httpClient);
        }

        [Test]
        public async Task GetStatusAsync_with_id_should_throw_api_exception_with_status_code_404()
        {
            Func<Task> getAccessToken = () => _subject.GetStatusAsync(1);

            var exceptionAssertion = await getAccessToken.Should().ThrowAsync<ApiException>();
            exceptionAssertion.And.ErrorCode.Should().Be(404);
        }

        [Test]
        public async Task GetStatusAsync_with_customer_number_should_throw_api_exception_with_status_code_404()
        {
            Func<Task> getAccessToken = () => _subject.GetStatusAsync("foo");

            var exceptionAssertion = await getAccessToken.Should().ThrowAsync<ApiException>();
            exceptionAssertion.And.ErrorCode.Should().Be(404);
        }

        [Test]
        public async Task GetStatusesAsync_should_return_status_code_200()
        {
            var response = await _subject.GetStatusesAsync(new OrderStatusesRequest { OrderIds = new[] { 1 } });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task CreateAsync_should_return_status_code_200()
        {
            var response = await _subject.CreateAsync(CreateTestOrder());

            response.StatusCode.Should().Be(200);

            await _subject.DeleteAsync(response.Payload.OrderId);
        }

        [Test]
        public async Task DeleteAsync_should_return_status_code_200()
        {
            ApiResponse<CreateSyncOrderResponse> createOrderResponse = null;
            try
            {
                createOrderResponse = await _subject.CreateSyncAsync(CreateTestOrder());
            }
            catch (ApiException)
            {
            }

            if (createOrderResponse is not null)
            {
                var deleteOrderResponse = await _subject.DeleteAsync(createOrderResponse.Payload.OrderId);

                deleteOrderResponse.StatusCode.Should().Be(200);
            }
        }

        [Test]
        public async Task CancelAsync_should_return_status_code_200()
        {
            ApiResponse<CreateSyncOrderResponse> createOrderResponse = null;
            try
            {
                createOrderResponse = await _subject.CreateSyncAsync(CreateTestOrder());
            }
            catch (ApiException)
            {
            }

            if (createOrderResponse is not null)
            {
                var getOrderResponse = await _subject.GetAsync(createOrderResponse.Payload.OrderId);

                getOrderResponse.StatusCode.Should().Be(200);

                try
                {
                    await _subject.DeleteAsync(createOrderResponse.Payload.OrderId);
                }
                catch (ApiException)
                {
                }
            }
        }

        [Test]
        public async Task ResendAsync_should_return_status_code_200()
        {
            ApiResponse<CreateSyncOrderResponse> createOrderResponse = null;
            try
            {
                createOrderResponse = await _subject.CreateSyncAsync(CreateTestOrder());
            }
            catch (ApiException)
            {
            }

            if (createOrderResponse is not null)
            {
                var resendOrderResponse = await _subject.ResendAsync(createOrderResponse.Payload.OrderId);

                resendOrderResponse.StatusCode.Should().Be(200);

                try
                {
                    await _subject.DeleteAsync(createOrderResponse.Payload.OrderId);
                }
                catch (ApiException)
                {
                }
            }
        }

        [Test]
        public async Task UpdateAsync_should_return_status_code_200()
        {
            var order = CreateTestOrder();

            ApiResponse<CreateSyncOrderResponse> createOrderResponse = null;
            try
            {
                createOrderResponse = await _subject.CreateSyncAsync(order);
            }
            catch (ApiException)
            {
            }

            if (createOrderResponse is not null)
            {
                var updateOrderResponse = await _subject.UpdateAsync(createOrderResponse.Payload.OrderId, order);

                updateOrderResponse.StatusCode.Should().Be(200);

                try
                {
                    await _subject.DeleteAsync(createOrderResponse.Payload.OrderId);
                }
                catch (ApiException)
                {
                }
            }
        }

        [Test]
        public async Task ValidateAsync_should_return_status_code_200()
        {
            var order = CreateTestOrder();

            var response = await _subject.ValidateAsync(order);

            response.StatusCode.Should().Be(200);
        }

        #region Utilities

        private static Order CreateTestOrder()
        {
            return new Order
            {
                Data = new OrderData
                {
                    ProviderNumber = "11e51r6",
                    AdditionalProviderNumber = "21309812039812",
                    ClientNumber = $"bb_test_{Guid.NewGuid()}",
                    Barcode = "123456",
                    Description = "Очень важный заказ",
                    ProviderKey = "cdek",
                    //ProviderConnectId = "11102",
                    PickupType = 1,
                    DeliveryType = 1,
                    TariffId = 16,
                    PointInId = 333,
                    PointOutId = 407,
                    PickupDate = DateTime.Now,
                    PickupTimeStart = "09:00",
                    PickupTimeEnd = "18:00",
                    DeliveryDate = DateTime.Now,
                    DeliveryTimeStart = "09:00",
                    DeliveryTimeEnd = "18:00",
                    Height = 45,
                    Length = 30,
                    Width = 20,
                    Weight = 20
                },
                Cost = new Cost
                {
                    AssessedCost = 50,
                    DeliveryCost = 200,
                    DeliveryCostVat = OrderVatType.None,
                    CodCost = 250,
                    IsDeliveryPayedByRecipient = false
                },
                Sender = new OrderAddress
                {
                    CountryCode = "RU",
                    PostIndex = "105062",
                    Region = "Москва",
                    Area = "",
                    City = "Москва",
                    CityGuid = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5",
                    Street = "Машкова",
                    House = "21",
                    Block = "",
                    Office = "",
                    Lat = 55.7647252M,
                    Lng = 37.6537218M,
                    AddressString = "г Москва, ул Машкова, д 21",
                    CompanyName = "ООО \"Тест\"",
                    CompanyInn = "1234567890",
                    ContactName = "Иванов Иван Иванович",
                    Phone = "79250001115",
                    Email = "test@test.com",
                    Comment = "",
                    BrandName = "ApiShip"
                },
                Recipient = new OrderAddress
                {
                    CountryCode = "RU",
                    PostIndex = "105062",
                    Region = "Москва",
                    Area = "",
                    City = "Москва",
                    CityGuid = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5",
                    Street = "Машкова",
                    House = "21",
                    Block = "",
                    Office = "",
                    Lat = 55.7647252M,
                    Lng = 37.6537218M,
                    AddressString = "г Москва, ул Машкова, д 21",
                    CompanyName = "ООО \"Тест\"",
                    CompanyInn = "1234567890",
                    ContactName = "Иванов Иван Иванович",
                    Phone = "79250001115",
                    Email = "test@test.com",
                    Comment = ""
                },
                ReturnAddress = new OrderAddress
                {
                    CountryCode = "RU",
                    PostIndex = "105062",
                    Region = "Москва",
                    Area = "",
                    City = "Москва",
                    CityGuid = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5",
                    Street = "Машкова",
                    House = "21",
                    Block = "",
                    Office = "",
                    Lat = 55.7647252M,
                    Lng = 37.6537218M,
                    AddressString = "г Москва, ул Машкова, д 21",
                    CompanyName = "ООО \"Тест\"",
                    CompanyInn = "1234567890",
                    ContactName = "Иванов Иван Иванович",
                    Phone = "79250001115",
                    Email = "test@test.com",
                    Comment = ""
                },
                Places = new OrderPlace[]
                {
                    new OrderPlace
                    {
                        Height = 45,
                        Length = 30,
                        Width = 20,
                        Weight = 20,
                        PlaceNumber = "123421931239",
                        Barcode = "800028197737",
                        Items = new OrderPlaceItem[]
                        {
                            new OrderPlaceItem
                            {
                                Height = 45,
                                Length = 30,
                                Width = 20,
                                Weight = 20,
                                Articul = "1189.0",
                                MarkCode = "010290000046994521AK-rO?H!hC2(M\\u001D91003A\\u001D92cYTu3sTj82KJR3+6hVtQyAfa5Zf6Q2alfJEnwe2RIv4GAWVy2GUptk7P1NYxRsIgsTJi+Wgg+K3dncPELDJ9Ag==",
                                Description = "Товар 1",
                                Quantity = 1,
                                QuantityDelivered = 0,
                                AssessedCost = 50,
                                Cost = 50,
                                CostVat = OrderVatType.None,
                                Barcode = "1234567890123",
                                CompanyName = "ООО \"Тест\"",
                                CompanyInn = "1234567890"
                            }
                        }
                    }
                },
                ExtraParams = new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("testParam", "testValue")
                }
            };
        }

        #endregion
    }
}