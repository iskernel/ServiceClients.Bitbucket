using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Requests
{
	public class PaginatedRequest
	{
		private const string PAGE_LENGTH_PARAMETER_NAME = "pagelen";
		private const string PAGE_PARAMETER_NAME = "page";
		
		private const int DEFAULT_PAGE_LENGTH = 10;
		private const int DEFAULT_PAGE = 1;
		
		private readonly RequestParameter<int> _pageLength;
		private readonly RequestParameter<int> _page;

		public PaginatedRequest()
		{
			_pageLength = new RequestParameter<int>(PAGE_PARAMETER_NAME, DEFAULT_PAGE_LENGTH);
			_page = new RequestParameter<int>(PAGE_PARAMETER_NAME, DEFAULT_PAGE);
		}
		
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
		
		public List<Tuple<string,string>> ToTuples()
		{
			var list = new List<Tuple<string,string>>();
			list.Add(new Tuple<string, string>(PageLength.Name, PageLength.Value.ToString()));
			list.Add(new Tuple<string, string>(Page.Name, Page.Value.ToString()));
			return list;
		}
	}
}
