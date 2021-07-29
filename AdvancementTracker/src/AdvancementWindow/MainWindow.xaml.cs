using System;
using System.Windows;
using Microsoft.Win32;

using AdvancementTracker.src.Core.Advancement;
using AdvancementTracker.src.Core.Data;
using AdvancementTracker.src.Core.AdvancementFileReader;
namespace AdvancementTracker.src.AdvancementWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Advancements Advancements { get; set; } = new Advancements();
        public MainWindow()
        {
            InitializeComponent();
            Load.LoadAdvancments();
            DisplayAdvancements(Advancements);
            Closed += MainWindow_Closed;
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Save.SaveAdvancments(Advancements);
        }

        /// <summary>
        /// Displays the advancements on the advancements lists and text blocks
        /// </summary>
        /// <param name="advancements">The advancements to display</param>
        public void DisplayAdvancements(Advancements advancements)
        {
            MonstersHuntedList.ItemsSource = advancements.MonstersHunted.Objects;
            AdventuringTimeList.ItemsSource = advancements.AdventuringTime.Objects;
            TwoByTwoList.ItemsSource = advancements.TwoByTwo.Objects;
            ABalancedDietList.ItemsSource = advancements.ABalancedDiet.Objects;

            MonsterHuntedInfo.Text = GetInfo.Get(advancements.MonstersHunted.Objects);
            AdventuringTimeInfo.Text = GetInfo.Get(advancements.AdventuringTime.Objects);
            TwoByTwoInfo.Text = GetInfo.Get(advancements.TwoByTwo.Objects);
            ABalancedDietInfo.Text = GetInfo.Get(advancements.ABalancedDiet.Objects);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Press Ok to confirm", "Delete Save", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Delete.DeleteAdvancments();
                Advancements = new Advancements();
                CreateAdvancements.Create(Advancements);
                DisplayAdvancements(Advancements);
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                var data = Reader.Read(file.OpenFile());
                Advancements = CreateJson.Create(data);
                DisplayAdvancements(Advancements);
            }
        }

        private void MonsterHuntedCheckBox_Click(object sender, RoutedEventArgs e)
        {
            MonsterHuntedInfo.Text = GetInfo.Get(Advancements.MonstersHunted.Objects);
        }
        private void AdventuringTimeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            AdventuringTimeInfo.Text = GetInfo.Get(Advancements.AdventuringTime.Objects);
        }
        private void TwoByTwoCheckBox_Click(object sender, RoutedEventArgs e)
        {
            TwoByTwoInfo.Text = GetInfo.Get(Advancements.TwoByTwo.Objects);
        }
        private void ABlanacedDietCheckBox_Click(object sender, RoutedEventArgs e)
        {
            ABalancedDietInfo.Text = GetInfo.Get(Advancements.ABalancedDiet.Objects);

        }
    }

}



