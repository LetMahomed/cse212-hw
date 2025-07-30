using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = [];
        List<string> result = [];

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1]) continue;

            string reversed = new([word[1], word[0]]);

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return [.. result];
    }       

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length < 4) continue;

            string degree = fields[3].Trim();

            if (degrees.TryGetValue(degree, out int value))
                degrees[degree] = ++value;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.TryGetValue(c, out int value))
                counts[c] = ++value;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.TryGetValue(c, out int value)) return false;

            counts[c] = --value;

            if (value < 0) return false;
        }

        return true;
    }


    public static string[] EarthquakeDailySummary()
{
    const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
    using var client = new HttpClient();
    using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
    using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
    using var reader = new StreamReader(jsonStream);
    var json = reader.ReadToEnd();

    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var featureCollection = JsonSerializer.Deserialize<EarthquakeFeatureCollection>(json, options);

    List<string> summaries = [];

    if (featureCollection?.Features != null)
    {
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties?.Place;
            var mag = feature.Properties?.Mag;

            if (!string.IsNullOrWhiteSpace(place) && mag.HasValue)
            {
                summaries.Add($"{place} - Mag {mag.Value}");
            }
        }
    }

    return [.. summaries];
}

}

// JSON model classes for Earthquake data
public class EarthquakeFeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
