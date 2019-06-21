namespace CarpoolApi.Api.Authentication
{
    public interface IAuthenticateService
    {
        object GetToken(AuthenticationRequest request);
    }
}
