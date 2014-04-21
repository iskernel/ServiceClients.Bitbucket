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
			request.AddParameter("pagelen", paginationRequest.PageLength);
			request.AddParameter("page", paginationRequest.Page);
			return request;
		}
	}
}
