using System;

namespace Khairia.Infrastructure
{
	public class BusinessException:Exception
	{
		public BusinessException(string message):base(message)
		{
		}
	}
}