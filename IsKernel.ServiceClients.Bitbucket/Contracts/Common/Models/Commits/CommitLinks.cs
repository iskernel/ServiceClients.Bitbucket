using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Commits
{
	public class CommitLinks : LinksBase
	{
		[JsonProperty("comments")]
		public string CommentsUrl {get;set;}
		
		[JsonProperty("patch")]
		public string Patch {get;set;}
		
		[JsonProperty("html")]
		public string Html {get;set;}
		
		[JsonProperty("diff")]
		public string Diff {get;set;}
		
		[JsonProperty("approve")]
		public string Approve {get;set;}
	}
}
