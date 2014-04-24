using System;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;

public class BitbucketDiffClient : BitbucketRepositoryClientBase, IBitbucketDiffClient
{
	private const string SPEC_SEGMENT = "spec";
	
	private const string BASE_URL = "https://bitbucket.org/api/2.0/";
	private const string DIFF_RESOURCE = "{owner}/{repo_slug}/diff/{spec}";
	private const string PATCH_RESOURCE = "{owner}/{repo_slug}/patch/{spec}";
	
	public BitbucketDiffClient(IAuthenticator authenticator) : base(authenticator, BASE_URL)
	{
		
	}
	
	public Task<string> GetDiffAsync(string owner, string reposlug, string spec)
	{
		var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
		urlSegments.Add(new Tuple<string, string>(SPEC_SEGMENT, spec));
		var task = MakeAsyncRequest<string>(DIFF_RESOURCE, Method.GET, urlSegments, null, "Could not retrieve diff");
		return task;
	}
	
	public Task<string> GetPatchAsync(string owner, string reposlug, string spec)
	{
		var urlSegments = CreateOwnerRepoSegments(owner, reposlug);
		urlSegments.Add(new Tuple<string, string>(SPEC_SEGMENT, spec));
		var task = MakeAsyncRequest<string>(PATCH_RESOURCE, Method.GET, urlSegments, null, "Could not retrieve diff");
		return task;
	}
}

