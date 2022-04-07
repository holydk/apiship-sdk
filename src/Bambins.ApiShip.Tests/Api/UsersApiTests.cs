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
    public class UsersApiTests
    {
        private TestAccount _account;
        private UsersApi _subject;

        [SetUp]
        public void Init()
        {
            _account = TestAccount.Create(true);
            _subject = new UsersApi(true, null, () => new HttpClient());
        }

        [Test]
        public async Task LoginAsync_should_return_access_token()
        {
            var response = await _subject.LoginAsync(new LoginRequest
            {
                Login = _account.Login,
                Password = _account.Password,
            });

            response.Payload.Token.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async Task LoginAsync_should_return_status_code_200()
        {
            var response = await _subject.LoginAsync(new LoginRequest
            {
                Login = _account.Login,
                Password = _account.Password,
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task LoginAsync_with_invalid_password_should_throw_api_exception_with_status_code_400()
        {
            Func<Task> getAccessToken = () => _subject.LoginAsync(new LoginRequest
            {
                Login = _account.Login,
            });
            var exceptionAssertion = await getAccessToken.Should().ThrowAsync<ApiException>();
            exceptionAssertion.And.ErrorCode.Should().Be(400);
        }
    }
}