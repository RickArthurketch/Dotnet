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
using System.Windows.Forms;
using System.IO;

namespace Application_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Photo ph;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Sélectionnez un répertoire d'images JPEG";

            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb.Text = dialog.SelectedPath;
                lb.Items.Clear();

                DirectoryInfo di = new DirectoryInfo(tb.Text);
                foreach (FileInfo fi in di.GetFiles("*.jpg"))
                {
                    lb.Items.Add(fi.FullName);
                }
            }
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                ph = new Photo(lb.SelectedItem.ToString());
                PanelProprietes.DataContext = ph;

            } else
            {
                PanelProprietes.DataContext = null;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Diaporama dp = new Diaporama();
            foreach (var chemin_image in lb.Items)
            {
                dp.sDiapo.Add(chemin_image.ToString());
            }

            dp.ShowDialog();
        }
    }
}
