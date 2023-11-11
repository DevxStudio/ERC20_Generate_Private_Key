﻿using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace System.Net
{
    using System.Security.Authentication;
    public static class SecurityProtocolTypeExtensions
    {
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)SslProtocolsExtensions.Tls12;
        public const SecurityProtocolType Tls11 = (SecurityProtocolType)SslProtocolsExtensions.Tls11;
        public const SecurityProtocolType SystemDefault = 0;
    }
}

namespace System.Security.Authentication
{
    public static class SslProtocolsExtensions
    {
        public const SslProtocols Tls12 = (SslProtocols)0x00000C00;
        public const SslProtocols Tls11 = (SslProtocols)0x00000300;
    }
}

namespace ERC20_Generate
{
    class SSL
    {
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error) => error == SslPolicyErrors.None;
        public static void GetSSL()
        {
            X509Store certStore = new X509Store(StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            // Установка сертификата для успешной загрузки файл(а)ов
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolTypeExtensions.Tls11 | SecurityProtocolTypeExtensions.Tls12;

        }
    }
}
