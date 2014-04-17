using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class Content : BitbucketJsonModel
	{
		[JsonProperty("raw")]
		public string Raw {get;set;}
		
		[JsonProperty("markdown")]
		public string Markdown {get;set;}
		
		[JsonProperty("html")]
		public string Html {get;set;}
	}
}
