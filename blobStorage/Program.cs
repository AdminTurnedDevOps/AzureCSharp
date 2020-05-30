using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;

namespace blobStorage
{
    class AZBlob
    {
        static void Main(string[] args)
        {
            Azure();

        }

        static void Azure(string storageConnectionString = "")
        {
            BlobContinuationToken continuationToken = null;

            var storageConnect = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blob = storageConnect.CreateCloudBlobClient();

            var containers = blob.ListContainersSegmented(continuationToken);
            Console.WriteLine(containers);
        }
    }
}
