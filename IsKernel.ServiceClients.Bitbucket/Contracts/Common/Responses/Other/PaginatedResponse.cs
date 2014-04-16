using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other
{
	public class PaginatedResponse
	{		
		[JsonProperty("previous")]
		public string PreviousPageUrl {get;set;}
		
		[JsonProperty("next")]
		public string NextPageUrl {get;set;}
		
		[JsonProperty("pagelen")]
		public int? PageLength {get;set;}
		
		[JsonProperty("page")]
		public int? Page {get;set;}
		
		[JsonProperty("size")]
		public int? Total {get;set;}
	}
}
