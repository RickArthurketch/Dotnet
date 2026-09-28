# README - Projet PhotoViewer (TP.Net N° 2)

## Description
* Ce projet est une application WPF nommée « PhotoViewer »[cite: 1].
* Il a été conçu dans le cadre du TP.Net N° 2 de l'année 2026/2027 pour le cursus 3iL INGÉNIEURS[cite: 1].
* L'objectif du projet est la création d'un visualiseur de photos exploitant des classes C# et des effets d'interface sous WPF[cite: 1].

## Fonctionnalités Principales
* **Explorateur de dossiers** : L'application intègre un bouton permettant de sélectionner un répertoire contenant des images JPEG via un `FolderBrowserDialog`[cite: 1].
* **Galerie d'images** : Les fichiers récupérés sont affichés directement sous forme d'images (et non de textes) dans une `ListBox` grâce à des styles XAML personnalisés[cite: 1].
* **Extraction des Métadonnées (Exif)** : Lorsqu'une photo est sélectionnée, un panneau de propriétés affiche les données intégrées au fichier image[cite: 1].
* Ces métadonnées comprennent : le chemin source, la date de la prise de vue, le titre, le modèle de l'appareil photo, l'application d'édition, le temps d'exposition (IsoSpeed), l'ouverture et la distance focale[cite: 1].
* **Zoom dynamique** : Un contrôle `Slider` permet de redimensionner dynamiquement les miniatures affichées dans la galerie grâce au Binding WPF[cite: 1].
* **Aperçu (Tooltip)** : Le survol d'une image de la liste déclenche un `ToolTip` affichant un aperçu de l'image avec un effet de semi-transparence[cite: 1].
* **Diaporama animé** : Une fenêtre secondaire permet de lancer un diaporama continu des images chargées[cite: 1]. 
* Le diaporama utilise des scénarios XAML (`Storyboard`) et un `OpacityMask` avec des animations de fondu (`DoubleAnimation`) pour assurer une transition fluide entre les photos[cite: 1].

## Architecture du Projet
* **Fenêtre Principale (`MainWindow`)** : Composée de grilles (`Grid`), de `DockPanel`, et d'un `WrapPanel` pour gérer l'agencement et la présentation de la galerie et des propriétés[cite: 1].
* **Classe `Photo.cs`** : Classe C# dédiée à la gestion des données de chaque image, incluant une sous-classe `PhotoMetadata` pour l'extraction via `BitmapMetadata`[cite: 1].
* **Fenêtre `Diaporama`** : Gère l'affichage en plein écran ou fenêtré des transitions entre deux objets `Image`[cite: 1].

## Prérequis Techniques et Configuration
* Type de projet : C# / Application WPF (.Net Framework) sous Visual Studio[cite: 1].
* Références d'assembly ajoutées : `System.Windows.Forms` (nécessaire pour la sélection du répertoire)[cite: 1].
* Espaces de noms requis dans le code-behind : `System.Windows.Media.Imaging` (pour lire les métadonnées) et `System.Windows.Media.Animation` (pour les animations du diaporama)[cite: 1].