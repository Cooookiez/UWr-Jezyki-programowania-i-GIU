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

namespace lista_04_zad_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double R, G, B;
        bool ColorByMouse = true;
        bool RectangleMode = true;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.R = Int32.Parse(inp_red.Text);
                this.G = Int32.Parse(inp_red.Text);
                this.B = Int32.Parse(inp_red.Text);
            }
            catch (Exception e) { }

            RectangleOrElipse();
            handleButtons();
            changeColor();
        }

        public void handleButtons()
        {
            if (this.ColorByMouse)
            {
                inp_red.IsEnabled = false;
                inp_green.IsEnabled = false;
            }
            else
            {
                inp_red.IsEnabled = true;
                inp_green.IsEnabled = true;
            }
        }

        public void RectangleOrElipse()
        {
            if (this.RectangleMode)
            {
                rec.Opacity = 1.0;
                ell.Opacity = 0.0;
            }
            else
            {
                rec.Opacity = 0.0;
                ell.Opacity = 1.0;
            }
        }

        public void changeColor(Point mPiont = new Point())
        {
            double r = 0.0;
            double g = 0.0;
            double b = 0.0;

            // get value from mosue and put int ti inputs
            if (ColorByMouse && mPiont != new Point())
            {
                Size size = grid_main.RenderSize;
                double gh = grid_main.Height;

                r = (mPiont.X / size.Width) * 255;
                g = (mPiont.Y / size.Height) * 255;
                r = Math.Round(r, 2);
                g = Math.Round(g, 2);
                inp_red.Text = r.ToString();
                inp_green.Text = g.ToString();
            }

            // get values from inputs to r, g, b
            try
            {
                r = double.Parse(inp_red.Text);
                g = double.Parse(inp_green.Text);
                b = double.Parse(inp_blue.Text);
            }
            catch (Exception e) { }

            // values must be between 0 and 255
            r = r > 255 ? 255 : r;
            r = r < 0 ? 0 : r;

            g = g > 255 ? 255 : g;
            g = g < 0 ? 0 : g;

            b = b > 255 ? 255 : b;
            b = b < 0 ? 0 : b;

            byte br = Convert.ToByte(r);
            byte bg = Convert.ToByte(g);
            byte bb = Convert.ToByte(b);
            byte[] btgb = { br, bg, bb };

            SolidColorBrush colorFill = new SolidColorBrush(Color.FromRgb(br, bg, bb));
            rec.Fill = colorFill;
            ell.Fill = colorFill;
                
            UpdateLayout();

            string sr, sg, sb, ret = "";
            sr = String.Format("{0, 3}", br);
            sg = String.Format("{0, 3}", bg);
            sb = String.Format("{0, 3}", bb);
            ret += $"{sr}, {sg}, {sb}";

            sr = String.Format("{0, 6}", BitConverter.ToString(btgb).Replace("-", ""));
            ret += $" / #{sr}";

            sr = String.Format("{0, 7}", Math.Round((double)br / 255 * 100, 2) + "%");
            sg = String.Format("{0, 7}", Math.Round((double)bg / 255 * 100, 2) + "%");
            sb = String.Format("{0, 7}", Math.Round((double)bb / 255 * 100, 2) + "%");
            ret += $" / {sr}, {sg}, {sb}";

            lbl_rgb_values.Content = ret;
        }

        private void inp_red_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.R = Int32.Parse(inp_red.Text);
            } catch (Exception ex) { }
            changeColor();
        }

        private void inp_green_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.G = Int32.Parse(inp_red.Text);
            }
            catch (Exception ex) { }
            changeColor();
        }

        private void inp_blue_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.B = Int32.Parse(inp_red.Text);

            }
            catch (Exception ex) { }
            changeColor();
        }

        private void btn_kwadraturaKola_Click(object sender, RoutedEventArgs e)
        {
            this.RectangleMode = this.RectangleMode ? false : true;
            RectangleOrElipse();
        }

        private void btn_mode_Click(object sender, RoutedEventArgs e)
        {
            this.ColorByMouse = this.ColorByMouse ? false : true;
            handleButtons();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mPiont = e.GetPosition(grid_main);

            // heights and widths
            double gh = grid_main.Height;
            double gw = grid_main.Width;
            double rh = rec.Height;
            double eh = ell.Height;

            // points
            Point newRec = new Point(mPiont.X - rh / 2, mPiont.Y - rh / 2);
            Point newEll = new Point(mPiont.X - eh / 2, mPiont.Y - eh / 2);

            // margins
            rec.Margin = new Thickness(newRec.X, newEll.Y, 0, 0);
            ell.Margin = new Thickness(newEll.X, newEll.Y, 0, 0);

            if (ColorByMouse) changeColor(mPiont);

        }
    }
}
