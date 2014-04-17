using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common;
using IsKernel.ServiceClients.Bitbucket.Models.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryPostOptionalParametersModel : BitbucketJsonModel
	{
		public RepositoryPostOptionalParametersModel(Scm scm, ForkingPolicy forkingPolicy, bool isPrivate)
		{
			Scm = scm.Value;
			IsPrivate = isPrivate;
			ForkPolicy = forkingPolicy.Value;
		}
		
		public RepositoryPostOptionalParametersModel(string name, Scm scm, ForkingPolicy forkingPolicy, bool isPrivate, 
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
