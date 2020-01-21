using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace App_Cancella
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //bool stop = false;
        CancellationTokenSource ct1;
        CancellationTokenSource ct2;
        CancellationTokenSource ct3;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Btn_Start1_Click(object sender, RoutedEventArgs e)
        {
            ct1 = new CancellationTokenSource();
            if (ct1.Token.IsCancellationRequested)
            {
                ct1.Cancel();
            }
            
            //if (stop) stop = false;
            Task.Factory.StartNew(()=>DoWork(100,1000,lbl_Count1,ct1));
        }

        private void DoWork(int max, int delay, Label lbl,CancellationTokenSource ct)
        {
            
            for (int i = 0; i <= max; i++)
            {
                Dispatcher.Invoke(()=>UpdateUI(i,lbl));
                Thread.Sleep(delay);

                if (ct.Token.IsCancellationRequested) break;//gracefully
                Console.ReadLine();
                
            }
        }

        private void UpdateUI(int i,Label lbl)
        {
            lbl.Content = i.ToString();
        }

        private void Btn_Start2_Click(object sender, RoutedEventArgs e)
        {
            ct2 = new CancellationTokenSource();
            if (ct2.Token.IsCancellationRequested)
            {
                ct2.Cancel();
            }
            
            //if (stop) stop = false;
            int max = Convert.ToInt32(txt_Max1.Text);
            Task.Factory.StartNew(() => DoWork(max, 1000,lbl_Count2,ct2));
        }

        private void Btn_Start3_Click(object sender, RoutedEventArgs e)
        {
            ct3 = new CancellationTokenSource();
            if (ct3.Token.IsCancellationRequested)
            {
                ct3.Cancel();
            }
            
            //if (stop) stop = false;
            int max = Convert.ToInt32(txt_Max2.Text);
            int delay = Convert.ToInt32(txt_Delay.Text);
            Task.Factory.StartNew(() => DoWork(max, delay,lbl_Count3,ct3));
        }

        private void Btn_Stop1_Click(object sender, RoutedEventArgs e)
        {
            if (ct1 != null)
            {
                ct1.Cancel();
            }
            //stop = true;
        }

        private void Btn_Stop2_Click(object sender, RoutedEventArgs e)
        {
            if (ct2 != null)
            {
                ct2.Cancel();
            }
            //stop = true;
        }

        private void Btn_Stop3_Click(object sender, RoutedEventArgs e)
        {
            if (ct3 != null)
            {
                ct3.Cancel();
            }
            //stop = true;
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {

            if (ct1 != null)
            {
                ct1.Cancel();
            }

             if(ct2!=null)
            {
                ct2.Cancel();
            }

            if(ct3!=null)
            {
                ct3.Cancel();
            }

        }
    }
}
