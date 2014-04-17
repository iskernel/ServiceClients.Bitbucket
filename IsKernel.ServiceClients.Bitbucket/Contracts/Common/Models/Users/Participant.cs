using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users
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
