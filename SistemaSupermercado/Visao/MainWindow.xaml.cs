﻿using System;
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
            TelaAdm adm = new TelaAdm();
            this.Close();
            adm.ShowDialog();
        }

        private void EntrarGerente(object sender, RoutedEventArgs e)
        {
            TelaGerente gerente = new TelaGerente();
            this.Close();
            gerente.ShowDialog();
        }

        private void EntrarCaixa(object sender, RoutedEventArgs e)
        {
            CadastrarVendas cv = new CadastrarVendas();
            this.Close();
            cv.ShowDialog();
        }
    }
}
