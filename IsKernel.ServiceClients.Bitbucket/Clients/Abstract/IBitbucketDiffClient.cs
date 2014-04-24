using System;
using System.Threading.Tasks;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketDiffClient
	{
		Task<string> GetDiffAsync(string owner, string reposlug, string spec);
		Task<string> GetPatchAsync(string owner, string reposlug, string spec);
	}
}
