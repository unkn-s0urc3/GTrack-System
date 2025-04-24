using GTrack_SGP4.CoordinateSystem;
using GTrack_SGP4.Observation;
using GTrack_SGP4.TLE;
using GTrack_SGP4.Util;

class Program
{
    static void Main(string[] args)
    {
        var provider = new LocalTleProvider(true, "D:\\Projects\\GitHub\\GTrack-System\\data\\visual.txt");

        // Get every TLE
        var tles = provider.GetTles();

        // Alternatively get a specific satellite's TLE
        var issTle = provider.GetTle(25544);

        Console.WriteLine(issTle.Epoch);
    }
}