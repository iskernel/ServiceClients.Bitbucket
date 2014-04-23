using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class Inline : BitbucketJsonModel
	{
		[JsonProperty("to")]
		public long? To {get;set;}
		
		[JsonProperty("from")]
		public long? From {get;set;}
		
		[JsonProperty("path")]
		public string Path {get;set;}
	}
}
