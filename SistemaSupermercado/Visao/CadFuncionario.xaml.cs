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
            try {
                Funcionario f = new Funcionario();
                if (btnCaixa.IsChecked == true) f = new OperadorDeCaixa();
                else if (btnGerente.IsChecked == true) f = new Gerente();
                f.Nome = fNome.Text;
                f.Email = fEmail.Text;
                f.Telefone = fTelefone.Text;
                f.Cpf = fCpf.Text;
                f.NumeroConta = fNConta.Text;
                f.Formacao = fFormacao.Text;
                f.DataIngresso = DateTime.Now;
                f.Foto = foto;
                f.Login = fLogin.Text;
                NCriptografia crp = new NCriptografia();
                if (fSenha.Password == fConfSenha.Password) f.Senha = crp.Criptografar(fSenha.Password);
                else throw new ArgumentException();
                NFuncionario nF = new NFuncionario();
                nF.Insert(f);
                this.Close();
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            catch (ArgumentException)
            {
                fSenha.Clear();
                fConfSenha.Clear();
                MessageBox.Show("As senhas não correspondem");
            }

        }
        private void AddIdGerente()
        {
          
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

        private void BtnCaixa_Checked(object sender, RoutedEventArgs e)
        {
            if (btnCaixa.IsChecked == true) stackIdGerente.Visibility = Visibility.Visible;
           
        }

        private void btnGerente_Uncec(object sender, RoutedEventArgs e)
        {
            if (btnCaixa.IsChecked == false) stackIdGerente.Visibility = Visibility.Hidden;
        }
    }
}
