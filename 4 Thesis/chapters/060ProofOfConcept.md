#Proof Of Concept

##Techologien

Der Auftraggeber möchte dass die aktuell in seinem Betrieb eingesetzten Technologien für die Implementation der Arbeit verwendet werden. Die vorgegebenen Technologien sind im folgenden Kapitel erklärt.

###C-Sharp
Im Rahmen der Einführung von .net veröffentlichte Microsoft 2002 die Programmiersprache C-Sharp oder verkürzt C#. C# orientiert sich stark an Java, C++, Haskell und Delphi. Daher liegt es Nahe das C# eine objektorientierte Programmiersprache ist und der Wechsel von den zu vorgenannten Programmiersprachen auf C# einfach fällt.

Neben Grundprinzipen der objektorientierten Programmierung resultiert aus folgende innovativen Sprach-Konstrukte eine vereinfachte Programmierung:

-	Gekapselte Methodensignaturen, Delegaten genannt, die typsichere Ereignisbenachrichtigungen ermöglichen
-	Eigenschaften, die als Accessoren für private Membervariablen dienen
-	Attribute, die zur Laufzeit deklarative Metadaten zu Typen bereitstellen
-	Inline-XML-Dokumentationskommentare
-	Sprachintegrierte Abfrage (Language-Integrated Query, LINQ), die integrierte Abfragefunktionen für eine Vielzahl von Datenquellen bereitstellt

Der C#-Erstellungsprozess ist im Vergleich zu C und C++ einfach und flexibler als in Java. Es gibt keine separaten Headerdateien und es ist nicht erforderlich, Methoden und Typen in einer bestimmten Reihenfolge zu deklarieren. Eine C#-Quelldatei kann eine beliebige Anzahl von Klassen, Strukturen, Schnittstellen und Ereignissen definieren. [^csharpbasic]

###ASP.net Web API 2 / ASP.net MVC Framework
Microsoft entwickelte mit dem ASP.net MVC Framework ein schlankes und einfach zu testendes Präsentationsframework. Wie im Namen enthalten basiert das Framework auf dem MVC-Pattern.
Die klare Trennung von Eingabelogik, Geschftslogik und Präsentationslogik wird durch die vom Framework bereitgestellten Komponenten unterstützt.
Um RESTful-Webservices einfach entwickeln zu können stellt Microsoft mit ASP.net Web API 2 eine einfache zu verwendendes und starkes Software Paket zur Verfügung. ASP.net Web API 2 basiert auf dem ASP.net MVC Framework.
[^aspnetbasic]

[^csharpbasic]: Quelle:[@csharpbasic]
[^aspnetbasic]: Quelle:[@csharpbasic]

\newpage
###Entity Framework
Entity Framework (EF) ist eine objektrelationale Zuordnung, die .NET-Entwicklern über domänenspezifische Objekte die Nutzung relationaler Daten ermöglicht. Ein Grossteil des Datenzugriffscodes, den Entwickler normalerweise programmieren, muss folglich nicht geschrieben werden. [^efbasic]

###Grunt
Grunt.js ist ein sogenannter Taskrunner, d.h. es übernimmt Aufgaben wie das Kompilieren von CSS, überprüft JavaScript auf Fehler ab und optimiert alle Assets für das Web. Grunt.js zeichnet isch dadurch aus, dass, bei richtiger Konfiguration, Grunt.js die Daten selbst überwacht und bei Änderungen die oben genannten Tasks automatisch ausführt.

###AngularJS
Mittels AngularJS wird die Client-Browser App entwickelt. AngularJS ist ein Javascript Framework, welches OpenSource von Google Inc. veröffentlicht wurde. AngularJS macht einen Grossteil des Codes, den man normalerweise schreibt, überflüssig. Die Reduktion des Codes begründet sich durch die Automatisierung von Standardaufgaben. Die manuelle DOM-Selektion, DOM-Manipulation und Event-Behandlung werden durch AngularJS überflüssig. Durch Einsatz von Direktiven und Modulen wird die Wiederverwendbarkeit von Code ermöglicht.

