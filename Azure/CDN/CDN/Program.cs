using System;
using System.Collections.Generic;
using Microsoft.Rest;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace CDN
{
    class Program
    {
        static string subscriptionID;

        static void Main(string[] args)
        {
            cdnApp();
        }

        public static AuthenticationResult Token()
        {
            var clientID = "";
            var clientSecret = "";
            var tenantDomainName = "";

            string authority = "https://login.microsoftonline.com/" + clientID + "/" + tenantDomainName;
            AuthenticationContext auth = new AuthenticationContext(authority);

            ClientCredential cred = new ClientCredential(clientID, clientSecret);

            AuthenticationResult authResult = auth.AcquireTokenAsync("https://management.core.windows.net/", cred).Result;

            return authResult;
        }

        static void cdnApp()
        {
            Console.WriteLine("Enter subscription ID...");
            subscriptionID = Console.ReadLine();

            Console.WriteLine("Enter New Profile Name...");
            var profileName = Console.ReadLine();

            Console.WriteLine("Enter Resource Group Name For Profile To Live In...");
            var resourceGroupName = Console.ReadLine();


            Console.WriteLine("Enter Region For Resource To Reside In...");
            var resourceLocation = Console.ReadLine();

            // With the Sku class, initiate an object that specifies what version of a Sku will be used.
            Sku sku = new Sku(SkuName.StandardVerizon);

            // With the Profile class, initiate an object that specifies the resource location and the sku.
            Profile profile = new Profile(location: resourceLocation, sku: sku);

            AuthenticationResult token = Token();
            

            // Authentication for ALL interaction with CDN. 
            Microsoft.Azure.Management.Cdn.CdnManagementClient cdn = new Microsoft.Azure.Management.Cdn.CdnManagementClient(new TokenCredentials(token.AccessToken))
            {
                SubscriptionId = subscriptionID
            };

            // ** Below creates the CDN profile **
            cdn.Profiles.Create(resourceGroupName, profileName, profile);
        }
    }
}