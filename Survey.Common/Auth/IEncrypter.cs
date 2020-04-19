namespace Survey.Common.Auth
{
    public interface IEncrypter
    {
        byte[] GetSalt();
        byte[] GetHash(string value, byte[] salt);
    }
}
