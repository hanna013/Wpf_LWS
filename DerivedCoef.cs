using MathNet.Numerics;
using System.Collections.Generic;

namespace DerivedCoef1
{
    public class DerivedCoef
    {
        private int xCmrCenter = 1224;
        private int yCmrCenter = 1024;
        private double CompensationConstant = 16.64;


        public (double,double) CalOffset(double x, double y, int xScanner, int yScanner)
        {
            int dx = xCmrCenter - xScanner;
            int dy = yCmrCenter - yScanner;

            double xOffset = dx * CompensationConstant/1000; // mm 단위로 변환(/1000)
            double yOffset = dy * CompensationConstant/1000;

            double derivedX = x + xOffset;
            double derivedY = y + yOffset;

            return (derivedX, derivedY);  // (double derivedX, double derivedY) = CalOffset(d,d,d,d); 로 받기

        }

    }

    static public class DB
    {
        static public List<double> DB_Scn_X = new List<double>();
        static public List<double> DB_Scn_Y = new List<double>();
        static public List<int> DB_Cmr_X = new List<int>();
        static public List<int> DB_Cmr_Y = new List<int>();
        static public List<double> Derived_X = new List<double>();
        static public List<double> Derived_Y = new List<double>();

        public static (double, double, double, double) Cal_Print()
        {
            double[] xdata_x = DB_Scn_X.ToArray();
            double[] ydata_x = Derived_X.ToArray();

            double[] xdata_y = DB_Scn_Y.ToArray();
            double[] ydata_y = Derived_Y.ToArray();

            (double, double) p_x = Fit.Line(xdata_x, ydata_x);
            double x_intercept = p_x.Item1; // == 10; intercept
            double x_slope = p_x.Item2; // == 0.5; slope

            (double, double) p_y = Fit.Line(xdata_y, ydata_y);
            double y_intercept = p_y.Item1; // == 10; intercept
            double y_slope = p_y.Item2; // == 0.5; slope

            return ( x_slope, x_intercept, y_slope, y_intercept);
        }


    }


}