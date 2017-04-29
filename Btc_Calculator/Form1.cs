using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btc_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Hide();
            SplashForm.ShowSplashScreen();
            //Thread.Sleep(5000);
            var MainForm = new Form1();
            //MainForm.Closed += (s, args) => this.Close();



            List<string> RawHashRate = MyClass.GetNetworkHashrate("/html/body/div[2]/table[2]/tr[4]/td[2]");
            string HashRate = RawHashRate[0].Replace("GH/s", string.Empty);
            tbxNetworkHashRate.Text = HashRate;
            //*[@id="currency"]
            List<string> BTCPrice = MyClass.GetCurrency("//*[@id='orders-stats']/div[1]/strong");
            //string BTCpriceString = BTCPrice[0].Replace(" USD", string.Empty).Replace(".",",");
            string BTCpriceString = (Convert.ToDouble(MyClass.GetTRYCurrency("https://www.btcturk.com/", "//*[@id='tmpl-market-trade-inject']/span[2]")[0].Replace(",", string.Empty).Replace(".", ",").ToString()) / Convert.ToDouble(DövizKur.USD().Replace(".", ",").ToString())).ToString();
            BTCpriceString = Math.Round(Convert.ToDouble(BTCpriceString), 2).ToString();
            tbxBTCPrice.Text = BTCpriceString;
            tbxMoneyBTCPrice.Text = BTCpriceString;

            lblUSDCurrency.Text = DövizKur.USD().Replace(".", ",");




            //MainForm.Show();
            SplashForm.CloseForm();

            FormChecker.Enabled = true; //TİMER

            //MainForm.TopMost = true;
            //MainForm.TopMost = false;

        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {

            double HashRate = Convert.ToDouble(tbxHashRate.Text);
            double NetworkHashRate = Convert.ToDouble(tbxNetworkHashRate.Text.Replace(",", string.Empty));
            double MaintenanceFee = Convert.ToDouble(tbxMaintenanceFee.Text);
            double BTCPrice = Convert.ToDouble(tbxBTCPrice.Text);
            double result;

            result = (HashRate / NetworkHashRate * 3600) - (MaintenanceFee * HashRate / BTCPrice);
            //result = Math.Round(result, 5);

            tbxResult.Text = result.ToString();
            tbxBTCPerDay.Text = result.ToString();
        }

        private void btnMoneyCalculate_Click(object sender, EventArgs e)
        {
            double DailyProfit = Convert.ToDouble(tbxBTCPerDay.Text) * Convert.ToDouble(tbxMoneyBTCPrice.Text);
            double WeeklyProfit = DailyProfit * 7;
            double MonthlyProfit = DailyProfit * 30.417;

            DailyProfit = Math.Round(DailyProfit, 5);
            WeeklyProfit = Math.Round(WeeklyProfit, 5);
            MonthlyProfit = Math.Round(MonthlyProfit, 5);

            tbxROIDailyProfit.Text = DailyProfit.ToString();

            tbxDailyProfit.Text = DailyProfit.ToString();
            tbxWeeklyProfit.Text = WeeklyProfit.ToString();
            tbxMonthlyProfit.Text = MonthlyProfit.ToString();
        }

        private void btnROICalculate_Click(object sender, EventArgs e)
        {
            double DailyProfit = Convert.ToDouble(tbxROIDailyProfit.Text);
            double SpendedMoney = Convert.ToDouble(tbxROISpendedMoney.Text);
            double result;

            result = (SpendedMoney) / (DailyProfit * 30.417);

            result = Math.Round(result, 1);

            tbxROIROIinMonths.Text = result.ToString();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            tbxData.Text = MyClass.GetTRYCurrency(tbxSiteURL.Text, tbxXpath.Text)[0].ToString();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            tbxUSD.Text = (Convert.ToDouble(tbxTRY.Text) / Convert.ToDouble(lblUSDCurrency.Text)).ToString();
        }

        private void FormChecker_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
            FormChecker.Enabled = false;
        }

        private void GamblingCalculation()
        {
            double baseBet = Convert.ToDouble(tbxgamblingBaseBet.Text);
            double multiplier = Convert.ToDouble(tbxgamblingMultiplier.Text);
            double increaseRatio = Convert.ToDouble(tbxgamblingIncreaseBy.Text);
            double[] arr_result = new double[100];
            double[] profit = new double[100];
            double total = baseBet;
            double first_bet = baseBet;
            string _result;
            string _profit;
            String.Format("{0:0,0}", 12345.67);


            profit[0] = (baseBet * multiplier) - baseBet;
            arr_result[0] = baseBet;
            richtbxGambling.Text = "1.)  " + baseBet.ToString() + "   | " + profit[0] + " |" + "\n";
            for (int i = 1; i <= 21; i++)
            {


                arr_result[i] = arr_result[i - 1] + arr_result[i - 1] * increaseRatio / 100;
                total = total + arr_result[i];
                profit[i] = Math.Round((arr_result[i] * multiplier) - (total), 1);

                _result = string.Format("{0:0,0}", arr_result[i]);

                richtbxGambling.Text += i + 1 + ".)  " + _result + "   | " + profit[i] + " |" + "\n";
            }



        }

        private void btngamblingCalculate_Click(object sender, EventArgs e)
        {
            GamblingCalculation();
        }
    }
}
