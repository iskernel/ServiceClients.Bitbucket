using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Commits
{
	public class Commit
	{
		[JsonProperty("hash")]
		public string Hash {get;set;}
		
		[JsonProperty("links")]
		public CommitLinks Links {get;set;}
	}
}
