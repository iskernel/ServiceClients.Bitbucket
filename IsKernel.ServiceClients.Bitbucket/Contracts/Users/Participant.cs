using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Users
{
	public class Participant : BitbucketJsonModel
	{
		[JsonProperty("role")]
		public string Role {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
		
		[JsonProperty("approved")]
		public bool Approved {get;set;}
	}
}
