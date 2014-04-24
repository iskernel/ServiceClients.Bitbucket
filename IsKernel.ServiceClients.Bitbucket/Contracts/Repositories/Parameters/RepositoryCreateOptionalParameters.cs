using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters
{
	public class RepositoryCreateOptionalParameters : BitbucketModel
	{
		public RepositoryCreateOptionalParameters(Scm scm, ForkingPolicy forkingPolicy, bool isPrivate)
		{
			Scm = scm.Value;
			IsPrivate = isPrivate;
			ForkPolicy = forkingPolicy.Value;
		}
		
		public RepositoryCreateOptionalParameters(string name, Scm scm, ForkingPolicy forkingPolicy, bool isPrivate, 
											      string language, bool hasIssues, bool hasWiki)
			:this(scm, forkingPolicy, isPrivate)
		{
			Name = name;
			Language = language;
			HasIssues = hasIssues;
			HasWiki = hasWiki;
		}
		
		[JsonProperty("scm")]
		public string Scm {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
		[JsonProperty("is_private")]
		public bool? IsPrivate {get;set;}
		
		[JsonProperty("language")]
		public string Language {get;set;}
		
		[JsonProperty("forking_policy")]
		public string ForkPolicy {get;set;}
		
		[JsonProperty("has_issues")]
		public bool? HasIssues {get;set;}
		
		[JsonProperty("has_wiki")]
		public bool? HasWiki {get;set;}
	}
}
