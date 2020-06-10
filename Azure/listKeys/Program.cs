using System;
using Azure.Security.KeyVault.Keys;
using Azure.Identity;

// Environment variables must be set for the DefaultAzureCredential Class
// setx AZURE_CLIENT_ID your_client_id
// setx AZURE_CLIENT_SECRET your_client_secret
// setx AZURE_TENANT_ID your_tenant_id
// * Please note that whichever user you choose MUST have access to the KeyVault, which you can set in the Access Policies of the key vault *
// To create a user with RBAC policies;
// az ad sp create-for-rbac -n "name_of_app_registration_user" --sdk-auth

namespace listKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            list();
        }

        static void list()
        {

            Console.WriteLine("Enter KeyVault URI");
            var keyvaultURI = Console.ReadLine();

            Console.WriteLine("Enter key name in key vault");
            var key = Console.ReadLine();

            var client = new KeyClient(new Uri(keyvaultURI), new DefaultAzureCredential());
            client.GetKey(key);
        }
    }
}
