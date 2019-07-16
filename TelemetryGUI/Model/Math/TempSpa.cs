namespace TelemetryGUI.Model.Math
{
    public class TempSpa
    {
        public int Year { get; set; } // 4-digit year,      valid range: -2000 to 6000, error code: 1
        public int Month { get; set; } // 2-digit month,         valid range: 1 to  12,  error code: 2
        public int Day { get; set; } // 2-digit day,           valid range: 1 to  31,  error code: 3
        public int Hour { get; set; } // Observer local hour,   valid range: 0 to  24,  error code: 4
        public int Minute { get; set; } // Observer local minute, valid range: 0 to  59,  error code: 5
        public double Second { get; set; } // Observer local second, valid range: 0 to <60,  error code: 6

        public double DeltaUt1 { get; set; } // Fractional second difference between UTC and UT which is used
        // to adjust UTC for earth's irregular rotation rate and is derived
        // from observation only and is reported in this bulletin:
        // http://maia.usno.navy.mil/ser7/ser7.dat,
        // where delta_ut1 = DUT1
        // valid range: -1 to 1 second (exclusive), error code 17

        public double DeltaT { get; set; } // Difference between earth rotation time and terrestrial time
        // It is derived from observation only and is reported in this
        // bulletin: http://maia.usno.navy.mil/ser7/ser7.dat,
        // where delta_t = 32.184 + (TAI-UTC) - DUT1
        // valid range: -8000 to 8000 seconds, error code: 7

        public double Timezone { get; set; } // Observer time zone (negative west of Greenwich)
        // valid range: -18   to   18 hours,   error code: 8

        public double Longitude { get; set; } // Observer longitude (negative west of Greenwich)
        // valid range: -180  to  180 degrees, error code: 9

        public double Latitude { get; set; } // Observer latitude (negative south of equator)
        // valid range: -90   to   90 degrees, error code: 10

        public double Elevation { get; set; } // Observer elevation [meters]
        // valid range: -6500000 or higher meters,    error code: 11

        public double Pressure { get; set; } // Annual average local pressure [millibars]
        // valid range:    0 to 5000 millibars,       error code: 12

        public double Temperature { get; set; } // Annual average local temperature [degrees Celsius]
        // valid range: -273 to 6000 degrees Celsius, error code{ get; set; }  13

        public double Slope { get; set; } // Surface slope (measured from the horizontal plane)
        // valid range: -360 to 360 degrees, error code: 14

        public double AzmRotation { get; set; } // Surface azimuth rotation (measured from south to projection of
        //     surface normal on horizontal plane, negative east)
        // valid range: -360 to 360 degrees, error code: 15

        public double AtmosRefract { get; set; } // Atmospheric refraction at sunrise and sunset (0.5667 deg is typical)
        // valid range: -5   to   5 degrees, error code: 16
    }
}