using System.Windows;
using System.Windows.Controls;

using AdvancementTracker.src.Core.Advancement;

namespace AdvancementTracker.src.UI.UserControls
{
    
    public partial class AdvancementsList : UserControl
    {
        public static readonly DependencyProperty FirstTextProp = DependencyProperty.Register("FirstText", typeof(string),typeof(TextBlock));
        public static readonly DependencyProperty ListItemsProp = DependencyProperty.Register("ListItems", typeof(Advancement),typeof(object));
        public static readonly DependencyProperty SecondTextProp = DependencyProperty.Register("SecondText", typeof(string),typeof(TextBlock));
        public string FirstText { get { return GetValue(FirstTextProp) as string; } set { SetValue(FirstTextProp, value); } } 
        public string SecondText { get { return GetValue(SecondTextProp) as string; } set { SetValue(SecondTextProp, value); } }
        public Advancement ListItems { get { return GetValue(ListItemsProp) as Advancement; } set { SetValue(ListItemsProp, value); } }
        public AdvancementsList()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += AdvancementsList_Loaded;
        }
        /// <summary>
        /// Updates the list
        /// </summary>
        public void Update()
        {
            List.ItemsSource = ListItems.Objects;
            Info.Text = GetInfo.Get(ListItems.Objects);
        }
        private void AdvancementsList_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ListCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
