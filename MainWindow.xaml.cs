﻿global using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwordDamage;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Random random = new Random();
    SwordDamage swordDamage = new SwordDamage();

    public MainWindow()
    {
        InitializeComponent();
        swordDamage.SetMagic(false);
        swordDamage.SetFlaming(false);
        RollDice();
    }

    public void RollDice()
    {
        swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        swordDamage.SetFlaming(flaming.IsChecked.Value);
        swordDamage.SetMagic(magic.IsChecked.Value);
        DisplayDamage();

        DisplayDamage();
    }
    void DisplayDamage()
    {
        damage.Text = "Rolled " + swordDamage.Roll + " for " + swordDamage.Damage + " HP";
    }
    private void flaming_Checked(object sender, RoutedEventArgs e)
    {
        swordDamage.SetFlaming(true);
            DisplayDamage();
    }

    private void flaming_Unchecked(object sender, RoutedEventArgs e)
    {
        swordDamage.SetFlaming(false);
        DisplayDamage();
    }

    private void magic_Checked(object sender, RoutedEventArgs e)
    {
        swordDamage.SetMagic(true);
        DisplayDamage();
    }

    private void magic_Unchecked(object sender, RoutedEventArgs e)
    {
        swordDamage.SetMagic(false);
        DisplayDamage();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RollDice();
    }

    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FLAME_DAMAGE;
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }
            CalculateDamage();
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }

        }


    }

}