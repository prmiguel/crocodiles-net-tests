
using System.Net;
using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using Net.Crocodiles.Core.Requests;
using FluentAssertions;
using Net.Crocodiles.Core.Responses;

namespace Net.Crocodiles.Tests;

[TestClass]
public class ListPublicCrocodileById
{
    private const String Url = "https://test-api.k6.io";

    [TestMethod]
    public void ShouldReturnASingleCrocodile()
    {
        IActor actor = new Actor("Guest", new ConsoleLogger());
        actor.Can(CallRestApi.At(Url));
        var response = actor.
            Calls(
                Rest.Request<CrocodileResponse>(
                    PublicCrocodilesRequest.GetCrocodileById(1)));
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Id.Should().Be(1);
    }
}
