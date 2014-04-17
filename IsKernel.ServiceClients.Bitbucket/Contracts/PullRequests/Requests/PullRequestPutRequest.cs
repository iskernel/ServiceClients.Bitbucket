using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestPutRequest
	{
		public PullRequestPutModel Model {get;set;}
		
		public PullRequestPutRequest(PullRequestPutModel model)
		{
			if(model == null)
			{
				throw new RequestParameterException("Model should not be null");
			}
			Model = model;
		}
	}
}
