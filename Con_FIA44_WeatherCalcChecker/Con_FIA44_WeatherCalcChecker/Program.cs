using WeatherCalcLib;

namespace Con_FIA44_WeatherCalcChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double temp = 0;
            double humidity = 0;
            double windSpeed = 0;

            temp = 20;
            humidity = 100;

            double dewpoint = WeatherCalc.DewPoint(temp, humidity);

            temp = 30;
            humidity = 55;

            double heatindex = WeatherCalc.HeatIndexInDegree(temp, humidity);

            temp = -15;
            windSpeed = 5;

            double windchill = WeatherCalc.WindChillInDegree(temp, windSpeed);

            temp = 30;
            dewpoint = 10;
            double cloudBase = WeatherCalc.CloudBase(temp, dewpoint);
        }
    }
}
