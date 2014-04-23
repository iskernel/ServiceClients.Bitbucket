using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Activity
	{
		[JsonProperty("status")]
		public string Status {get;set;}
		
		[JsonProperty("description")]
		public string Description {get;set;}
		
		[JsonProperty("title")]
		public string Title {get;set;}
		
		[JsonProperty("source")]
		public CommitLocation Source {get;set;}
		
		[JsonProperty("destination")]
		public CommitLocation Destination {get;set;}
		
		[JsonProperty("reason")]
		public string Reason {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
		
		[JsonProperty("date")]
		public DateTime? Date {get;set;}
		
		[JsonProperty("state")]
		public string State {get;set;}
		
		[JsonProperty("comment")]
		public Comment Comment {get;set;}
		
		[JsonProperty("pull_request")]
		public PullRequest PullRequest {get;set;}
	}
}
