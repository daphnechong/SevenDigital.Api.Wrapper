﻿using System.Linq;
using NUnit.Framework;
using SevenDigital.Api.Wrapper.Schema;
using SevenDigital.Api.Wrapper.Schema.TrackEndpoint;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.TrackEndpoint
{
	[TestFixture]
	public class TrackSearchTests
	{
		[Test]
		public void Can_hit_endpoint()
		{
			TrackSearch release = Api<TrackSearch>.Get
				.WithParameter("q", "Happy")
				.Please();

			Assert.That(release, Is.Not.Null);
			Assert.That(release.Results.Count, Is.GreaterThan(0));
			Assert.That(release.Results.FirstOrDefault().Type, Is.EqualTo(ItemType.track));
		}

		[Test]
		public void Can_hit_endpoint_with_paging()
		{
			TrackChart artistBrowse = Api<TrackChart>.Get
				.WithParameter("q","Happy")
				.WithParameter("page", "2")
				.WithParameter("pageSize", "20")
				.Please();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(2));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(20));
		}
	}
}