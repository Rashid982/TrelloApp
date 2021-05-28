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
    /// Interaction logic for SelfBoard.xaml
    /// </summary>
    public partial class SelfBoard : Page
    {
        public SelfBoard()
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

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "SuccessBtn1")
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteCardBtn")
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteCardBtn")
                {
                    button.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteListBtn")
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "DeleteListBtn")
                {
                    button.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var txtbox in FindVisualChildren<TextBox>(this))
            {
                if (txtbox.Name == "CardTitleTxtBox")
                {
                    if (string.IsNullOrWhiteSpace(txtbox.Text))
                    {
                        txtbox.Visibility = Visibility.Visible;
                        foreach (var datepicker in FindVisualChildren<DatePicker>(this))
                        {
                            if (datepicker.Name == "DatetimePckr")
                            {
                                datepicker.Visibility = Visibility.Visible;
                            }
                        }

                        foreach (var border in FindVisualChildren<Border>(this))
                        {
                            if (border.Name == "NewCardBorder")
                            {
                                border.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        txtbox.Visibility = Visibility.Hidden;
                        foreach (var datepicker in FindVisualChildren<DatePicker>(this))
                        {
                            if (datepicker.Name == "DatetimePckr")
                            {
                                datepicker.Visibility = Visibility.Hidden;
                            }
                        }
                        foreach (var border in FindVisualChildren<Border>(this))
                        {
                            if (border.Name == "NewCardBorder")
                            {
                                border.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var txtBox in FindVisualChildren<TextBox>(this))
            {
                if (txtBox.Name == "ListTitleTxtbox")
                {
                    if (string.IsNullOrWhiteSpace(txtBox.Text))
                    {
                        txtBox.Visibility = Visibility.Visible;
                        foreach (var button in FindVisualChildren<Button>(this))
                        {
                            if (button.Name == "AddListBtn")
                            {
                                button.Background = Brushes.Green;
                                button.Foreground = Brushes.White;
                            }
                        }
                        foreach (var button in FindVisualChildren<Button>(this))
                        {
                            if (button.Name == "CloseBtn")
                            {
                                button.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        txtBox.Visibility = Visibility.Collapsed;
                        foreach (var button in FindVisualChildren<Button>(this))
                        {
                            if (button.Name == "AddListBtn")
                            {
                                var bc = new BrushConverter();
                                button.Background = Brushes.Transparent;
                                button.Foreground = (Brush)bc.ConvertFrom("#5e6c84");
                            }
                        }
                        foreach (var button in FindVisualChildren<Button>(this))
                        {
                            if (button.Name == "CloseBtn")
                            {
                                button.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }            
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "CloseBtn")
                {
                    button.Visibility = Visibility.Collapsed;
                }
            }

            foreach (var txtBox in FindVisualChildren<TextBox>(this))
            {
                if (txtBox.Name == "ListTitleTxtbox")
                {                   
                    txtBox.Visibility = Visibility.Collapsed;                    
                }
            }

            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "AddListBtn")
                {
                    var bc = new BrushConverter();
                    button.Background = Brushes.Transparent;
                    button.Foreground = (Brush)bc.ConvertFrom("#5e6c84");
                }
            }
        }

        private void AddListBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "AddListBtn")
                {
                    if(button.Background == Brushes.Green)
                    {
                        button.Background = Brushes.DarkGreen;
                        button.Foreground = Brushes.Black;
                    }
                    
                }
            }
        }

        private void AddListBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var button in FindVisualChildren<Button>(this))
            {
                if (button.Name == "AddListBtn")
                {
                    if (button.Background == Brushes.DarkGreen)
                    {
                        button.Background = Brushes.Green;
                        button.Foreground = Brushes.White;
                    }

                }
            }
        }
    }
}
