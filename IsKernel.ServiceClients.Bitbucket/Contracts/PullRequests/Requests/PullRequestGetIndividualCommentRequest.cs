using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestGetIndividualCommentRequest : PullRequestSpecificRequestBase
	{
		private readonly RequestParameter<string> _commentId;
		
		public PullRequestGetIndividualCommentRequest(string owner, string repoSlug, string pullRequestId, string commentId) 
			   : base(owner, repoSlug, pullRequestId)
		{
			if(string.IsNullOrWhiteSpace(commentId) == true)
			{
				throw new RequestParameterException("Comment id is null or whitespace");
			}
			_commentId = new RequestParameter<string>("comment_id", commentId);
		}
	}
}
