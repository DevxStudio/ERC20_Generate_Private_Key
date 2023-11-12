using Nethereum.KeyStore;
using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace ERC20_Generate
{
    internal class Program
    {
        public static int count;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Number of Wallets (Max 9999):\n");
            string nab;
            nab = Console.ReadLine();
            List<Thread> AutoStart = new List<Thread>
            {
                new Thread(() => Gen(nab).Wait())
            };

            foreach (Thread t in AutoStart)
                t.Start();
        }
        static private async Task Gen(string nab)
        {
            try
            {
                while (true)
                {
                    if (count == Convert.ToInt32(nab))
                    {
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        EthECKey key = EthECKey.GenerateKey();
                        string privateKey = key.GetPrivateKey();
                        string address = key.GetPublicAddress();
                        var keyStore = new KeyStoreScryptService();
                        Console.WriteLine(address + ":" + privateKey);
                        count++;
                    }

                }
            }
            catch { }
            // Gen().Wait();
            Console.ReadKey();

        }
    }
}
