﻿using System;
using NUnit.Framework;
using SevenDigital.Api.Wrapper.Schema;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests
{
	[TestFixture]
	public class StatusTests
	{
		[Test]
		public void Can_hit_endpoint()
		{

			Status status = Api<Status>.Get.Please();

			Assert.That(status, Is.Not.Null);
			Assert.That(status.ServerTime.Day, Is.EqualTo(DateTime.Now.Day));
		}
	}
}
