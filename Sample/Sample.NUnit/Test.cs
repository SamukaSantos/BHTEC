using NUnit.Framework;
using System;
using Sample.Service;
using Sample.Service.Creator;

namespace Sample.NUnit
{
	[TestFixture ()]
	public class Test
	{

		string userValid = "dionisoliveira" ;

		string userInvalid = "123BHTECK" ;


		[Test ()]
		public void UserValidProfile ()
		{
			var Service = ServiceCreator.Get<GitService>();

			Assert.IsNotNull(Service.GetUserAsync(userValid).Result);

				
		
		}

		[Test ()]
		public void UserInvalidProfile ()
		{
			var Service = ServiceCreator.Get<GitService>();

			Assert.IsNotNull(Service.GetUserAsync(userInvalid).Result);



		}
	}
}

