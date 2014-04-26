using System;
using System.Linq;
using System.Collections.Specialized;
using RestSharp.Contrib;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure.Extensions
{
	public static  class NameValueCollectionExtensions
	{
		public static string ToQueryString(this NameValueCollection nvc)
		{
		    var array = (from key in nvc.AllKeys
				         from value in nvc.GetValues(key)
				         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
				         .ToArray();
		    var result = "?" + string.Join("&", array);
			return result;
		}
		
		public static string ToPostData(this NameValueCollection nvc)
		{
		    var array = (from key in nvc.AllKeys
				         from value in nvc.GetValues(key)
				         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
				         .ToArray();
		    var result = string.Join("&", array);
			return result;
		}
	}
}
