using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MGRMikolajczuk.Model
{
    class ComponentFabryk
    {

        public TextBlock GeneraTextBlock(string name)
        {
            return new TextBlock() {Text = name,
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap };
        }

        public Button GenerateButton(string name)
        {
            Button b = new Button();
            b.Content = "Otworz zamówienie";
            b.Tag = name;
            Style s = Application.Current.FindResource("ButtonShadow") as Style;
            b.Style = s;
            b.Height = 50;
            return b;
        }

        public Button GenerateButton(TextBlock tb)
        {
            Button b = new Button();
            b.Content = tb;
            Style s = Application.Current.FindResource("ButtonShadow") as Style;
            b.Style = s;
            b.Height = 50;
            return b;
        }



        public Border GenerateBorder(StackPanel sp)
        {
            return new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = sp
            };
        }

        public Panel GenerateGrid()
        {
            Panel panel = new Grid();
            panel.VerticalAlignment = VerticalAlignment.Center;
            panel.Margin = new Thickness(5, 5, 5, 5);
            return panel;
        }
    }
}
