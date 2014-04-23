using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Link : BitbucketJsonModel
	{
		[JsonProperty("href")]
		public string Href {get;set;}
	}
}
