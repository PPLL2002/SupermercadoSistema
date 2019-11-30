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
using Visao;

namespace Visao
{
    /// <summary>
    /// Lógica interna para AtualizarFuncionario.xaml
    /// </summary>
    public partial class AtualizarFuncionario : Window
    {
        string foto = string.Empty;
        Funcionario funcio;
        public AtualizarFuncionario(Funcionario f)
        {
            InitializeComponent();
            fNome.Text = f.Nome;
            fEmail.Text = f.Email;
            fCpf.Text = f.Cpf;
            fTelefone.Text = f.Telefone;
            fFormacao.Text = f.Formacao;
            fNConta.Text = f.NumeroConta;

            byte[] b = Convert.FromBase64String(f.Foto);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(b);
            bi.EndInit();

            image.Source = bi;

            funcio = f;
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

                funcio.Foto = foto;
            }
        }

        private void btnCancelarF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAtualizarF(object sender, RoutedEventArgs e)
        {
            NFuncionario nf = new NFuncionario();
            funcio.Nome = fNome.Text;
            funcio.Email = fEmail.Text;
            funcio.Telefone = fTelefone.Text;
            funcio.Cpf = fCpf.Text;
            funcio.NumeroConta = fNConta.Text;
            funcio.Formacao = fFormacao.Text;
            funcio.DataIngresso = DateTime.Now;
            
            nf.Update(funcio);
            this.Close();
        }
    }
}
