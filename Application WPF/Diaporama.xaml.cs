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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Application_WPF
{
    /// <summary>
    /// Logique d'interaction pour Diaporama.xaml
    /// </summary>
    public partial class Diaporama : Window
    {
        public List<String> sDiapo = new List<string>();
        public int indexImage = 1;
        public Diaporama()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (sDiapo != null && sDiapo.Count > 0)
            {
                ImageSourceConverter s = new ImageSourceConverter();
                Image1.Source = (ImageSource)s.ConvertFromString(sDiapo[0]);
                if (sDiapo.Count > 1)
                {
                    Image2.Source = (ImageSource)s.ConvertFromString(sDiapo[1]);
                    indexImage = 2; 
                }
                else
                {
                    indexImage = 0;
                }
            }
        }
        private void VisibleToInvisible_Completed(object sender, EventArgs e)
        {
            if (sDiapo != null && sDiapo.Count > 0)
            {
                ImageSourceConverter s = new ImageSourceConverter();

                if (indexImage >= sDiapo.Count) indexImage = 0;

                Image1.Source = (ImageSource)s.ConvertFromString(sDiapo[indexImage]);
                indexImage++;

                Storyboard sb = (Storyboard)this.FindResource("InvisibleToVisible");
                sb.Begin();
            }
        }

        private void InVisibleToVisible_Completed(object sender, EventArgs e)
        {
            if (sDiapo != null && sDiapo.Count > 0)
            {
                ImageSourceConverter s = new ImageSourceConverter();

                if (indexImage >= sDiapo.Count) indexImage = 0;

                Image2.Source = (ImageSource)s.ConvertFromString(sDiapo[indexImage]);
                indexImage++;

                Storyboard sb = (Storyboard)this.FindResource("VisibleToInvisible");
                sb.Begin();
            }
        }
    }

}
