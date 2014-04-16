using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other
{
	/// <summary>
	/// Description of Link.
	/// </summary>
	public class Link
	{
		[JsonProperty("href")]
		public string Href {get;set;}
	}
}
