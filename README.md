# C# ApiShip SDK
## Getting started
* Install from Nuget
```
Install-Package Bambins.ApiShip
```
* Create **ApiShipClient**
```csharp
var api = new ApiShipClient();
```
If you have access token
```csharp
var api = new ApiShipClient("your_access_token");
```
If you want to use your own HTTP client
```csharp
// create and configure HTTP client or resolve from DI
var httpClient = new HttpClient();
var api = new ApiShipClient("your_access_token", httpClient);
```