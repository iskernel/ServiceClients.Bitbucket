using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Branches
{
	public class Branch
	{
		[JsonProperty("name")]
		public string Name {get;set;}
	}
}
