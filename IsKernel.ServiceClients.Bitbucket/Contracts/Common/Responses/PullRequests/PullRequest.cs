using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.PullRequests
{
	public class PullRequest
	{
		[JsonProperty("description")]
		public string Description {get;set;}
		
		[JsonProperty("links")]
		public PullRequestLinks Links {get;set;}
		
		[JsonProperty("author")]
		public User Author {get;set;}
		
		[JsonProperty("close_source_branch")]
		public bool? IsCloseSourceBranch {get;set;}
		
		[JsonProperty("title")]
		public string Title {get;set;}
		
		[JsonProperty("destination")]
		public Location Destination {get;set;}
		
		[JsonProperty("reason")]
		public string Reason {get;set;}
		
		[JsonProperty("close_by")]
		public User CloseByUser {get;set;}
		
		[JsonProperty("source")]
		public Location Source {get;set;}
		
		[JsonProperty("state")]
		public string State {get;set;}
		
		[JsonProperty("created_on")]
		public DateTime? CreatedOn {get;set;}
		
		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn {get;set;}
		
		[JsonProperty("id")]
		public long? Id {get;set;}
		
		//TODO Figure what kind of object this is
		[JsonProperty("merge_commit")]
		public object MergeCommit {get;set;}
	}
}