Die normalen Datentypen von JavaScript können verwendet werden. Dadurch ist es sehr einfach möglich, fremde Bibliotheken einzubinden, ohne eine weitere Zwischenschicht (Glue Code) zu implementieren. Die Methode, die AngularJS dazu verwendet nennt sich Dirty-Checking und wird im Vertiefungskapitel näher erklärt.[^angularjsbasic]


###JSON
Zwischen der AngularJS WebApp und dem Webservice dient JSON(JavaScript Object Notation) als Datenübertragungsformat. JSON zeichnet sich durch seine schlanke Notation und der objektnahen Darstellung aus
[^efbasic]: Quelle [@efbasic]
[^angularjsbasic]: Quelle [@angularjsbasic]

\newpage

## Sicherheitsstufe
### Plugin Entwicklung
Die Entwicklung einer Sicherheitstufe wird wie im Konzept unter[Modularität und Erweiterbarkeit] vorgesehen losgelöst und unabhängig entwickelt. Pro Sicherheitstufe werden 3 VisualStudio Projekte angelegt. 
Im Hauptprojekt der Sicherheitstufe wird die klassiche Runtimeumgebung für Webprojekte mit den benötigten Standartreferenzen und Templates für Microsoft MVC und Microsoft WebAPI aufgesetzt. Das PlugIn kann in diesem Projekt ohne Authentifizierungsservice entwickelt und  ausgeführt werden. 
Das Testprojekt stellt die Lauffähigkeit der im Hauptprojekt entwickelten Implementationen sicher. Um die Entwicklungen im Hauptprojekt als DLL-Klassenbibliothek zu generieren die ClassLibary-Projekt. In diesem werden die entwickelten Klassen aus dem Hauptprojekt verlinkt. Bei vorhandensein aller nötigen Referenzen und verlinkungen erstellt die ClassLibary bei einem Build die DLL-Klassenbibliothek unser PlugIn.
![Screenshot VisualStudio der 3 Projekte der Sicherheitsstufe E-Mail](images/visualstudio_securitystep.jpg)

### Interface - Vertrag mit den Sicherheitsstufen
Für den Endbenutzer beginnt die Authentifizierung mit öffnnen der Authentifizierung-Lightbox. Dabei wird die Action "Validate/Check" des Authentifizierungsservice aufgerufen. Diese zentrale Funktionalität überprüft den Status der Verifizierung und ruft die nötigen Sicherheitstufen auf.
Für den Endbenutzer ist der Ablauf der Authentifizierung pro Sicherheitsstufe sichtbar. Der Ablauf und Inhalt der Authentifzierung jeder Sicherheitsstufe kann individuell erstellt werden. Einzig der Startpunkt und Endpunkt wird von Authentifzierungsservice vorgegeben. So muss die Seite bzw. Action "Index" für den Start der Authentifizierung vorhanden sein. Am Ende der Authentifizierung soll es wieder zurück zur Action "Validate/Check" des Authentifzierungsservice gehen.
Damit die Action "Validate/Check" übperüfen kann, ob die Authentifizierung der Sicherheitsstufe erfolgreich war oder zum 1. oder wiederholten mal ausgeführt werden, wir die Methode "checkIsValidated" pro Sicherheitsstufe implementiert. Diese Funktion teil anhand der eindeutigen Spezifikation Projekt und ID des Providers mit ob die Validierung erfolgreich ist.
Das Interface des MEF-Contracts aller Sicherheitsstufen enthält ausserdem zwei Funktionalitäten zum abfrage und Speicherung individuellen Konfiguration der Sichstufen und die Abfrage der Vergleichsparameter.




![ISecurityStep](images/code/ISecurityStep.jpg)



