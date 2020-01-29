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

In der Natur sind Geräusche für Insekten und Vogelzwitschern hinterlegt. Für das Wasser gibt es Wellenrauschen. In der Stadt gibt es bei der Ampel Verkehrsgeräusche, auf der anderen Seite Motorradgeräusche und bei der Statue eine jubelnde Menge. Die Geräusche wurden so eingestellt, dass sie logarithmisch abklingen und nur den für sie entsprechenden Bereich abdecken. Letzteres war jedoch nicht ohne weiteres möglich, weshalb ein Skript zur Soundverdeckung geschrieben wurde.

### c. Bewegende Objekte
Es wurde in *MoveWay.cs* ein Skript geschrieben, welches Objekte entlang eines markierten Pfades auf einfache kinematische Art bewegt. Dieses Skript wurde auf das blaue Auto in der Stadt und das Flugzeug über dem Terrain angewendet. Beide haben eine Audioquelle. Beim vorbeifahren bzw. -fliegen dieser Objekte am Spieler sollte die Lautstärke entsprechend größer sein und auch der Doppler-Effekt hörbar.

### d. Sonstiges
Hier nur eine Übersicht über die unterschiedlichen Soundquellen:
- Wasser: Wellengeräusch
- Player: Schrittgeräusche, Anpassung bei Rennen, Sprunggeräusch
- Natur: Insektengeräusche + Naturambiente, Vögelzwitschern
- Stadt: Motorrad, Ampelverkehr, jubelnde Menge, fahrendes Auto
- Luft/Flugzeug: Jet-Engine Geräusch

### e. Sound-Verdeckung
Um zu erreichen, dass bspw. in der Stadt keine Wellen- oder Naturgeräusche mehr zu hören sind, bzw. in der Natur und am Strand keine bzw. nur sachte Stadtgeräusche wurde ein Skript geschrieben. In *WaterMix.cs* und *CityMix.cs* wird dynamisch auf den AudioMixer zugegriffen.\
Beim Betreten der Stadt werden die Naturgeräusche sehr leise gemacht und die Wellengeräusche komplett deaktiviert. Die Stadtgeräusche werden aktiviert. Folglich hat es den Effekt als würden die Stadtgebäude und die Stadtgeräusche die Geräusche des Umlandes verdecken. Beim Verlassen der Stadt werden die Stadtgeräusche auf sehr leise gestellt, die Wassergeräusche etwas hörbar und die Naturgeräusche komplett aktiviert.\
Ähnlich verläuft es beim Betreten und Verlassen des Wasserbereiches. Dort werden die Stadtgeräusche komplett abgeschalten, Naturgeräusche etwas hörbei und die Wassergeräusche auf besonders laut. Letzteres war nötig, da die Wellengeräusche von der Soundquelle zu leise waren. Beim Verlassen des Wasserbereiches werden die Stadtgeräusche auf etwas leiser gestellt als beim Verlassen der Stadt, da bei letzteren zunächst eine Nähe mit der Stadt assoziiert werden würde.\
Für das Detektieren der Bereiche werden wieder Collider-Komponenten verwendet.

## Externe Ressourcen

### Soundquellen
Die verwendeten Sounds befinden sich im Ordner Assets/Sounds und stammen alle von freesound.org.

### Unity Asset Store
Es wurden mehrere externe Asset Pakete aus dem Standard-Asset Store verwendet.
- Unity Standard Assets (Player, Flugzeug, Bäume, Wasser)
- Unity 3D Game Kit (Verwendung in verworfenen Szenen)
- Unity Windridge City (für Stadt)
- Asphalt Materials (Asphalt Textur)
- Low Poly Road Pack (blaues Auto und Straßen)
- Dungeon Stone Textures (für Wegtextur)

Siehe Assets/*.meta Dateien für mehr Details. Einige Pakete wurden nur wegen einzelnen Texturen verwendet oder nur in der Anfangsphase des Projekts für Experimente.

Folgende Skripte wurden aus *Unity Standard Assets* angepasst und müssen aus dem *src/diff* Ordner entsprechend herauskopiert werden und die Standards ersetzen:\
Standard Assets/Characters/ThirdPersonCharacter/Scripts/
- ThirdPersonCharacter.cs
- ThirdPersonUserControl.cs