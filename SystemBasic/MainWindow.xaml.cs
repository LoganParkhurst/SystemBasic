using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SystemBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cave cave = new Cave();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //TXB_WhatHappenedBox.Text = cave.Creatures.Count.ToString();
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            LBL_Day.DataContext = $"Day: {cave.Day}";
            TXB_NameBox.DataContext = cave;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cave.ProgressDay();
            LBL_Day.DataContext = $"Day: {cave.Day}";
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            Debug.WriteLine(Cave.GetFoodLevels(cave.Creatures));
        }
    }
}
