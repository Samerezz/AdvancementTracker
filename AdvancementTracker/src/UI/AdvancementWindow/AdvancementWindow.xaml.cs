using System;
using System.Windows;
using Microsoft.Win32;

using AdvancementTracker.src.Core.Advancement;
using AdvancementTracker.src.Core.Data;
using AdvancementTracker.src.Core.AdvancementFileReader;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace AdvancementTracker.src.UI.AdvancementWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdvancementWindow : Window
    {
        public static Advancements Advancements { get; set; } = new Advancements();
        public AdvancementWindow()
        {
            InitializeComponent();
            ExitImage.Source = ToImage(Properties.Resources.ExitIcon);
            MinimizeImage.Source = ToImage(Properties.Resources.MinimizeIcon);
            Load.LoadAdvancments();
            InitAdvancements(Advancements);
            Closed += MainWindow_Closed;
        }
        /// <summary>
        /// Converts image bytes to a BitmapImage
        /// </summary>
        /// <param name="array">The image bytes to convert</param>
        /// <returns></returns>
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Save.SaveAdvancments(Advancements);
        }
        /// <summary>
        /// Displays the advancements on the advancements lists and text blocks
        /// </summary>
        /// <param name="advancements">The advancements to display</param>
        public void InitAdvancements(Advancements advancements)
        {
            MonsterHuntedList.ListItems = advancements.MonstersHunted;
            AdventuringTimeList.ListItems = advancements.AdventuringTime;
            TwoByTwoList.ListItems = advancements.TwoByTwo;
            ABalancedDietList.ListItems = advancements.ABalancedDiet;
            UpdateLists();
        }
        /// <summary>
        /// Updates all lists
        /// </summary>
        public void UpdateLists()
        {
            MonsterHuntedList.Update();
            AdventuringTimeList.Update();
            TwoByTwoList.Update();
            ABalancedDietList.Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Press Ok to confirm", "Delete Save", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Delete.DeleteAdvancments();
                Advancements = new Advancements();
                CreateAdvancements.Create(Advancements);
                InitAdvancements(Advancements);
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                var data = Reader.Read(file.OpenFile());
                Advancements = CreateJson.Create(data);
                InitAdvancements(Advancements);
            }
        }
        
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }
        private void StackPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

}



