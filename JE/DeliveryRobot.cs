namespace JE
{
    public class DeliveryRobot : Robot
    {
        public DeliveryMode ModeOfDelivery { get; set; }
        public double MaxLoadKG { get; set; }
        private List<HouseholdSkill> Skills = new List<HouseholdSkill>();

        public DeliveryRobot(string name, double powerCapacity, double currentPower, DeliveryMode mode, double maxLoad)
        {
            RobotName = name;
            PowerCapacityKWH = powerCapacity;
            CurrentPowerKWH = currentPower;
            ModeOfDelivery = mode;
            MaxLoadKG = maxLoad;
        }

        public void DownloadSkill(HouseholdSkill skill)
        {
            if (!Skills.Contains(skill))
                Skills.Add(skill);
        }

        public override string DescribeRobot()
        {
            return $"I am a Delivery robot.\nDelivery mode: {ModeOfDelivery}\nMaximum load: {MaxLoadKG} kg\n{DisplayBatteryInformation()}";
        }
    }
}
