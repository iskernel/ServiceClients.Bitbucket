using System;
using System.Runtime.Serialization;

namespace IsKernel.ServiceClients.Bitbucket.Exceptions
{
	[Serializable]
	public class RequestParameterException : Exception
	{
		public RequestParameterException()
		{
		}
		
		public RequestParameterException(string message) : base(message)
		{
			
		}
		
		public RequestParameterException(string message, Exception inner) : base(message, inner)
		{
			
		}
		
		protected RequestParameterException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
			
        }
		
	}
}
