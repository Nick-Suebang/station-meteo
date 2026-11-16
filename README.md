[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/acbfFqK6)

# Station météo

Application C# qui lit cinq capteurs (température, humidité, direction et vitesse du vent, pression)
et trace les dix dernières mesures de chacun. Les mesures viennent soit du fichier `donnees.csv`,
soit de capteurs aléatoires.

## Deux versions

- **Windows Forms** (racine du dépôt) : la version d'origine, à ouvrir avec `station-meteo.sln`.
- **Web** (dossier `web/`) : la même logique, exécutée dans le navigateur avec Blazor WebAssembly.
  Les classes `StationMeteo`, `SerieTemporelle`, `CapteurCsv`, `CapteurRandom`, `DonneesCsv`
  et les interfaces sont compilées directement depuis la racine, sans copie. Seuls l'affichage
  (`Form1` → `Pages/Home.razor`), les graphiques (`ZedGraphique` → `GraphiqueSvg`)
  et le minuteur (`MinuteurWinForms` → `MinuteurWeb`) ont été réécrits.

## Lancer la version web en local

Il faut le SDK .NET 10.

```bash
dotnet run --project web/StationMeteoWeb.csproj
```

Puis ouvrir http://localhost:5275.

## Mise en ligne

Le workflow `.github/workflows/publier-web.yml` publie la version web sur GitHub Pages à chaque
push sur `main` (dans le dépôt : Settings > Pages > Source = GitHub Actions).
