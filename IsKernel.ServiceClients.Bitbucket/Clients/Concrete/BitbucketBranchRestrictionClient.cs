using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketBranchRestrictionClient : BitbucketRepositoryClientBase, IBitbucketBranchRestrictionClient
	{
		private const string ID_SEGMENT = "id";
		
		private const string BASE_URL = "https://bitbucket.org/api/2.0/repositories/";
		private const string BRANCH_RESTRICTIONS_RESOURCE = "/{owner}/{repo-slug}/branch-restrictions";
		private const string SPECIFIED_RESTRICTION_RESOURCE = "/{owner}/{repo-slug}/branch-restrictions/{id}";
		
		public BitbucketBranchRestrictionClient(IAuthenticator authentificator) : base(authentificator,BASE_URL)
		{
			
		}
		
		public Task<PaginatedResponse<BranchRestriction>> GetBranchRestrictionsForRepository(string owner, string reposlug, 
																							 PaginatedRequest request)
		{
			var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<BranchRestriction>>(BRANCH_RESTRICTIONS_RESOURCE, Method.GET,
																			  urlSegments, parameters, 
																			 "Could not retrieve branch restrictions");
			return task;
		}
		
		public Task<BranchRestriction> AddBranchRestriction(string owner, string reposlug, BranchRestriction restriction)
		{
			var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
			var task = MakePostWithContentAsyncRequest<BranchRestriction>(BRANCH_RESTRICTIONS_RESOURCE, restriction, 
																		  urlSegments, null,
													   					  "Could not add branch restriction");
			return task;
		}
		
		
		public Task<BranchRestriction> GetBranchRestrictionsForRepository(string owner, string reposlug, string id)
		{
			var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
			urlSegments.Add(new Tuple<string, string>(ID_SEGMENT, id));
			var task = MakeAsyncRequest<BranchRestriction>(SPECIFIED_RESTRICTION_RESOURCE, Method.GET,
														   urlSegments, null, 
														   "Could not retrieve branch restrictions");
			return task;
		}
		
		
		public Task<BranchRestriction> EditBranchRestrictionForRepository(string owner, string reposlug, string id, 
															 			  BranchRestriction restriction)
		{
			var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
			urlSegments.Add(new Tuple<string, string>(ID_SEGMENT, id));
			var task = MakePutWithContentAsyncRequest<BranchRestriction>(SPECIFIED_RESTRICTION_RESOURCE, restriction,
														  				 urlSegments, null, 
														   				 "Could not edit branch restrictions");
			return task;
		}
		
		public Task<string> DeleteBranchRestrictionsForRepository(string owner, string reposlug, string id)
		{
			var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
			urlSegments.Add(new Tuple<string, string>(ID_SEGMENT, id));
			var task = MakeAsyncRequest<string>(SPECIFIED_RESTRICTION_RESOURCE, Method.DELETE,
											    urlSegments, null, 
											    "Could not delete branch restrictions");
			return task;
		}
		
	}
}
