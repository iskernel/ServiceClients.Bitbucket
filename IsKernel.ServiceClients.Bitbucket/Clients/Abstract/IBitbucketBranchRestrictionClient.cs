using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketBranchRestrictionClient
	{
		Task<PaginatedResponse<BranchRestriction>> GetBranchRestrictionsForRepository(string owner, string reposlug, 
																					  PaginatedRequest request);
		Task<BranchRestriction> AddBranchRestriction(string owner, string reposlug, BranchRestriction restriction);
		Task<BranchRestriction> GetBranchRestrictionsForRepository(string owner, string reposlug, string id);
		Task<BranchRestriction> EditBranchRestrictionForRepository(string owner, string reposlug, string id, 
													 			   BranchRestriction restriction);
		Task<string> DeleteBranchRestrictionsForRepository(string owner, string reposlug, string id);
	}
}
