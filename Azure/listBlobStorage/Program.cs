using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;

namespace listBlobStorage
{
    class Program
    {
        string storageConnectionString;
        string containerName;

        static void Main(string[] args)
        {
            listBlobStorage();
        }

        static void listBlobStorage()
        {

            Console.WriteLine("Enter the storage account connection string");
            string storageConnectionString = Console.ReadLine();

            var storageConnect = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blob = storageConnect.CreateCloudBlobClient();
            

            Console.WriteLine("Enter container name");
            string containerName = Console.ReadLine();
            var containerRef = blob.GetContainerReference(containerName);
            Console.WriteLine(containerRef.ListBlobs());

            foreach (CloudBlockBlob container in containerRef.ListBlobs())
            {
                Console.WriteLine(container.Name);
            }


        }
    }
}
