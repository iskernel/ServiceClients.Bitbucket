using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.PullRequests
{
	public class PullRequestLinks : LinksBase
	{
		[JsonProperty("decline")]
		public Link DeclineUrl {get;set;}
		
		[JsonProperty("commits")]
		public Link CommitsUrl {get;set;}
		
		[JsonProperty("comments")]
		public Link CommentsUrl {get;set;}
		
		[JsonProperty("patch")]
		public Link PatchUrl {get;set;}
		
		[JsonProperty("merge")]
		public Link MergeUrl {get;set;}
		
		[JsonProperty("html")]
		public Link HtmlUrl {get;set;}
		
		[JsonProperty("activity")]
		public Link ActivityUrl {get;set;}
		
		[JsonProperty("diff")]
		public Link DiffUrl {get;set;}
		
		[JsonProperty("approve")]
		public Link ApproveUrl {get;set;}
	}
}
