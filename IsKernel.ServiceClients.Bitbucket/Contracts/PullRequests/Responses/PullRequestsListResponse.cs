using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Responses
{
	public class PullRequestsListResponse : PaginatedResponse
	{
		[JsonProperty("values")]
		public PullRequest[] Values {get;set;}
	}
}
