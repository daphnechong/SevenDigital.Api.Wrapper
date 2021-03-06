﻿using System;
using System.Linq;
using SevenDigital.Api.Wrapper.Exceptions;
using SevenDigital.Api.Wrapper.Schema.ArtistEndpoint;
using SevenDigital.Api.Wrapper.Schema.LockerEndpoint;

namespace SevenDigital.Api.Wrapper.ExampleUsage {
	class Program {
        static void Main(string[] args)
        {
            string s = args[0];

            // -- artist/details
            var artist = Api<Artist>.Get
                .WithParameter("artistId", s)
                .Please();

            Console.WriteLine("Artist \"{0}\" selected", artist.Name);
            Console.WriteLine("Website url is {0}", artist.Url);
            Console.WriteLine();


            // -- artist/toptracks
            var artistTopTracks = Api<ArtistTopTracks>
                .Get
                .WithParameter("artistId", s)
                .Please();

            Console.WriteLine("Top Track: {0}", artistTopTracks.Tracks.FirstOrDefault().Title);
            Console.WriteLine();


            // -- artist/browse
            const string searchValue = "Radioh";
            var artistBrowse = Api<ArtistBrowse>
                .Get
                .WithLetter(searchValue)
                .Please();

            Console.WriteLine("Browse on \"{0}\" returns: {1}", searchValue, artistBrowse.Artists.FirstOrDefault().Name);
            Console.WriteLine();

            // -- user/locker
            var locker = Api<Locker>
                .Get
                .ForUser("token", "secret")
                .Please();

            Console.WriteLine("Locker returns {0}", locker);

            try
            {
                // -- Deliberate error response
                Console.WriteLine("Trying artist/details without artistId parameter...");
                Api<Artist>.Get.Please();

            }
            catch (ApiXmlException ex)
            {
                Console.WriteLine("{0} : {1}", ex.Error.Code, ex.Error.ErrorMessage);
            }
            Console.ReadKey();
        }
	}

   
}
