﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public static class SecureStringExtensions
	{
		public static string ConvertToUnsecureString(this SecureString securePassword)
		{
		    if (securePassword == null)
			{
		        throw new ArgumentNullException("securePassword");
			}
		    IntPtr unmanagedString = IntPtr.Zero;
		    try
		    {
		        unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
		        return Marshal.PtrToStringUni(unmanagedString);
		    }
		    finally
		    {
		        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
		    }
		}
	}
}