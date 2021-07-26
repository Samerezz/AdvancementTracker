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


using AdvancementTracker.src.Core.Advancement;
using AdvancementTracker.src.Core.Data;
namespace AdvancementTracker.src.AchievementWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load.LoadAdvancments();
            DisplayAdvancements();
            Closed += MainWindow_Closed;

        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Save.SaveAdvancments();
        }

        public void DisplayAdvancements()
        {

            MonstersHuntedList.ItemsSource = CreateAdvancements.Advancements.MonstersHunted.Objects;

            AdventuringTimeList.ItemsSource = CreateAdvancements.Advancements.AdventuringTime.Objects;

            TwobyTwoList.ItemsSource = CreateAdvancements.Advancements.TwoByTwo.Objects;

            ABalancedDietList.ItemsSource = CreateAdvancements.Advancements.ABlanacedDiet.Objects;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           var result = MessageBox.Show("Press Ok to confirm", "Delete Save", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Delete.DeleteAdvancments();
                CreateAdvancements.Advancements = new Advancements();
                CreateAdvancements.Create();
                DisplayAdvancements();
            }
        }
    }

}
    
    

