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
    /// Lógica interna para DadosCaixa.xaml
    /// </summary>
    public partial class DadosCaixa : Window
    {

        NLogin NL;

        public DadosCaixa()
        {
            InitializeComponent();
        }

        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            NL = new NLogin();
            NL.TrocarSenha(loginCaixa.Text, senhaCaixa.Text);
            this.Close();
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
