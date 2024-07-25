namespace WeatherCalcLib
{
    public static class WeatherCalc
    {
        public static double DewPoint(double temperature, double humidity)
        {
            const double K2 = 17.62;
            const double K3 = 243.12;

            double dewPoint = K3 * (Math.Log(humidity / 100) + ((K2 * temperature) / (K3 + temperature))) / (K2 - Math.Log(humidity / 100) - ((K2 * temperature) / (K3 + temperature)));

            return dewPoint;
        }

        public static double HeatIndexInDegree(double temperature, double humidity)
        {
            const double C1 = -8.78469475556;
            const double C2 = 1.61139411;
            const double C3 = 2.33854883889;
            const double C4 = -0.14611605;
            const double C5 = -0.012308094;
            const double C6 = -0.0164248277778;
            const double C7 = 0.002211732;
            const double C8 = 0.00072546;
            const double C9 = -0.000003582;

            double heatIndex = C1 + (C2 * temperature) + (C3 * humidity) + (C4 * temperature * humidity) + (C5 * Math.Pow(temperature, 2)) + 
                (C6 * Math.Pow(humidity, 2)) + (C7 * Math.Pow(temperature, 2) * humidity) + (C8 * temperature * Math.Pow(humidity, 2)) + (C9 * Math.Pow(temperature, 2) * Math.Pow(humidity, 2));

            return heatIndex;
        }

        public static double WindChillInDegree(double temperature, double windSpeed)
        {
            const double C1 = 13.12;
            const double C2 = 0.6215;
            const double C3 = 11.37;
            const double C4 = 0.3965;

            double windChill = C1 + C2 * temperature + (C4 * temperature - C3) * Math.Pow(windSpeed,0.16);

            return windChill;
        }

        public static double CloudBase(double temperature, double dewPoint)
        {
            double cloudBase = (temperature - dewPoint) * 125;

            return cloudBase;
        }
    }
}
