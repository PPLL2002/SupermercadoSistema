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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Negocio;

namespace Visao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EntrarDono(object sender, RoutedEventArgs e)
        {
            bool logou = false;
            do
            {
                LoginWindow w = new LoginWindow();
                if (w.ShowDialog().Value)
                {
                    Login l = new Login();
                    logou = l.VerificarSenha(w.Usuario, w.Senha, 0);
                    if (logou)
                    {
                        
                        TelaAdm adm = new TelaAdm();
                        this.Close();
                        adm.Show();
                    }
                    if (!logou) { MessageBox.Show("Usuário ou senha inválidos"); }
                }
                else break;
            } while (!logou);
        }

        private void EntrarGerente(object sender, RoutedEventArgs e)
        {
            bool logou = false;
            do
            {
                LoginWindow w = new LoginWindow();
                if (w.ShowDialog().Value)
                {
                    Login l = new Login();
                    logou = l.VerificarSenha(w.Usuario, w.Senha, 1);
                    if (logou)
                    {
                        TelaGerente gerente = new TelaGerente();
                        this.Close();
                        gerente.ShowDialog();
                    }
                    if (!logou) { MessageBox.Show("Usuário ou senha inválidos"); }
                }
                else break;
            } while (!logou);
        }

        private void EntrarCaixa(object sender, RoutedEventArgs e)
        {
           /* bool logou = false;
            do
            {
                LoginWindow w = new LoginWindow();
                if (w.ShowDialog().Value)
                {
                    Login l = new Login();
                    logou = l.VerificarSenha(w.Usuario, w.Senha, 2);
                    if (logou)
                    {*/
                        CadastrarVendas cv = new CadastrarVendas();
                        this.Close();
                        cv.ShowDialog();
                    /*}
                    if (!logou) { MessageBox.Show("Usuário ou senha inválidos"); }
                }
                else break;
            } while (!logou);*/
        }
    }
}
