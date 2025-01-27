
using System.Net;
using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using Net.Crocodiles.Core.Requests;
using FluentAssertions;
using Net.Crocodiles.Core.Responses;

namespace Net.Crocodiles.Tests;

[TestClass]
public class ListPublicCrocodiles
{
    private const String Url = "https://test-api.k6.io";

    [TestMethod]
    public void ShouldReturnAllPublicCrocodiles()
    {
        IActor actor = new Actor("Guest", new ConsoleLogger());
        actor.Can(CallRestApi.At(Url));
        var response = actor.
            Calls(
                Rest.Request<List<CrocodileResponse>>(
                    PublicCrocodilesRequest.
                        GetAllCrocodiles()));
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Should().HaveCount(8);
        response.Data.First().Id.Should().Be(1);
        response.Data.Last().Id.Should().Be(8);
    }
}
