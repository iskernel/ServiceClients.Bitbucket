using System;
using System.Security;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketAuthenticationClient
	{
		Task<Uri> RequestTokenAsync(string callbackUrl = "oob");
		Task<IBitbucketClient> AuthentificateAsync(string verifier);
		IBitbucketClient AuthentificateWithAccessToken(string token, string secretToken);
	 	IBitbucketClient AuthentificateWithLogin(string username, string password);
	}
}
