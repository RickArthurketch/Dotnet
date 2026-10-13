using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Services
{
    public partial class Form1 : Form
    {
        const String sKey1 = "";

        const String sEndPoint = "https://tpvision.cognitiveservices.azure.com/";
        const String sApiKeyYS_SandBox = "";

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

        private void button_Charger_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Environment.CurrentDirectory;
            op.Filter = "Fichier PDF|*.pdf";

            if (op.ShowDialog() == DialogResult.OK)
            {
                lb2.Text = op.FileName;
            }
        }

        private async void button_Signature_Click(object sender, EventArgs e)
        {
            String sUrl = "https://api-sandbox.yousign.app/v3/signature_requests";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sApiKeyYS_SandBox);

            var requestContest = new
            {
                name = "Signature Document",
                delivery_mode = "email",
                timezone = "Europe/Paris"
            };

            var json = JsonConvert.SerializeObject(requestContest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // --- ÉTAPE 1 : Création de la demande (Votre code actuel) ---
                HttpResponseMessage response = await client.PostAsync(sUrl, content);
                response.EnsureSuccessStatusCode();

                String responseContent = await response.Content.ReadAsStringAsync();

                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                string idSignature = jsonResponse.id;
                tB2.Text = JsonConvert.SerializeObject(jsonResponse, Formatting.Indented);

                // --- ÉTAPE 2 : Envoi du document  ---
                string urlEtape2 = $"https://api-sandbox.yousign.app/v3/signature_requests/{idSignature}/documents";

                var fileStreamContent = new StreamContent(File.OpenRead(lb2.Text));

                fileStreamContent.Headers.Add("Content-Disposition", new string(Encoding.UTF8.GetBytes("form-data; name=\"file\"; filename=\"DocumentTP.pdf\"").Select(b => (char)b).ToArray()));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(fileStreamContent);
                multipartContent.Add(new StringContent("signable_document"), "nature");

                HttpResponseMessage response2 = await client.PostAsync(urlEtape2, multipartContent);
                response2.EnsureSuccessStatusCode();

                string responseContent2 = await response2.Content.ReadAsStringAsync();
                dynamic jsonResponse2 = JsonConvert.DeserializeObject(responseContent2);

                tB2.Text += Environment.NewLine + Environment.NewLine + "--- Envoi du document ---" + JsonConvert.SerializeObject(jsonResponse2, Formatting.Indented);
                string idDocument = jsonResponse2.id;

                // --- ÉTAPE 3: Ajouter le destinataire  ---
                string urlEtape3 = $"https://api-sandbox.yousign.app/v3/signature_requests/{idSignature}/signers";

                var signerDonnees = new
                {
                    info = new
                    {
                        first_name = "Rick Arthur",
                        last_name = "KETCHANDJI",
                        email = mail.Text, 
                        locale = "fr"
                    },
                    fields = new[]
                    {
                        new
                        {
                            type = "signature",
                            document_id = idDocument,
                            page = 22, 
                            x = 240,
                            y = 700, 
                            width = 120,
                            height = 40
                        }
                    },
                    signature_level = "electronic_signature",
                    signature_authentication_mode = "no_otp"
                };

                var jsonSigner = JsonConvert.SerializeObject(signerDonnees);
                var contentSigner = new StringContent(jsonSigner, Encoding.UTF8, "application/json");

                HttpResponseMessage response3 = await client.PostAsync(urlEtape3, contentSigner);
                if (!response3.IsSuccessStatusCode)
                {
                    string errorAPI = await response3.Content.ReadAsStringAsync();
                    MessageBox.Show("Erreur détaillée de YouSign : " + errorAPI);
                    return; // On arrête la méthode
                }
                response3.EnsureSuccessStatusCode();

                string responseContent3 = await response3.Content.ReadAsStringAsync();
                dynamic jsonResponse3 = JsonConvert.DeserializeObject(responseContent3);

                tB2.Text += Environment.NewLine + Environment.NewLine + "--- Ajouter le destinataire ---" + Environment.NewLine + JsonConvert.SerializeObject(jsonResponse3, Formatting.Indented);

                // --- ÉTAPE 4 : Activation de la demande de signature ---
                string urlEtape4 = $"https://api-sandbox.yousign.app/v3/signature_requests/{idSignature}/activate";

                
                HttpResponseMessage response4 = await client.PostAsync(urlEtape4, null);

                // Vérification des erreurs
                if (!response4.IsSuccessStatusCode)
                {
                    string errorAPI = await response4.Content.ReadAsStringAsync();
                    MessageBox.Show("Erreur lors de l'activation : " + errorAPI);
                    return;
                }

                string responseContent4 = await response4.Content.ReadAsStringAsync();
                dynamic jsonResponse4 = JsonConvert.DeserializeObject(responseContent4);

                // Affichage du résultat final
                tB2.Text += Environment.NewLine + Environment.NewLine + "--- Activation de la demande de signature ---" + Environment.NewLine + JsonConvert.SerializeObject(jsonResponse4, Formatting.Indented);

                MessageBox.Show("La demande de signature a été envoyée avec succès !");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erreur de requête HTTP : " + ex.Message);
                return;
            }
        }
    }
}
