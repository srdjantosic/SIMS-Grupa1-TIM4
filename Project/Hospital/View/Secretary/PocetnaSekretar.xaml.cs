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


namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class PocetnaSekretar : Window
    {
        public PocetnaSekretar()
        {
            InitializeComponent();
            Prozor.Content = new PocetnaPage();
        }

        private void pacijenti(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new PacijentiPage();
        }

        private void raspored(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new RasporedPage();
        }

        private void odjaviSe(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void WrapPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Down:
                    this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                    break;
                case Key.Up:
                    this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
                    break;
                default:
                    break;
            }
        }

        private void oprema(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new OpremaPage();
        }

        private void hitanSlucaj(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new HitanSlucaj();
        }

        private void zahtevi(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new ZahteviZaSlobodneDanePage();
        }

        private void sastanci(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new ZakazivanjeSastanka();
        }

        private void pocetna(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new PocetnaPage();
        }

        private void Menu_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Menu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tbPacijenti.Focus();
        }
    }
}
