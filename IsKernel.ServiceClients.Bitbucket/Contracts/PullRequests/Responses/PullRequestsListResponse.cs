using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Responses
{
	public class PullRequestsListResponse : PaginatedResponse
	{
		[JsonProperty("values")]
		public PullRequest[] Values {get;set;}
	}
}
