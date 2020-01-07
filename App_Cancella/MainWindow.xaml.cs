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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Start1_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(()=>DoWork());
        }

        private void DoWork()
        {
            for (int i = 0; i < 100; i++)
            {
                Dispatcher.Invoke(()=>UpdateUI(i));
                Thread.Sleep(1000);
            }
        }

        private void UpdateUI(int i)
        {
            lbl_Count1.Content = i.ToString();
        }

    }
}
