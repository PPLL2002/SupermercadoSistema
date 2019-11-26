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
    /// Lógica interna para CadFuncionario.xaml
    /// </summary>
    public partial class CadFuncionario : Window
    {
        public CadFuncionario()
        {
            InitializeComponent();
        }


        private void btnInserirF(object sender, RoutedEventArgs e)
        {
            Funcionario f = new Funcionario();
            f.Nome = fNome.Text;
            f.Email = fEmail.Text;
            f.Telefone = fTelefone.Text;
            f.Cpf = fCpf.Text;
            f.NumeroConta = fNConta.Text;
            f.Formacao = fFormacao.Text;
            f.DataIngresso = DateTime.Now;

            NFuncionario nF = new NFuncionario();
            nF.Insert(f);

            this.Close();
        }
    }
}
