using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;

namespace blobStorage
{
    class AZBlob
    {
        string storageConnectionString;
        
        static void Main(string[] args)
        {
            Azure();

        }

        static void Azure()
        {
            Console.WriteLine("Enter the storage account connection string");
            string storageConnectionString = Console.ReadLine();

            BlobContinuationToken continuationToken = null;

            var storageConnect = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blob = storageConnect.CreateCloudBlobClient();

            var containers = blob.ListContainersSegmented(continuationToken);
            Console.WriteLine(containers);
        }
    }
}
