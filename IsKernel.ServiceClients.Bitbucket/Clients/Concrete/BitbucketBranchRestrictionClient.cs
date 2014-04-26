using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketBranchRestrictionClient : BitbucketRepositoryClientBase, IBitbucketBranchRestrictionClient
	{
		private const string ID_SEGMENT = "id";
		
		private const string BASE_URL = "https://bitbucket.org/api/2.0/repositories/";
		private const string BRANCH_RESTRICTIONS_RESOURCE = "/{owner}/{repo_slug}/branch-restrictions";
		private const string SPECIFIED_RESTRICTION_RESOURCE = "/{owner}/{repo_slug}/branch-restrictions/{id}";
		
		public BitbucketBranchRestrictionClient(IAuthenticator authentificator) : base(authentificator,BASE_URL)
		{
			
		}
		
		public Task<PaginatedResponse<BranchRestriction>> GetAllAsync(string owner, string reposlug, PaginatedRequest request)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(request);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters, null);
			var task = MakeAsyncRequest<PaginatedResponse<BranchRestriction>>(BRANCH_RESTRICTIONS_RESOURCE, restRequest);
			return task;
		}
		
		public Task<BranchRestriction> AddAsync(string owner, string reposlug, BranchRestriction restriction)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var content = restriction.CreatePostData();
			var restRequest = new RestComplexDataRequest(Method.POST, segments, null, null, content, 
														 RestDataContentType.UrlEncode);
			var task = MakeAsyncRequest<BranchRestriction>(BRANCH_RESTRICTIONS_RESOURCE, restRequest);
			return task;
		}
		
		
		public Task<BranchRestriction> GetAsync(string owner, string reposlug, string id)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);
			var task = MakeAsyncRequest<BranchRestriction>(SPECIFIED_RESTRICTION_RESOURCE, restRequest);
			return task;
		}
		
		
		public Task<BranchRestriction> EditAsync(string owner, string reposlug, string id, BranchRestriction restriction)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id);
			var content = restriction.CreatePostData();
			var restRequest = new RestComplexDataRequest(Method.PUT, segments, null, null, content, 
														  RestDataContentType.UrlEncode);
			var task = MakeAsyncRequest<BranchRestriction>(SPECIFIED_RESTRICTION_RESOURCE, restRequest);
			return task;
		}
		
		public Task<string> DeleteAsync(string owner, string reposlug, string id)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);
			var task = MakeAsyncRequest<string>(SPECIFIED_RESTRICTION_RESOURCE, restRequest);
			return task;
		}
		
	}
}
