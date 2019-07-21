namespace CarpoolApi.Api.Hashing
{
    public interface IHashingService
    {
        byte[] Encrypt(string original);
        string Decrypt(byte[] cipherText, string plainText);
    }
}
