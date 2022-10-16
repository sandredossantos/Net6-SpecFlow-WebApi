using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace SpecFlow.WebApi.Test.StepDefinitions
{
    [Binding]
    public class SpecFlowGetStepDefinitions
    {
        public WebApplicationFactory<Program> Factory { get; }
        public HttpClient Client { get; set; } = null!;
        private HttpResponseMessage Response { get; set; } = null!;

        public SpecFlowGetStepDefinitions(WebApplicationFactory<Program> factory)
        {
            Factory = factory;
        }


        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            Client = Factory.CreateDefaultClient(new Uri("http://localhost/"));
        }

        [When(@"I make a Get request to '([^']*)'")]
        public async Task WhenIMakeAGetRequestToAsync(string controller)
        {
            Response = await Client.GetAsync($"{controller}");
        }

        [Then(@"The response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int code)
        {
            Assert.Equal((HttpStatusCode)code, Response.StatusCode);
        }

        [Then(@"The result should be primary colors")]
        public async Task ThenTheResultShouldBePrimaryColorsAsync()
        {
            var response = await Response.Content.ReadAsStringAsync();
            Assert.Contains("Red", response);
            Assert.Contains("Blue", response);
            Assert.Contains("Yellow", response);
        }
    }
}
