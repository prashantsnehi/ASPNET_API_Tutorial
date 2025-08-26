using System.Security.Cryptography;
using System.Text;

namespace API_Tutorial.Helpers;

public class AesGcmEncryptionHelper
{
    private const int AES_KEY_SIZE = 32; // 256 bits = 32 bytes
    private const int GCM_IV_LENGTH = 12;
    private const int GCM_TAG_LENGTH = 16;

    // Encrypt method
    public static string Encrypt(string message, string keyHex)
    {
        try
        {
            byte[] key = Convert.FromHexString(keyHex);
            byte[] iv = Convert.FromHexString(keyHex.Substring(0, GCM_IV_LENGTH * 2)); // 24 hex chars => 12 bytes
            byte[] plainText = Encoding.UTF8.GetBytes(message);
            byte[] cipherText = new byte[plainText.Length];
            byte[] tag = new byte[GCM_TAG_LENGTH];

            using (AesGcm aes = new AesGcm(key))
            {
                aes.Encrypt(iv, plainText, cipherText, tag);
            }

            // Combine cipherText + tag
            byte[] cipherTextWithTag = new byte[cipherText.Length + tag.Length];
            Buffer.BlockCopy(cipherText, 0, cipherTextWithTag, 0, cipherText.Length);
            Buffer.BlockCopy(tag, 0, cipherTextWithTag, cipherText.Length, tag.Length);

            return Convert.ToHexString(cipherTextWithTag);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Exception Occurred: " + ex.Message);
            return null;
        }
    }

    // Decrypt method
    public static string Decrypt(string cipherTextHex, string keyHex)
    {
        try
        {
            byte[] key = Convert.FromHexString(keyHex);
            byte[] iv = Convert.FromHexString(keyHex.Substring(0, GCM_IV_LENGTH * 2)); // 12-byte IV
            byte[] cipherTextWithTag = Convert.FromHexString(cipherTextHex);

            int cipherTextLength = cipherTextWithTag.Length - GCM_TAG_LENGTH;
            byte[] cipherText = new byte[cipherTextLength];
            byte[] tag = new byte[GCM_TAG_LENGTH];

            Buffer.BlockCopy(cipherTextWithTag, 0, cipherText, 0, cipherTextLength);
            Buffer.BlockCopy(cipherTextWithTag, cipherTextLength, tag, 0, GCM_TAG_LENGTH);

            byte[] decryptedData = new byte[cipherText.Length];

            using (AesGcm aes = new AesGcm(key))
            {
                aes.Decrypt(iv, cipherText, tag, decryptedData);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Exception Occurred: " + ex.Message);
            return null;
        }
    }
}