using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other
{
	public class Location
	{
		[JsonProperty("commit")]
		public Commit Commit {get;set;}
		
		[JsonProperty("repository")]
		public Repository Repository {get;set;}
		
		[JsonProperty("branch")]
		public Branch Branch {get;set;}
	}
}
