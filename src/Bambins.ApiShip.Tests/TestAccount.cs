using System;

namespace Bambins.ApiShip.Tests
{
    public class TestAccount
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public static TestAccount Create(bool isSandbox)
        {
            var login = !isSandbox
                ? Environment.GetEnvironmentVariable("API_LOGIN")
                : "test";
            var password = !isSandbox
                ? Environment.GetEnvironmentVariable("API_PASSWORD")
                : "test";

            return new TestAccount()
            {
                Login = login,
                Password = password
            };
        }
    }
}