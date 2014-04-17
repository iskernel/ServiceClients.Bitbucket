using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class Link : BitbucketJsonModel
	{
		[JsonProperty("href")]
		public string Href {get;set;}
	}
}
