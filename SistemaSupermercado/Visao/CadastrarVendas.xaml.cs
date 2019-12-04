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
    /// Lógica interna para CadastrarVendas.xaml
    /// </summary>
    public partial class CadastrarVendas : Window
    {
        public CadastrarVendas()
        {
            InitializeComponent();
        }

        private void btnIniciarVenda(object sender, RoutedEventArgs e)
        {
            Inicar.Visibility = Visibility.Hidden;
            Cancelar.Visibility = Visibility.Visible;
            Finalizar.Visibility = Visibility.Visible;
            CancelarItem.Visibility = Visibility.Visible;
        }
        private void btnCancelarVenda(object sender, RoutedEventArgs e)
        {
            Inicar.Visibility = Visibility.Visible;
            Cancelar.Visibility = Visibility.Hidden;
            Finalizar.Visibility = Visibility.Hidden;
            CancelarItem.Visibility = Visibility.Hidden;
        }
    }
}
