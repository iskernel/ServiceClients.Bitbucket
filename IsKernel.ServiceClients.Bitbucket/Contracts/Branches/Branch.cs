using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class Branch : BitbucketJsonModel
	{
		[JsonProperty("name")]
		public string Name {get;set;}
	}
}
