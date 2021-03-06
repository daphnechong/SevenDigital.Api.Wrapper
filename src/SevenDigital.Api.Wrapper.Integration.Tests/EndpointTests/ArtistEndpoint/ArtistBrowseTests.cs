﻿using NUnit.Framework;
using SevenDigital.Api.Wrapper.Schema.ArtistEndpoint;
using SevenDigital.Api.Wrapper.Schema;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.ArtistEndpoint
{
	[TestFixture]
	[Category("Integration")]
	public class ArtistBrowseTests
	{
		[Test]
		public void Can_hit_endpoint()
		{
			ArtistBrowse artistBrowse = Api<ArtistBrowse>
				.Get.WithParameter("letter", "radio").Please();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(1));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(10));
			Assert.That(artistBrowse.Artists.Count,Is.GreaterThan(0));
		}

		[Test]
		public void Can_hit_endpoint_with_fluent_interface()
		{
			var artistBrowse = Api<ArtistBrowse>.Get
									.WithLetter("radio")
									.Please();
			
			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(1));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(10));
			Assert.That(artistBrowse.Artists.Count, Is.GreaterThan(0));
		}

		[Test]
		public void Can_hit_endpoint_with_paging()
		{
			ArtistBrowse artistBrowse = Api<ArtistBrowse>.Get
				.WithParameter("letter", "radio")
				.WithParameter("page", "2")
				.WithParameter("pageSize", "20")
				.Please();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(2));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(20));
		}


		[Test]
		public void Can_hit_endpoint_with_fluent_interface_with_paging()
		{
			var artistBrowse = (ArtistBrowse)Api<ArtistBrowse>
									.Get
									.WithLetter("radio")
									.WithPageNumber(2)
									.WithPageSize(20)
									.Please();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(2));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(20));
		}
	}
}