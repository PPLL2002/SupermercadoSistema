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
using Negocio;

namespace Visao
{
    /// <summary>
    /// Lógica interna para RelatorioEstoque.xaml
    /// </summary>
    public partial class RelatorioEstoque : Window
    {
        public RelatorioEstoque()
        {
            InitializeComponent();
        }

        private void btnCustoTotal(object sender, RoutedEventArgs e)
        {
            NRelatorio rela = new NRelatorio();
            Caixa.Text = "R$ " + rela.CalcularCusto().ToString();
        }

        private void btnReceitaTotal(object sender, RoutedEventArgs e)
        {
            NRelatorio rela = new NRelatorio();
            Caixa.Text = "R$ " + rela.CalcularReceita().ToString();
        }

        private void btnLucroTotal(object sender, RoutedEventArgs e)
        {
            NRelatorio rela = new NRelatorio();
            Caixa.Text = "R$ " + rela.CalcularLucro().ToString();
        }

        private void btnTicketMedio(object sender, RoutedEventArgs e)
        {
            NRelatorio rela = new NRelatorio();
            Caixa.Text = "R$ " + rela.CalcularTicketMedio().ToString();
        }
    }
}
