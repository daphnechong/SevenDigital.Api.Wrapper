﻿namespace SevenDigital.Api.Wrapper.Schema.TrackEndpoint
{
	public static class TrackExtensions
	{
		public static IFluentApi<Track> WithTrackId(this IFluentApi<Track> api, int trackId)
		{
			api.WithParameter("trackId", trackId.ToString());
			return api;
		}
	}
}