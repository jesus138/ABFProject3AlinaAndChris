# ABF Projekt 3

Dieses Projekt stellt ein Gruppenprojekt im Rahmen des Wintersemesters 2019/2020 dar. Es wurde ein Spiel mit Audioengineering in Unity 3D erstellt mit 5.1 Surroundsound.

## Inhaltsverzeichnis
1. Verzeichnisstruktur
2. Bedienung
3. Aufgabenerläuterungen
4. Externe Ressourcen

## Verzeichnisstruktur
- bin: fertige Programme
    - winx64: Windows x86_64
    - winx86: Windows x86
- src: Quellcode
    - unity01: Das Projekt
    - diff: Geänderte Asset-Store Scripts

## Bedienung
Zum starten bitte unter Windows einen entsprechenden Windows build verwenden. Dazu architekturspezifisch für x64 oder x86 ABFProject3.exe ausführen.\
Auflösung auswählen, bspw. 1600:900 oder 1920:1080 und am besten "Windowed" ankreuzen, um es einfacher wieder zu schließen.\
Der Spieler wird mit den Tasten **W A S D** bewegt. Bei gedrückthalten von **STRG** rennt der Spieler. Mit **C** kann geduckt werden und mit **Leertaste** wird gesprungen.

## Aufgabenerläuterungen
Nun soll das Projekt kurz anhand der Aufgaben erläutert werden.

### a. Schrittgeräusche
Zur Realisierung unterschiedlicher Geräusche auf unterschiedlichem Boden wurden folgende Skripte programmiert:
- ABFEvents.cs
- ChrisScript.cs
- GroundEvent.cs
- ABFUI.cs

Prinzipiell werden versteckte Kollisionsobjekte über die Texturen im Terrain gelegt, wodurch festgestellt werden kann, wann der Spieler über welche Textur läuft. Die Schrittgeräusche werden entsprechend angepasst.\
Unten rechts im Bildschirm wird der aktuell aktive Bodentyp angezeigt.\
Beim Rennen/Sprinten des Spielers wird in ChrisScript.cs dynamisch die "Pitch" erhöht, sodass ein Unterschied zum normalen Laufen hörbar wird.\
Beim Springen gibt es zudem ein Landegeräusch, welches jedoch den Bodentyp nicht berücksichtigt. Dies könnte ähnlich wie die Schrittgeräusche realisiert werden.

### b. Ambiente-Sound
Es gibt drei Hauptbereiche im Terrain:
- Wasser + Sand
- Natur
- Stadt

Es wurde ein AudioMixer verwendet zu dessen vier Gruppen die Soundquellen geroutet werden. Diese sind als Untergruppen des Masters:
- Water
- Nature
- City
- Player
- Air

### c. Bewegende Objekte

### d. Sonstiges

### e. Sound-Verdeckung

## Externe Ressourcen

### Soundquellen
Die verwendeten Sounds befinden sich im Ordner Assets/Sounds und stammen alle von freesound.org.

### Unity Asset Store
Es wurden mehrere externe Asset Pakete aus dem Standard-Asset Store verwendet.

Folgende Skripte wurden aus *Unity Standard Assets* angepasst und müssen aus dem *src/diff* Ordner entsprechend herauskopiert werden und die Standards ersetzen: