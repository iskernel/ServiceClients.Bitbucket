using System;

namespace IsKernel.ServiceClients.Bitbucket.Exceptions
{
	[Serializable]
	public class BitbucketException : Exception
	{
		public BitbucketException()
		{
		}
		
		public BitbucketException(string message) : base(message)
		{
			
		}
		
		public BitbucketException(string message, Exception inner) : base(message, inner)
		{
			
		}
		
		protected BitbucketException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
			
        }
	}
}
