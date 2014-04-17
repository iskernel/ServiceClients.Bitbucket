using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories
{
	public class ParentRepository : BitbucketJsonModel
	{
		[JsonProperty("full_name")]
		public string FullName {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
		[JsonProperty("links")]
		public ParentRepositoryLinks Links {get;set;}
		
		
	}
}
