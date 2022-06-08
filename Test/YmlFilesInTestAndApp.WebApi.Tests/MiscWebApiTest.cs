using Microsoft.AspNetCore.Mvc.Testing;

using NUnit.Framework;

namespace YmlFilesInTestAndApp.WebApi.Tests;

[TestFixture]
internal class MiscWebApiTest
{
    [SetUp]
    public void ApiControllerHttpTestSetUp()
    {
        WebApplicationFactory<Program> webAppFactory = new();
        ApiHttpClient = webAppFactory.CreateDefaultClient();
    }

    protected HttpClient ApiHttpClient { get; private set; } = null!;

    [TestCase("json")]
    [TestCase("txt")]
    public void CanGetStaticFiles(string fileExt)
    {
        //This fails for txt endpoint
        HttpResponseMessage res = ApiHttpClient.GetAsync($"/static-files/file1.{fileExt}").Result;
        res.EnsureSuccessStatusCode();
    }

    [TestCase("json")]
    [TestCase("txt")]
    public void CanGetStaticFilesForRunningApp(string fileExt)
    {
        //This works fine for both txt and json
        string url = "http://localhost:5156";
        HttpClient httpClient = new HttpClient();

        HttpResponseMessage res = httpClient.GetAsync($"{url}/static-files/file1.{fileExt}").Result;
        res.EnsureSuccessStatusCode();
    }

    [Test]
    public void CanGetWeatherEndpoint()
    {
        HttpResponseMessage res = ApiHttpClient.GetAsync("/WeatherForecast").Result;
        res.EnsureSuccessStatusCode();
    }
}
