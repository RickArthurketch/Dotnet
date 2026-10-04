using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure;
using Azure.AI.Vision.ImageAnalysis;

namespace Web_Services
{
    public partial class Form1 : Form
    {
        const String sKey1 = "";
        const String sEndPoint = "https://tpvision.cognitiveservices.azure.com/";

        public Form1()
        {
            InitializeComponent();
        }


        /*  1er version
         * private void btAnalyse_Click(object sender, EventArgs e)
        {

            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(sEndPoint), new AzureKeyCredential(sKey1));
            ImageAnalysisResult imr =  client.Analyze(new Uri("https://learn.microsoft.com/azure/ai-services/computer-vision/media/quickstarts/presentation.png"),
                VisualFeatures.Caption | VisualFeatures.Read, new ImageAnalysisOptions { GenderNeutralCaption = true });

            tb.Text = imr.Caption.Text;
        }
        */
        private void btAnalyse_Click(object sender, EventArgs e)
        {

            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(sEndPoint), new AzureKeyCredential(sKey1));
            FileStream fs = new FileStream(lb.Text, FileMode.Open, FileAccess.Read);
            BinaryData bData = BinaryData.FromStream(fs);

            ImageAnalysisOptions option = new ImageAnalysisOptions{ GenderNeutralCaption = true, Language = "en" };
            VisualFeatures features = VisualFeatures.Caption | VisualFeatures.DenseCaptions | 
                VisualFeatures.Objects | VisualFeatures.Read | VisualFeatures.People;

            ImageAnalysisResult img = client.Analyze(bData, features, option);

            string Resultat = img.Caption.Text + Environment.NewLine;
            Resultat += "Indice de confiance : " + img.Caption.Confidence.ToString() + Environment.NewLine;

            int nbPersonnes = img.People != null ? img.People.Values.Count : 0;
            Resultat += "Nombre de personnes : " + nbPersonnes + Environment.NewLine;

            int nbObjets = img.Objects != null ? img.Objects.Values.Count : 0;
            Resultat += "Nombre d'objets détectés : " + nbObjets + Environment.NewLine;

            if (nbPersonnes > 0)
            {
                var p = img.People.Values[0].BoundingBox;
                Resultat += $"Personne 1 Top : {p.Y}, Left : {p.X}, Width : {p.Width}, Height : {p.Height}" + Environment.NewLine;
            }

            if (nbObjets > 0)
            {
                var o = img.Objects.Values[0].BoundingBox;
                Resultat += $"objet 1 Top : {o.Y}, Left : {o.X}, Width : {o.Width}, Height : {o.Height}" + Environment.NewLine;
            }

            tb.Text = Resultat;
        }

        private void btCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.InitialDirectory = Environment.CurrentDirectory;
            opFile.Filter = "Images JPEG|*.jpg|Images JPEG|*.jpg";
            opFile.FilterIndex = 1;

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(opFile.FileName, FileMode.Open, FileAccess.Read);
                if (pBox.Image != null)
                {
                    pBox.Image.Dispose();
                }

                pBox.Image = System.Drawing.Image.FromStream(fs);
                lb.Text = opFile.FileName;
            }
        }
    }
}
