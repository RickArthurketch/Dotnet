# TP.Net N°3 : Web Services - Utilisation d'API externes

Ce projet est une application C# Windows Forms développée dans le cadre du TP de Technologie .Net. Il a pour objectif de démontrer l'intégration et l'utilisation de services web et d'APIs externes au sein d'une application de bureau.

## 🚀 Fonctionnalités

L'application est divisée en deux onglets principaux :

### 1. Analyse d'image par IA (Microsoft Azure)
* Chargement d'une image locale (formats JPEG/PNG) via un explorateur de fichiers.
* Utilisation du service **Azure AI Vision** pour analyser l'image.
* Extraction et affichage des informations suivantes :
  * Description générée par l'IA (en anglais, neutre en genre).
  * Indice de confiance de l'analyse.
  * Détection et comptage des personnes présentes sur l'image.
  * Détection et comptage des objets.
  * Coordonnées (boîtes englobantes) des éléments détectés.

### 2. Signature numérique (YouSign)
* Sélection d'un document PDF local.
* Saisie de l'adresse email d'un destinataire.
* Utilisation de l'API **YouSign (SandBox)** pour :
  * Initier une demande de signature.
  * Téléverser le document PDF sécurisé.
  * Ajouter le destinataire (Signer).
  * Activer et envoyer la demande de signature par email.

## 🛠️ Technologies et Dépendances

* **Langage :** C#
* **Framework :** .NET Framework (Windows Forms)
* **Packages NuGet requis :**
  * `Azure.AI.Vision.ImageAnalysis` (version préliminaire / beta) - Pour l'API Microsoft.
  * `Newtonsoft.Json` - Pour la manipulation, la sérialisation et la désérialisation des requêtes/réponses JSON de l'API YouSign.

## ⚙️ Installation et Configuration
