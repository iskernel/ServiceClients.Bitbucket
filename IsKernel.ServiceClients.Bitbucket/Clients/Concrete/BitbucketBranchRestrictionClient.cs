using System;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketBranchRestrictionClient : BitbucketRepositoryClientBase, IBitbucketBranchRestrictionClient
	{
		private const string BASE_URL = "https://bitbucket.org/api/2.0/repositories/";
		
		public BitbucketBranchRestrictionClient(IAuthenticator authentificator) : base(authentificator,BASE_URL)
		{
			
		}
		
		
	}
}
