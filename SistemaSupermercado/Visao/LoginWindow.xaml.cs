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
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        public string Usuario { get => txtUsuario.Text; }
        public string Senha { get => txtSenha.Password; }

        private void btnEntrar(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
