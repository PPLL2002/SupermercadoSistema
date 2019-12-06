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
    /// Lógica interna para DadosDono.xaml
    /// </summary>
    public partial class DadosDono : Window
    {
        Dono d;
        NDono nD;
        NLogin NL;
        public DadosDono()
        {
            InitializeComponent();
            nD = new NDono();
            d = nD.Listar();
            nomeAdm.Text = d.Nome;
            cpfAdm.Text = d.Cpf;
        }

        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            try { 
                d.Nome = nomeAdm.Text;
                d.Cpf = cpfAdm.Text;
                nD = new NDono();
                nD.Update(d);
                NL = new NLogin();
                NL.TrocarSenha(loginAdm.Text, senhaAdm.Text);
                this.Close();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Preencha todos os campos para altera-los ou pressione cancelar");
            }
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
