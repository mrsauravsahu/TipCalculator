using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TipCalculator.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TipCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tip tip;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            tip = new Tip();
        }

        private void BillAmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BillAmountTextBox.Text = "";
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void BillAmountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (BillAmountTextBox.Text == "")
            {
                BillAmountTextBox.Text = "₹ 0.00";
                return;
            }
            BillAmountTextBox.Text = tip.BillAmount;
        }

        private void BillAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }
        private void performCalculation()
        {
            var selectedRadioButton = MyStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            string billAmount = BillAmountTextBox.Text.Replace("₹", " ");
            tip.calculateTip(billAmount, double.Parse(selectedRadioButton.Tag.ToString()));
            //tip.calculateTip(BillAmountTextBox.Text, double.Parse(selectedRadioButton.Tag.ToString()));

            TipAmountTextBox.Text = tip.TipAmount;
            TotalAmountTextBox.Text = tip.TotalAmount;
        }

    }
}
