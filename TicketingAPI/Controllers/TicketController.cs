using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace TicketingAPI.Controllers;

[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var publicKey = Environment.GetEnvironmentVariable("AWSPublicKey");
        var privateKey = Environment.GetEnvironmentVariable("AWSPrivateKey");
        var region = Environment.GetEnvironmentVariable("AWSRegion");
        var bucketName = Environment.GetEnvironmentVariable("AWSBucketName");
        IList<string> results = new List<string>();

        AmazonS3Client Client = new AmazonS3Client(publicKey, privateKey, region);
            ListObjectsRequest listObjectsRequest = new ListObjectsRequest();
            listObjectsRequest.BucketName = bucketName;
            listObjectsRequest.MaxKeys = 2;
            int i = 1;
            ListObjectsResponse listObjectsResponse = Client.ListObjectsAsync(listObjectsRequest).Result;
            do
            {

                List<S3Object> s3Objects = listObjectsResponse.S3Objects;

                foreach (S3Object s3Object in s3Objects)
                {
                    results.Add(s3Object.Key);
                }
                
                listObjectsRequest.Marker = listObjectsResponse.NextMarker;
                listObjectsResponse = Client.ListObjectsAsync(listObjectsRequest).Result;
            }
            while (listObjectsResponse.IsTruncated);

        return results;
    }

    // GET api/values/file
    [HttpGet("{key}")]
    public string Get(string key)
    {
        var publicKey = Environment.GetEnvironmentVariable("AWSPublicKey");
        var privateKey = Environment.GetEnvironmentVariable("AWSPrivateKey");
        var region = Environment.GetEnvironmentVariable("AWSRegion");
        var bucketName = Environment.GetEnvironmentVariable("AWSBucketName");
        IList<string> results = new List<string>();

        AmazonS3Client Client = new AmazonS3Client(publicKey, privateKey, region);
        GetObjectRequest req = new GetObjectRequest();
        req.BucketName = bucketName;
        req.Key = key;
      
        GetObjectResponse resp = Client.GetObjectAsync(req).Result;
        if (resp.HttpStatusCode== System.Net.HttpStatusCode.OK)
        {
            return JsonConvert.SerializeObject(resp.Metadata);
        }
        else
        {
            return "";
        }
 
    

        
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}