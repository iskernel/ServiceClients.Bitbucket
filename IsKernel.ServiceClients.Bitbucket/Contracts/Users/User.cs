using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Users
{
	public class User
	{
    [JsonProperty("username")]
		public string Username {get;set;}
        
		[JsonProperty("website")]
		public string Website {get;set;}
		
        [JsonProperty("display_name")]
		public string DisplayName {get;set;}
		
		[JsonProperty("created_on")]
		public string CreatedOn {get;set;}
		
		[JsonProperty("links")]
		public UserLinks Links {get;set;}
		
		[JsonProperty("location")]
		public string Location {get;set;}
		
		[JsonProperty("type")]
		public string Type {get;set;}
		
	}
}
