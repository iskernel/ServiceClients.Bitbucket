using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users
{
	public class Author : BitbucketJsonModel
	{
		[JsonProperty("raw")]
		public string Raw {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
	}
}
