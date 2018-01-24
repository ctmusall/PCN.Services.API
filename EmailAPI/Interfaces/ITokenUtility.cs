namespace Email.API.Interfaces
{
    public interface ITokenUtility
    {
        string GenerateToken(string applicationName);
    }
}
