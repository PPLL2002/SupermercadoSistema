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
using System.Windows.Shapes;

namespace Visao
{
    /// <summary>
    /// Lógica interna para TelaCaixa.xaml
    /// </summary>
    public partial class TelaCaixa : Window
    {
        public TelaCaixa()
        {
            InitializeComponent();
        }

        private void btnAlterarDados(object sender, RoutedEventArgs e)
        {
            DadosCaixa dc = new DadosCaixa();
            dc.ShowDialog();
        }

        private void btnVendas(object sender, RoutedEventArgs e)
        {

        }
    }
}
