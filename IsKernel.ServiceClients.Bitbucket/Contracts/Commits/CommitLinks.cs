using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Commits
{
	public class CommitLinks : LinksBase
	{
		[JsonProperty("comments")]
		public Link CommentsUrl {get;set;}
		
		[JsonProperty("patch")]
		public Link Patch {get;set;}
		
		[JsonProperty("html")]
		public Link Html {get;set;}
		
		[JsonProperty("diff")]
		public Link Diff {get;set;}
		
		[JsonProperty("approve")]
		public Link Approve {get;set;}
	}
}
