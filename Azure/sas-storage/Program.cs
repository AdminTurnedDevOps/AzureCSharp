using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;

namespace sas_storage
{
    class Program
    {
        string storageConnect;
        string policyName;
        static void Main(string[] args)
        {
            sas();
        }

        static void sas()

        {
            // Prompt a user for information on the storage account, policy name, and container name
            Console.WriteLine("Enter policy name");
            string policyName = Console.ReadLine();

            Console.WriteLine("Enter the storage account connection string");
            string storageConnectionString = Console.ReadLine();

            Console.WriteLine("Enter the container name");
            string name = Console.ReadLine();

            //Connect to the storage account with the appropriate storage connection string
            var storageConnect = CloudStorageAccount.Parse(storageConnectionString);

            //Create the blob client to reference the container name
            CloudBlobClient blob = storageConnect.CreateCloudBlobClient();
            CloudBlobContainer containerName = blob.GetContainerReference(name);

            //Create a new shared access policy that allows for reading and listing container contents
            SharedAccessBlobPolicy sharedPolicy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List
            };

            //Retrieve existing permissions
            BlobContainerPermissions perms = containerName.GetPermissions();
            perms.SharedAccessPolicies.Add(policyName, sharedPolicy);

            //Set new permissions from the shared access policy that was created.
            containerName.SetPermissions(perms);
            
            
        }
    }
}
