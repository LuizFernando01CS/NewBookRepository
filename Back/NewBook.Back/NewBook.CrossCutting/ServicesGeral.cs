using System.Security.Cryptography;
using System.Text;

namespace NewBook.CrossCutting
{
    public class ServicesGeral
    {
        public ServicesGeral(){}

        public string GerarHash(string password)
        {
            SHA512 shaM = SHA512.Create();

            var hashIntegridadeBytes = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashIntegridadeBytes).Replace("-", "");
        }
    }
}