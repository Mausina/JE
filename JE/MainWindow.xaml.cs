using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace JE
{



    // github link https://github.com/Mausina/JE
    //


    public partial class MainWindow : Window
    {
        private List<Robot> robots;
        private List<Robot> allRobots;
        public MainWindow()
        {
            InitializeComponent();
            allRobots = CreateRobots();
            robots = new List<Robot>(allRobots);
            RobotListBox.ItemsSource = robots;
            AllRobotsRadio.IsChecked = true;
        }
        public static List<Robot> CreateRobots()
        {
            var robots = new List<Robot>();

            var houseBot = new HouseholdRobot("HouseBot", 25, 25);
            var gardenMate = new HouseholdRobot("GardenMate", 25, 5);
            gardenMate.DownloadSkill(HouseholdSkill.Gardening);
            var housemate3000 = new HouseholdRobot("Housemate 3000", 25, 15);
            housemate3000.DownloadSkill(HouseholdSkill.Cooking);
            housemate3000.DownloadSkill(HouseholdSkill.Laundry);

            var deliverBot = new DeliveryRobot("DeliverBot", 25, 25, DeliveryMode.Walking, 10);
            var flyBot = new DeliveryRobot("FlyBot", 25, 25, DeliveryMode.Flying, 5);
            var driver = new DeliveryRobot("Driver", 25, 25, DeliveryMode.Driving, 10);

            robots.Add(houseBot);
            robots.Add(gardenMate);
            robots.Add(housemate3000);
            robots.Add(deliverBot);
            robots.Add(flyBot);
            robots.Add(driver);

            return robots;
        }
        private void RobotListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RobotListBox.SelectedItem is Robot selectedRobot)
            {
                RobotDetailsTextBox.Text = selectedRobot.DescribeRobot();
            }
            else
            {
                RobotDetailsTextBox.Text = string.Empty;
            }
        }

        private void ChargeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RobotListBox.SelectedItem is Robot selectedRobot)
            {
                double chargeNeeded = selectedRobot.PowerCapacityKWH - selectedRobot.CurrentPowerKWH;
                if (chargeNeeded <= 0)
                {
                    MessageBox.Show($"{selectedRobot.RobotName} is already fully charged!", "Charge Info");
                }
                else
                {
                    
                    double chargeRate = 25.0;
                    double timeToCharge = chargeNeeded / chargeRate;
                    selectedRobot.CurrentPowerKWH = selectedRobot.PowerCapacityKWH;
                    MessageBox.Show($"{selectedRobot.RobotName} charged successfully!\nTime taken: {timeToCharge:F1} minute.", "Charge Info");
                    RobotDetailsTextBox.Text = selectedRobot.DescribeRobot();
                }
            }
            else
            {
                MessageBox.Show("Please select a robot to charge", "No Robot Selected");
            }
        }

        private void AllRobotsRadio_Click(object sender, RoutedEventArgs e)
        {
            robots = new List<Robot>(allRobots);
            RobotListBox.ItemsSource = robots;
        }

        private void HouseholdRadio_Click(object sender, RoutedEventArgs e)
        {
            robots = allRobots.FindAll(r => r is HouseholdRobot);
            RobotListBox.ItemsSource = robots;
        }

        private void DeliveryRadio_Click(object sender, RoutedEventArgs e)
        {
            robots = allRobots.FindAll(r => r is DeliveryRobot);
            RobotListBox.ItemsSource = robots;
        }


    }
}