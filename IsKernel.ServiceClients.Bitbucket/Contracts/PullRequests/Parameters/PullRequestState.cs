using System;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Parameters
{
	public class PullRequestState : ClassEnumBase<string>
	{
		private PullRequestState(string value) : base(value)
		{
			
		}
		
		public static readonly PullRequestState Open = new PullRequestState("OPEN");
		public static readonly PullRequestState Merged = new PullRequestState("MERGED");
		public static readonly PullRequestState Declined = new PullRequestState("DECLINED");		
	}
}
