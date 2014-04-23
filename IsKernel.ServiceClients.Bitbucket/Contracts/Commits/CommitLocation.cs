using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Commits
{
	public class CommitLocation : BranchLocation
	{
		[JsonProperty("commit")]
		public Commit Commit {get;set;}
	}
}
