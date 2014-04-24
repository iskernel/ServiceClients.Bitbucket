using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Content : BitbucketModel
	{
		[JsonProperty("raw")]
		public string Raw {get;set;}
		
		[JsonProperty("markdown")]
		public string Markdown {get;set;}
		
		[JsonProperty("html")]
		public string Html {get;set;}
	}
}
