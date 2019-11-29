using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Modelo;
using Negocio;

namespace Visao
{
    /// <summary>
    /// Lógica interna para CadFuncionario.xaml
    /// </summary>
    public partial class CadFuncionario : Window
    {
        private string foto = string.Empty;
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
            f.Foto = foto; 
            NFuncionario nF = new NFuncionario();
            nF.Insert(f);
            this.Close();
        }

        private void FotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog w = new OpenFileDialog();
            w.Filter = "Arquivos Jpg|*.jpg";
            if (w.ShowDialog().Value)
            {
                byte[] b = File.ReadAllBytes(w.FileName);
                foto = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                image.Source = bi;
            }
        }

        private void btnCancelarF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
