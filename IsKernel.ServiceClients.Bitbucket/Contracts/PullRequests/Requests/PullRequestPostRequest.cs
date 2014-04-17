using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestPostRequest
	{
		public PullRequestPostModel Model {get;set;}
		
		public PullRequestPostRequest(PullRequestPostModel model)
		{
			if(model == null)
			{
				throw new RequestParameterException("Model should not be null");
			}
			Model = model;
		}
				
	}
}
