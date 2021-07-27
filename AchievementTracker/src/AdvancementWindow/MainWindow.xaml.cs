using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            DisplayAdvancements();
            Closed += MainWindow_Closed;

        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Save.SaveAdvancments(Advancements);
        }

        public void DisplayAdvancements()
        {

            MonstersHuntedList.ItemsSource = Advancements.MonstersHunted.Objects;

            AdventuringTimeList.ItemsSource = Advancements.AdventuringTime.Objects;

            TwoByTwoList.ItemsSource = Advancements.TwoByTwo.Objects;

            ABalancedDietList.ItemsSource = Advancements.AbalancedDiet.Objects;

            MonsterHuntedInfo.Text = GetInfo.Get(Advancements.MonstersHunted.Objects);
            AdventuringTimeInfo.Text = GetInfo.Get(Advancements.AdventuringTime.Objects);
            TwoByTwoInfo.Text = GetInfo.Get(Advancements.TwoByTwo.Objects);
            ABalancedDietInfo.Text = GetInfo.Get(Advancements.AbalancedDiet.Objects);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           var result = MessageBox.Show("Press Ok to confirm", "Delete Save", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Delete.DeleteAdvancments();
                Advancements = new Advancements();
                CreateAdvancements.Create(Advancements);
                DisplayAdvancements();
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                Reader.Read(file.OpenFile());
                DisplayAdvancements();
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
            ABalancedDietInfo.Text = GetInfo.Get(Advancements.AbalancedDiet.Objects);
            
        }
    }

}
    
    

