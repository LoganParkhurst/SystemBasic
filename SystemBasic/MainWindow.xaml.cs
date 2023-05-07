using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// 
    // Logan Parkhurst
    // 4/25/2023
    public partial class MainWindow : Window
    {
        Cave cave = new Cave();
        Person person = new Person();
        Person player = new Person();

        public delegate void Del(string message);
        public static void DebugMessages(string message)
        {
            Debug.WriteLine(message);
        }
        Del handler = DebugMessages;

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
            RCT_StatusBox.DataContext = "#FFF000";
            TXB_Shop.Text = person.ShowShop();
            LBL_Day.DataContext = $"Day: {cave.Day}";
            LBL_Cash.DataContext = $"Cash: {player.Coin.ToString("C2", CultureInfo.CurrentCulture)}";
            LBL_GuanoCount.DataContext = $"Guano: {Guano.Guano_Instance.Amount}";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cave.ProgressDay();
            LBL_Day.DataContext = $"Day: {cave.Day}";
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            if (cave.Creatures.Find(x => x.Name == "Brazilian free-tailed bat").Amount >= 101)
                RCT_StatusBox.DataContext = "#FF219628";
            else if (cave.Creatures.Find(x => x.Name == "Brazilian free-tailed bat").Amount <= 100 && cave.Creatures.Find(x => x.Name == "Brazilian free-tailed bat").Amount > 0)
                RCT_StatusBox.DataContext = "#FFF000";
            else
                RCT_StatusBox.DataContext = "#FFFF0000";

            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            LBL_GuanoCount.DataContext = $"Guano: {Guano.Guano_Instance.Amount}";
            handler($"{Cave.GetFoodLevels(cave.Creatures)}");
        }
        private void BTN_ADD_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("BTN_ADD_Click Clicked");
            string input = TBL_Shop.Text;
            TBL_Shop.Text = "";
            person.BuyItem(input, cave.Creatures, player);
            TXB_Population.Text = Cave.GetPopulation(cave.Creatures);
            TXB_FoodStorage.Text = Cave.GetFoodLevels(cave.Creatures);
            LBL_Cash.DataContext = $"Cash: {player.Coin.ToString("C2", CultureInfo.CurrentCulture)}";
        }
        private void BTN_Sell_Click(object sender, RoutedEventArgs e)
        {
            if(Guano.Guano_Instance.Amount > 0)
            {
                player.Coin += person.Sell();
            }
            LBL_Cash.DataContext = $"Cash: {player.Coin.ToString("C2", CultureInfo.CurrentCulture)}";
            LBL_GuanoCount.DataContext = $"Guano: {Guano.Guano_Instance.Amount}";
        }
    }
}
