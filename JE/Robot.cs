using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JE
{
    public abstract class Robot
    {
        public string RobotName { get; set; }
        public double PowerCapacityKWH { get; set; }
        public double CurrentPowerKWH { get; set; }

        public double GetBatteryPercentage()
        {
            if (PowerCapacityKWH == 0) return 0;
            return (CurrentPowerKWH / PowerCapacityKWH) * 100.0;
        }

        public string DisplayBatteryInformation()
        {
            return $"Battery: {CurrentPowerKWH:F2} / {PowerCapacityKWH:F2} kWh ({GetBatteryPercentage():F1}%)";
        }

        public abstract string DescribeRobot();

        public override string ToString()
        {
            return $"{RobotName} ({this.GetType().Name})";
        }
    }
}
