using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories
{
	public class ParentRepository
	{
		[JsonProperty("full_name")]
		public string FullName {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
		[JsonProperty("links")]
		public ParentRepositoryLinks Links {get;set;}
		
		
	}
}
