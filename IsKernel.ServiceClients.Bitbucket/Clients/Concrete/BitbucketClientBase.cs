using System;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public abstract class BitbucketClientBase
	{
		protected readonly RestClient _client;
		
		protected BitbucketClientBase(IAuthenticator authentificator, string clientBaseUrl = "")
		{
			_client = new RestClient(clientBaseUrl);
			_client.Authenticator = authentificator;
		}
		
		protected RestRequest AddPaginationParameters(RestRequest request, PaginatedRequest paginationRequest)
		{
			request.AddParameter(paginationRequest.PageLength.Name, paginationRequest.PageLength.Value);
			request.AddParameter(paginationRequest.Page.Name, paginationRequest.Page.Value);
			return request;
		}
	}
}
