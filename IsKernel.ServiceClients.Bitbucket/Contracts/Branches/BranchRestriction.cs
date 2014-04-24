using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class BranchRestriction : BitbucketModel
	{
		[JsonProperty("groups")]
		public Group[] Groups {get;set;}
		
		[JsonProperty("id")]
		public long? Id {get;set;}
		
		[JsonProperty("links")]
		public BranchRestrictionLinks Links {get;set;}
		
		[JsonProperty("kind")]
		public string Type {get;set;}
		
		[JsonProperty("pattern")]
		public string Pattern {get;set;}
		
		[JsonProperty("users")]
		public User[] Users {get;set;}
	}
}
