using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Task3
{
    class HMAC
    {
        public static void PrintByteArray(byte[] array, string arg)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]:X2}");
                if ((i % 4) == 3 && arg == "key")
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        public static byte[] CreateHMACKey()
        {
            var _rng = RandomNumberGenerator.Create();
            byte[] byteArray = new byte[16];
            _rng.GetBytes(byteArray);
            return byteArray;
        }

        public static byte[] CreateHMAC(string arg, byte[] array)
        {
            Encoding enc = Encoding.GetEncoding("ASCII");
            HMACSHA256 hm = new HMACSHA256(array);
            byte[] result = hm.ComputeHash(enc.GetBytes(arg));
            return result;
        }
    }
}
