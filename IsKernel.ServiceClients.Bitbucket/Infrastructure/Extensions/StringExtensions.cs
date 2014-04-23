using System;
using System.Security;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Returns a Secure string from the source string
		/// </summary>
		/// <param name="Source"></param>
		/// <returns></returns>
		public static SecureString ToSecureString(this string Source)
		{
		    if (string.IsNullOrWhiteSpace(Source))
			{
		        return null;
			}
			else
		    {
		        SecureString result = new SecureString();
		        foreach (char c in Source.ToCharArray())
				{
		            result.AppendChar(c);
				}
				return result;
		    }
		}
	}
}
