using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DungeonCrawlBot.Controls
{
    public class BorderGrid : Grid, INotifyPropertyChanged
    {
        public int CornerRadius
        {
            get
            {
                return (int)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public Brush BorderBackground
        {
            get
            {
                return (Brush)GetValue(BorderBackgroundProperty);
            }
            set
            {
                SetValue(BorderBackgroundProperty, value);
            }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(int), typeof(BorderGrid), new PropertyMetadata(0, OnCornerRaiusPropertyChanged));

        public static readonly DependencyProperty BorderBackgroundProperty = DependencyProperty.Register("BorderBackground", typeof(Brush), typeof(BorderGrid), new PropertyMetadata(new SolidColorBrush(Colors.White), OnBorderBackgroundPropertyChanged));

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void OnBorderBackgroundPropertyChanged(DependencyObject dependecyObj, DependencyPropertyChangedEventArgs e)
        {
            var borderGrid = dependecyObj as BorderGrid;
            borderGrid.OnPropertyChanged("BorderGrid");
        }

        private static void OnCornerRaiusPropertyChanged(DependencyObject dependecyObj, DependencyPropertyChangedEventArgs e)
        {
            var borderGrid = dependecyObj as BorderGrid;
            borderGrid.OnPropertyChanged("CornerRadius");
        }

        protected override void OnRender(DrawingContext dc)
        {
            var offX = 0;
            var offY = 0;
            var width = ActualWidth;
            var height = ActualHeight;

            var brush = BorderBackground;
            var pen = new Pen(brush, 1);
            pen.Freeze();
            var rect = new Rect(offX, offY, width, height);

            dc.DrawRoundedRectangle(brush, pen, rect, CornerRadius, CornerRadius);
            base.OnRender(dc);
        }
    }
}
