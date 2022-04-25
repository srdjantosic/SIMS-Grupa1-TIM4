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
using Project.Hospital.View.Secretary;
using Project.Hospital.View.Manager;
namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void prijaviSe(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }
        private void inmanager(object sender, RoutedEventArgs e)
        {
            var pocetna= new Pocetna();
            pocetna.Show();
            this.Close();
        }
    }
}
