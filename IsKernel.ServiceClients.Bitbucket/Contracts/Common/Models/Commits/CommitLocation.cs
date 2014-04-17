using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Commits
{
	public class CommitLocation : BranchLocation
	{
		[JsonProperty("commit")]
		public Commit Commit {get;set;}
	}
}
