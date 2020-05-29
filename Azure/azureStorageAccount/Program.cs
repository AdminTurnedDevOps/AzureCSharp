using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;

namespace azureStorageAccount
{
    public class Program
    {
        static void Main() 
        {
            var ClientId = "";
            var ClientSecret = "";
            var AzureTenantId = "";
            var subscriptionid = "";

            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(ClientId, ClientSecret, AzureTenantId, AzureEnvironment.AzureGlobalCloud);

            var azure = Microsoft.Azure.Management.Fluent.Azure.Configure().Authenticate(credentials).WithSubscription(subscriptionid);

            foreach (Microsoft.Azure.Management.Storage.Fluent.IStorageAccount i in azure.StorageAccounts.List()) {
                Console.WriteLine(i.Name);
            };

        }
    }
}