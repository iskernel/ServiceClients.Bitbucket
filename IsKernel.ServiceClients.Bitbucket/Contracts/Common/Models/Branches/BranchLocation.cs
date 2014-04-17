using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches
{
	public class BranchLocation : BitbucketJsonModel
	{
		[JsonProperty("repository")]
		public Repository Repository {get;set;}
		
		[JsonProperty("branch")]
		public Branch Branch {get;set;}
	}
}
