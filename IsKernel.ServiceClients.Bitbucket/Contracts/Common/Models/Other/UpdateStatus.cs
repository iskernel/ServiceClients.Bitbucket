using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class UpdateStatus
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
	}
}
