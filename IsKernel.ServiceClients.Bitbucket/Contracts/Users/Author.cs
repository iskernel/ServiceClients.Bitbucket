using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Users
{
	public class Author : BitbucketJsonModel
	{
		[JsonProperty("raw")]
		public string Raw {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
	}
}
