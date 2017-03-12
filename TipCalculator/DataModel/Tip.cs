namespace TipCalculator.DataModel
{
    public class Tip
    {
        private double billAmount, tipAmount, totalAmount;

        public string BillAmount { get; set; }
        public string TipAmount { get; set; }
        public string TotalAmount { get; set; }

        public void calculateTip(string originalBillAmount, double tipPercentage)
        {
            billAmount = tipAmount = totalAmount = 0.0;

            if (double.TryParse(originalBillAmount, out billAmount))
            {
                tipAmount = billAmount * tipPercentage;
                totalAmount = tipAmount + billAmount;
            }
            this.BillAmount = "₹ " + billAmount.ToString();
            this.TipAmount = "₹ " + tipAmount.ToString();
            this.TotalAmount = "₹ " + totalAmount.ToString();
        }
    }
}
