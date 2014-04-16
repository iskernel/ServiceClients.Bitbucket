using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories
{
	public class Repository
	{
		[JsonProperty("scm")]
		public string SourceControl {get;set;}
		
		[JsonProperty("has_wiki")]
		public string HasWiki {get;set;}
		
		[JsonProperty("description")]
		public string Description {get;set;}
		
		[JsonProperty("links")]
		public RepositoryLinks Links {get;set;}
		
		[JsonProperty("fork_policy")]
		public string ForkPolicy {get;set;}
	
		[JsonProperty("language")]
		public string Language {get;set;}
		
		[JsonProperty("parent")]
		public ParentRepository Parent {get;set;}
		
		[JsonProperty("full_name")]
		public string FullName {get;set;}
		
		[JsonProperty("has_issues")]
		public bool? HasIssues {get;set;}
		
		[JsonProperty("owner")]
		public User Owner {get;set;}
		
		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn {get;set;}
		
		[JsonProperty("size")]
		public long? Size {get;set;}
		
		[JsonProperty("is_private")]
		public bool? IsPrivate {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
	}
}
