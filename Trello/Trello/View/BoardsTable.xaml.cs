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

namespace Trello.View
{
    /// <summary>
    /// Interaction logic for BoardsTable.xaml
    /// </summary>
    public partial class BoardsTable : Page
    {
        public BoardsTable()
        {
            InitializeComponent();
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "SuccessBtn")
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void SuccessBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "SuccessBtn")
                {
                    button.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteBoardBtn")
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void ListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteBoardBtn")
                {
                    button.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
