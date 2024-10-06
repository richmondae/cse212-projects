public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
     // This class holds an array of Feature objects. Each feature represents an earthquake.
    public Feature[] Features { get; set; }
}

public class Feature
{
    // Each Feature has a set of properties related to the earthquake (like location and magnitude).
    public Properties Properties { get; set; }
}

public class Properties
{
    // 'Place' is where the earthquake happened.
    public string Place { get; set; }
    
    // 'Magnitude' represents the strength of the earthquake.
    public double Magnitude { get; set; }
}
