using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using static BookStoreV2.StaticDetails;

namespace BookStoreV2.Models
{
    public class ApiRequest 
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
