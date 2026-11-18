[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/acbfFqK6)

# Station météo

Application C# qui lit cinq capteurs (température, humidité, direction et vitesse du vent, pression)
et trace les dix dernières mesures de chacun. Les mesures viennent soit du fichier `donnees.csv`
(relevés horaires de janvier à mars 2024), soit de capteurs aléatoires.

**Essayer en ligne :** https://nick-suebang.github.io/station-meteo/

## Organisation

| Dossier | Contenu |
| --- | --- |
| racine | Logique de la station et version **Windows Forms** (.NET Framework 4.7.2, ZedGraph) |
| `web/` | Version **Blazor WebAssembly** qui s'exécute dans le navigateur |
| `tests/` | Tests unitaires xUnit de la logique |

La logique (`StationMeteo`, `SerieTemporelle`, `CapteurCsv`, `CapteurRandom`, `DonneesCsv`,
`DefinitionCapteur` et les interfaces) ne dépend d'aucune interface graphique. Les projets web et
de tests compilent ces fichiers directement depuis la racine, sans copie. Seuls l'affichage
(`FenetrePrincipale` → `Pages/Home.razor`), les graphiques (`ZedGraphique` → `GraphiqueSvg`)
et le minuteur (`MinuteurWinForms` → `MinuteurWeb`) existent en deux versions.

## Conception

- **Stratégie** : `ICapteur`, avec `CapteurCsv` (relevés) et `CapteurRandom` (simulation) interchangeables.
- **Adaptateur** : `ZedGraphique`, `GraphiqueSvg`, `MinuteurWinForms` et `MinuteurWeb` adaptent
  des composants de chaque plateforme aux interfaces `IGraphique` et `IMinuteur`.
- **Observateur** : `StationMeteo` réagit à l'événement `Tick` du minuteur.
- **Injection de dépendances** : `StationMeteo` reçoit son minuteur, sa fabrique de séries et son
  horloge, ce qui permet de la tester sans minuteur ni heure réelle.

## Commandes

Il faut le SDK .NET 10 (et Windows pour la version Windows Forms).

```bash
dotnet run --project station-meteo.csproj
```

```bash
dotnet run --project web/StationMeteoWeb.csproj
```

```bash
dotnet test tests/StationMeteo.Tests
```

La version web est ensuite disponible sur http://localhost:5275.

## Mise en ligne

Le workflow `.github/workflows/publier-web.yml` lance les tests, puis publie la version web sur
GitHub Pages à chaque push sur `main`.

## Auteur et contact

**Nick Suebang** (Nick Hariel Teponno Suebang), technicien en informatique et développeur web et mobile à Rimouski (QC).

- Portfolio : [nicksuebang.com](https://nicksuebang.com)
- Courriel : [contact@nicksuebang.com](mailto:contact@nicksuebang.com)
- GitHub : [@Nick-Suebang](https://github.com/Nick-Suebang)
- LinkedIn : [Nick Hariel Teponno Suebang](https://www.linkedin.com/in/nick-hariel-teponno-suebang-6a8875292/)
