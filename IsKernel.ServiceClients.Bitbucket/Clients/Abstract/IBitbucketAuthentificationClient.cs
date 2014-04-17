using System;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketAuthentificationClient
	{
		IBitbucketClient BitbucketClient {get;}
	}
}
