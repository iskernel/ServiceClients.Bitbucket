using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests
{
	public class PullRequest : BitbucketJsonModel
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
		public CommitLocation Destination {get;set;}
		
		[JsonProperty("reason")]
		public string Reason {get;set;}
		
		[JsonProperty("close_by")]
		public User CloseByUser {get;set;}
		
		[JsonProperty("source")]
		public CommitLocation Source {get;set;}
		
		[JsonProperty("state")]
		public string State {get;set;}
		
		[JsonProperty("created_on")]
		public DateTime? CreatedOn {get;set;}
		
		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn {get;set;}
		
		[JsonProperty("id")]
		public long? Id {get;set;}
		
		[JsonProperty("reviewers")]
		public User[] Reviewers {get;set;}
		
		[JsonProperty("participants")]
		public Participant[] Participants {get;set;}
		
		[JsonProperty("merge_commit")]
		public Commit MergeCommit {get;set;}
	}
}
