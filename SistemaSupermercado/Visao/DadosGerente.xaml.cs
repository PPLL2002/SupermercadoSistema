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
using Modelo;
using Negocio;

namespace Visao
{
    /// <summary>
    /// Lógica interna para DadosGerente.xaml
    /// </summary>
    public partial class DadosGerente : Window
    {
        NLogin NL;
        public DadosGerente()
        {
            InitializeComponent();

        }

        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            NL = new NLogin();
            NL.TrocarSenha(loginGerente.Text, senhaGerente.Text);
            this.Close();
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
