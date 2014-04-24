using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Group
	{
		[JsonProperty("full_slug")]
		public string FullSlug {get;set;}
		
		[JsonProperty("slug")]
		public string Slug {get;set;}
		
		[JsonProperty("links")]
		public LinksBase Links {get;set;}
		
		[JsonProperty("name")]
		public string Name {get;set;}
		
		[JsonProperty("owner")]
		public User Owner {get;set;}
	}
}
