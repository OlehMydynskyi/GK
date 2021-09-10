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

namespace GC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float currentDamage;
        public MainWindow()
        {
            InitializeComponent();
            BaseDamage();
            PressButton.Click += ButtonClick;
            HoldButton.Click += ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            BaseDamage();
            bool isPress = (string)((Button)e.OriginalSource).Content == "Press" ? true : false;
            currentDamage += (800 * SameElem(BaseDamageField.Text) * SameElem(AnotherDamageField.Text, isPress ? PunctureDamageField.Text : SlashDamageField.Text) * (SameElem(PowerField.Text) - 1) + 800 * (SameElem(PowerField.Text) - 1)) / 2;
            GlassCounter.Content = Math.Round(currentDamage);
        }

        private void BaseDamage()
        {
            currentDamage = 250 * (float.Parse(PowerField.Text) / 100);
            GlassCounter.Content = currentDamage;
        }

        private float SameElem(string FieldText)
        {
            return 1 + float.Parse(FieldText) / 100;
        }

        private float SameElem(string FieldText1, string FieldText2)
        {
            return 1 + (float.Parse(FieldText1) + float.Parse(FieldText2)) / 100;
        }
    }
}
