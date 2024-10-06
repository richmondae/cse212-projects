using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // Find pairs of words that are reverse of each other
        // Create a set for fast lookup and a list to store pairs
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> pairs = new List<string>();

        // Loop through each word in the list
        foreach (string word in words)
        {
            // Reverse the word
            string reversed = new string(word.Reverse().ToArray());

            // If the reversed word exists in the set and it's not the same word
            if (wordSet.Contains(reversed) && word != reversed)
            {
                // Add the pair and remove them from the set to avoid duplicates
                pairs.Add($"{word} & {reversed}");
                wordSet.Remove(word); 
                wordSet.Remove(reversed);
            }
        }
        return pairs.ToArray(); // Return the result as an array
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            if (fields.Length > 3)
            {
                // The degree is in the 4th column
                var degree = fields[3].Trim();

                // If the degree hasn't been seen before, add it to the dictionary
                if (!degrees.ContainsKey(degree))
                {
                    degrees[degree] = 0;
                }

                // Increment the count for this degree
                degrees[degree]++;
            }
        }
        // Return the dictionary
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Clean up both words (remove spaces and make them lowercase)
        var cleanedWord1 = new string(word1.Where(c => !char.IsWhiteSpace(c)).Select(c => char.ToLower(c)).ToArray());
        var cleanedWord2 = new string(word2.Where(c => !char.IsWhiteSpace(c)).Select(c => char.ToLower(c)).ToArray());

        // If the words aren't the same length, they can't be anagrams
        if (cleanedWord1.Length != cleanedWord2.Length)
        {
            return false;
        }

        // Count the number of each letter in word1
        var letterCount = new Dictionary<char, int>();

        foreach (char c in cleanedWord1)
        {
            if (letterCount.ContainsKey(c))
            {
                letterCount[c]++;
            }
            else
            {
                letterCount[c] = 1;
            }
        }

        // Check that word2 has the same letters
        foreach (char c in cleanedWord2)
        {
            if (!letterCount.ContainsKey(c) || letterCount[c] == 0)
            {
                return false; // Not an anagram if it has different letters
            }

            letterCount[c]--;
        }

        return true; // If everything matches, they're anagrams
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
      // Prepare a list to store the earthquake summaries
        List<string> summaries = new List<string>();

        // Loop through each earthquake and create a summary string
        foreach (var feature in featureCollection.Features)
        {
            summaries.Add($"{feature.Properties.Place} - Magnitude: {feature.Properties.Magnitude}");
        }

        return summaries.ToArray(); // Return the list of summaries as an array
    }
}
