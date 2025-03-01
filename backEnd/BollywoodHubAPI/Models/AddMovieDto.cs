﻿namespace BollywoodHubAPI.Models
{
    public class AddMovieDto
    {
        public int[]? genre_ids { get; set; }
        public string? title { get; set; }
        public string? overview { get; set; }
        public string? release_date { get; set; }
        public decimal? vote_average { get; set; }
        public int? vote_count { get; set; }
        public string? poster_path { get; set; }
        public string? original_language { get; set; }

    }
}
