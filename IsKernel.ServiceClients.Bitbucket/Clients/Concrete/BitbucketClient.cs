using System;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketClient : IBitbucketClient
	{
		public BitbucketClient(IAuthenticator client)
		{
			RepositoryClient = new BitbucketRepositoryClient(client);
		}
		
		public IBitbucketRepositoryClient RepositoryClient {get; private set;}
	}
}
