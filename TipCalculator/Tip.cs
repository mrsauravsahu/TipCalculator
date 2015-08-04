using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator
{
    public class Tip
    {
        public String BillAmount { get; set; }
        public String TipAmount { get; set; }
        public String  TotalAmount { get; set; }
        public Tip()
        {
            BillAmount = String.Empty;
            TipAmount = String.Empty;
            TotalAmount = String.Empty;
        }
        public void calculateTip(string originalBillAmount, double tipPercentage)
        {
            double billAmount, tipAmount, totalAmount;
            billAmount = tipAmount = totalAmount = 0.0;

            if(double.TryParse(originalBillAmount, out billAmount))
            {
                tipAmount = billAmount * tipPercentage;
                totalAmount = tipAmount + billAmount;
            }
            this.BillAmount = String.Format("{0:C}", billAmount.ToString()).Replace('$', ' ');
            this.TipAmount = String.Format("{0:C}", tipAmount.ToString()).Replace('$', ' ');
            this.TotalAmount = String.Format("{0:C}", totalAmount.ToString()).Replace('$', ' ');
        }
    }
}
