using System;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Models.PullRequests
{
	public class PullRequestState : PrivateValueModel<string>
	{
		private PullRequestState(string value) : base(value)
		{
			
		}
		
		public static readonly PullRequestState Open = new PullRequestState("OPEN");
		public static readonly PullRequestState Merged = new PullRequestState("MERGED");
		public static readonly PullRequestState Declined = new PullRequestState("DECLINED");		
	}
}
