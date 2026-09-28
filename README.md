# README - Projet PhotoViewer

## Description
* Ce projet est une application WPF nommée « PhotoViewer ».
* L'objectif du projet est la création d'un visualiseur de photos exploitant des classes C# et des effets d'interface sous WPF.

## Fonctionnalités Principales
* **Explorateur de dossiers** : L'application intègre un bouton permettant de sélectionner un répertoire contenant des images JPEG via un `FolderBrowserDialog`.
* **Galerie d'images** : Les fichiers récupérés sont affichés directement sous forme d'images (et non de textes) dans une `ListBox` grâce à des styles XAML personnalisés.
* **Extraction des Métadonnées (Exif)** : Lorsqu'une photo est sélectionnée, un panneau de propriétés affiche les données intégrées au fichier image.
* Ces métadonnées comprennent : le chemin source, la date de la prise de vue, le titre, le modèle de l'appareil photo, l'application d'édition, le temps d'exposition (IsoSpeed), l'ouverture et la distance focale.
* **Zoom dynamique** : Un contrôle `Slider` permet de redimensionner dynamiquement les miniatures affichées dans la galerie grâce au Binding WPF.
* **Aperçu (Tooltip)** : Le survol d'une image de la liste déclenche un `ToolTip` affichant un aperçu de l'image avec un effet de semi-transparence.
* **Diaporama animé** : Une fenêtre secondaire permet de lancer un diaporama continu des images chargées. 
* Le diaporama utilise des scénarios XAML (`Storyboard`) et un `OpacityMask` avec des animations de fondu (`DoubleAnimation`) pour assurer une transition fluide entre les photos.

## Architecture du Projet
* **Fenêtre Principale (`MainWindow`)** : Composée de grilles (`Grid`), de `DockPanel`, et d'un `WrapPanel` pour gérer l'agencement et la présentation de la galerie et des propriétés.
* **Classe `Photo.cs`** : Classe C# dédiée à la gestion des données de chaque image, incluant une sous-classe `PhotoMetadata` pour l'extraction via `BitmapMetadata`.
* **Fenêtre `Diaporama`** : Gère l'affichage en plein écran ou fenêtré des transitions entre deux objets `Image`.

## Prérequis Techniques et Configuration
* Type de projet : C# / Application WPF (.Net Framework) sous Visual Studio.
* Références d'assembly ajoutées : `System.Windows.Forms` (nécessaire pour la sélection du répertoire).
* Espaces de noms requis dans le code-behind : `System.Windows.Media.Imaging` (pour lire les métadonnées) et `System.Windows.Media.Animation` (pour les animations du diaporama).