namespace JE
{
    public class HouseholdRobot : Robot
    {
        private List<HouseholdSkill> Skills = new List<HouseholdSkill>();

        public HouseholdRobot(string name, double capacity, double current)
        {
            RobotName = name;
            PowerCapacityKWH = capacity;
            CurrentPowerKWH = current;
            DownloadSkill(HouseholdSkill.Cleaning);
        }

        public void DownloadSkill(HouseholdSkill skill)
        {
            if (!Skills.Contains(skill))
                Skills.Add(skill);
        }

        public override string DescribeRobot()
        {
            return $"I am a household robot.\nHousehold Robot Skills:\n{string.Join(", ", Skills)}\n{DisplayBatteryInformation()}";
        }
    }
}
