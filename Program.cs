namespace LongestSequenceOfSameTemperature 
{
    internal class Program
    {
        static int? minTemperature = default!;
        static int? maxTemperature = default!;

        static void Main(string[] args)
        {
            //var temperatures = new int[9] { 7, 12, 5, 3, 11, 6, 10, 2, 9 };
            //var temperatures = new int[9] { 7, 9, 10, 3, 2, 1, 0, -1, 9 };
            var temperatures = new int[9] { 7, 6, 5, 4, 3, 2, 2, 3, 9 };

            var longestStartDay = 0;
            var longestEndDay = 0;

            var maxRange = 1;
            var startDay = 0;
            var endDay = 0;

            for (int day = 0; day < temperatures.Length; day++)
            {
                var temperature = temperatures[day];

                if (day != 0)
                {
                    if (!(temperature >= minTemperature && temperature <= maxTemperature))
                    {
                        endDay = day - 1;
                        if ((endDay - startDay) + 1 >= maxRange)
                        {
                            longestStartDay = startDay;
                            longestEndDay = endDay;
                            maxRange = longestEndDay - longestStartDay + 1;
                        }

                        startDay = day;

                        setMinMaxTemperature(temperature);
                    }
                    else
                    {
                        if (temperature <= minTemperature + 2 || temperature >= maxTemperature - 2)
                            setMinMaxTemperature(temperature);

                        endDay = day;
                    }
                }
                else
                {
                    setMinMaxTemperature(temperature);
                }
            }

            Console.WriteLine(longestStartDay);
            Console.WriteLine(longestEndDay);

        }

        static void setMinMaxTemperature(int temperature)
        {
            minTemperature = temperature - 2;
            maxTemperature = temperature + 2;
        }

    }
}