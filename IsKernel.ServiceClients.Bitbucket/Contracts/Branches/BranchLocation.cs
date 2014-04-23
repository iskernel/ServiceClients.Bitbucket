using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Models.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class BranchLocation : BitbucketJsonModel
	{
		[JsonProperty("repository")]
		public Repository Repository {get;set;}
		
		[JsonProperty("branch")]
		public Branch Branch {get;set;}
	}
}
