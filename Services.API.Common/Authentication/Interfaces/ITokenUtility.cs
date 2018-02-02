namespace Services.API.Common.Authentication.Interfaces
{
    public interface ITokenUtility
    {
        string GenerateToken(string applicationName, string securityKey);
    }
}
