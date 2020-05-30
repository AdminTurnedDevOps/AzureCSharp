using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;

namespace azureStorageAccount
{
    public class Program
    {
            static string ClientId = "";
            static string ClientSecret = "";
            static string AzureTenantId = "";
            static string subscriptionid = "";

        static void Main() 
        {

            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(ClientId, ClientSecret, AzureTenantId, AzureEnvironment.AzureGlobalCloud);

            var azure = Microsoft.Azure.Management.Fluent.Azure.Configure().Authenticate(credentials).WithSubscription(subscriptionid);

            foreach (Microsoft.Azure.Management.Storage.Fluent.IStorageAccount i in azure.StorageAccounts.List()) {
                Console.WriteLine(i.Name);
            };

        }
    }
}