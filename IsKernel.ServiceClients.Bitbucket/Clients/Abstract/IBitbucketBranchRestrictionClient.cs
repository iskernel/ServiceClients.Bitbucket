using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketBranchRestrictionClient
	{
		Task<PaginatedResponse<BranchRestriction>> GetAllAsync(string owner, string reposlug, 
															   PaginatedRequest request);
		Task<BranchRestriction> AddAsync(string owner, string reposlug, BranchRestriction restriction);
		Task<BranchRestriction> GetAsync(string owner, string reposlug, string id);
		Task<BranchRestriction> EditAsync(string owner, string reposlug, string id, 
													 			   BranchRestriction restriction);
		Task<string> DeleteAsync(string owner, string reposlug, string id);
	}
}
