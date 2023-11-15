using Nethereum.KeyStore;
using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace ERC20_Generate
{
    internal class Program
    {
        public static int count;
        public static string filekey = Directory.GetCurrentDirectory() + "\\PRIVATEKEY!.txt";
        public static string onlyadress = Directory.GetCurrentDirectory() + "\\ONLY_ADRESS.txt";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== BY @DEVXSTUDIO 2023 ===== \n");
            Console.WriteLine("Number of Wallets (Max 9999):\n");
            string nab;
            nab = Console.ReadLine();
            List<Thread> AutoStart = new List<Thread>
            {
                new Thread(() => Gen(nab))
            };

            foreach (Thread t in AutoStart)
                t.Start();
        }
        static private void Gen(string nab)
        {
            try
            {
                while (true)
                {
                    if (count == Convert.ToInt32(nab))
                    {
                        break;
                    }
                    else
                    {
                        EthECKey key = EthECKey.GenerateKey();
                        string privateKey = key.GetPrivateKey();
                        string address = key.GetPublicAddress();
                        var keyStore = new KeyStoreScryptService();
                        Console.WriteLine(address + ":" + privateKey);
                        string i = address + ":" + privateKey;
                        File.AppendAllText(filekey,  i + Environment.NewLine, Encoding.UTF8);
                        File.AppendAllText(onlyadress, address + Environment.NewLine, Encoding.UTF8);
                        count++;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); Console.ReadKey(); }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Adress:PrivateKey SAVE TO FILE: PRIVATEKEY!.txt");
            Console.WriteLine("Only Adress SAVE TO FILE: ONLY_ADRESS.txt");
            if (File.Exists(filekey))
                Process.Start(filekey);
            if (File.Exists(onlyadress))
                Process.Start(onlyadress);
            Console.ReadKey();
        }
    }
}
