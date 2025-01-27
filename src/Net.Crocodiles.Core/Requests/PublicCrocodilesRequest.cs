using RestSharp;

namespace Net.Crocodiles.Core.Requests;

public class PublicCrocodilesRequest
{
    public static RestRequest GetAllCrocodiles() => new RestRequest("/public/crocodiles");

    public static RestRequest GetCrocodileById(int id) => new RestRequest("/public/crocodiles/" + id);
}