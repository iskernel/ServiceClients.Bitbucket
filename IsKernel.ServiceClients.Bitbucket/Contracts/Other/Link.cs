using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Link : BitbucketModel
	{
		[JsonProperty("href")]
		public string Href {get;set;}
		
		[JsonProperty("rel")]
		public string Relation {get;set;}
	}
}
