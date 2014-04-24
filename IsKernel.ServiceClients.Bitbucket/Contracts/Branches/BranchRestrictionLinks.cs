using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class BranchRestrictionLinks : LinksBase
	{
		[JsonProperty("parent")]
		public string Parent {get;set;}
	}
}
