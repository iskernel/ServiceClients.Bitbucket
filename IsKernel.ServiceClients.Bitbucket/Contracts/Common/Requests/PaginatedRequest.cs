using System;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests
{
	internal class PaginatedRequest
	{
		private readonly RequestParameter<int> _pageLength;
		private readonly RequestParameter<int> _page;

		public PaginatedRequest(int pageLength, int page)
		{
			_pageLength = new RequestParameter<int>("pagelen", pageLength);
			_page = new RequestParameter<int>("page", page);
		}
		
		
		public RequestParameter<int> PageLength 
		{
			get 
			{
				return _pageLength;
			}
		}

		public RequestParameter<int> Page 
		{
			get 
			{
				return _page;
			}
		}
	}
}
