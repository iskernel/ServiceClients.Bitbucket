using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Models.Repositories
{
	public class RepositoryOptionalParameterJsonModel : PostJsonModel
	{
		[JsonProperty("scm")]
		public string Scm {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
		[JsonProperty("is_private")]
		public bool? IsPrivate {get;set;}
		
		[JsonProperty("language")]
		public string Language {get;set;}
		
		[JsonProperty("has_issues")]
		public bool? HasIssues {get;set;}
		
		[JsonProperty("has_wiki")]
		public bool? HasWiki {get;set;}
	}
}
