﻿using System;
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
        Person person = new Person();
        Person player = new Person();

        public string Instructions = "Instructions\nClick the Progress Time button to progress to the next day\nIn the shop type in the Text Block if you have enough cash then you can buy it\nYou can sell Guano to earn cash\nYour Goal is to keep the system alive as long as possible";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //TXB_WhatHappenedBox.Text = cave.Creatures.Count.ToString();
            TXB_Instructions.Text = Instructions;
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            person.SetUpShop();
            TXB_Shop.Text = person.ShowShop();
            LBL_Day.DataContext = $"Day: {cave.Day}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cave.ProgressDay();
            LBL_Day.DataContext = $"Day: {cave.Day}";
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            Debug.WriteLine(Cave.GetFoodLevels(cave.Creatures));
        }



        private void BTN_ADD_Click(object sender, RoutedEventArgs e)
        {
            string input = TBL_Shop.Text;
            TBL_Shop.Text = "";


        }

        private void BTN_Sell_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
