#Anforderungen
Dieses Kapitel beschreibt das Durchführen einer Anforderungsanalyse. Anhand der Anforderungsanalyse sollen die Anforderungen für die zu entwickelnden Softwares ermittelt werden. Die Anforderungen bilden die Basis für die Architektur, das Softwaredesign, die Implementation und die Testfälle. Ihnen ist dementsprechend ein sehr grosser Stellenwert zuzuschreiben.

##Akteure
__Programmierer__
Der Programmierer ist der Entwickler der Webseite. Er möchte sein programmiertes oder sein verwendetes Social-Media-Modul mit dem Authentifizierungsservice schützen.

__User__
Der User ist der Endbenutzer. Er nimmt am Social-Media-Modul teil und authentifiziert sich über den Authentifizierungsservice.







\newpage

##Use-Cases
Im Nachfolgenden werden alle Use-Cases aufgelistet, die im Rahmen dieser Thesis gefunden wurden.

###Use-Cases Diagramm

Das Use-Case Diagramm illustriert die nachfolgenden Use-Cases. Dadurch kann rasch ein Überblick über die zu entwickelnde Lösung geschaffen werden.

![Use-Case Diagram](images/use-case-diagram.png)

\newpage

###Use-Cases Beschreibung
Die im Diagramm dargestellten Use-Cases werden nun noch beschrieben. Die Use-Cases wurden numerisch nach Themenbereichen gruppiert.


#### UC-11 Registration für den Konfigurator

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Ein Programmierer ist beim Authentifizierungsservice registriert.


__Beschreibung__           	Ein Programmierer muss sich am Authentifizierungsservice registrieren können.

__Akteure__                 Programmierer

__Vorbedingung__            Keine

__Ergebnis__                Registrierter Programmierer

__Hauptszenario__           Der Programmierer füllt ein Registrationsformular aus und bestätigt seine E-Mail Adresse.

__Alternativszenario__      -
-------------------------------------------------------------------------------

#### UC-12 Login Konfigurator

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Ein Programmierer kann sich beim Authentifizierungsservice registrieren. 

__Beschreibung__           	Ein Programmierer muss sich am Authentifizierungsservice authentifizieren können.

__Akteure__                 Programmierer

__Vorbedingung__            Der Programmierer ist registriert.

__Ergebnis__                Authentifizierter und eingeloggter Programmierer

__Hauptszenario__           Der Programmierer loggt sich mit E-Mail und Passwort am Authentifizierungsservice ein.

__Alternativszenario__      Der Programmierer sendet sich das verpasste Passwort per E-Mail zu. Er erstellt über den im erhaltenden E-Mail enthaltenen Link ein neues Passwort und loggt sich mit E-mail und dem neuen Passwort am Authentifizierungsservice ein.
-------------------------------------------------------------------------------

\newpage
#### UC-21 Konfigurieren eines Authentifizierungsvorgang

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Es ist ein neuer Authentifizierungsvorgang für ein neues Social Media-Modul konfiguriert.

__Beschreibung__           	Der Programmierer kann ein neuer Authentifizierungsvorgang eröffnen.

__Akteure__                 Programmierer

__Vorbedingung__            Der Programmierer hat sich am System angemeldet.

__Ergebnis__                Neuer Authentifizierungsvorgang

__Hauptszenario__           Der Programmierer eröffnet einen neuen Authentifizierungsvorgang. Er benennt ihn sinnig. Die zu verwende(n) Authentifizierungskomponenten werden ausgewählt. Bei der Konfiguration unterstützen die Resultate der Studie den Programmierer für die optimale Konfiguration. Am Ende der Konfiguration werden die Akzeptanzkriteren für eine erfolgreiche Authentifizierung festgelegt.

__Alternativszenario__      Ein bestehender Authentifizierungsvorgang wird dupliziert.
-------------------------------------------------------------------------------


#### UC-25 Authentifizierungsservice in vorhandenes System einbinden

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Die Authentifizierungsschnittstelle kann in ein (bestehendes) System eingebunden werden.

__Beschreibung__           	Der Programmierer kann die Authentifizierungsschnittstelle in seinem System integrieren.

__Akteure__                 Programmierer

__Vorbedingung__            Der Programmierer hat sich am System angemeldet. Der Programmierer hat einen neuen Authentifizierungsvorgang konfiguriert.

__Ergebnis__                Der Programmierer hat eine Möglichkeit, die Authentifizierungsschnittstelle mit seinem konfigurierten Authentifizierungsvorgang in seiner Software einzubinden.

__Hauptszenario__           Der Programmierer öffnet die Einbindeseite. Es werden ihm alle Schritte zur erfolgreichen Einbindung aufgelistet. Der Code liegt individualisiert vor. Der Programmierer kopiert den Code in sein Programm.

__Alternativszenario__      -
-------------------------------------------------------------------------------

\newpage
#### UC-31 User authentifizieren

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Der User ist authentifiziert oder der User abgelehnt.

__Beschreibung__           	Der User probiert sich über den Authentifizierungsservice zu authentifizieren, um an einer Interaktivität teilzunehmen.

__Akteure__                 User

__Vorbedingung__            Der Programmierer hat den Authentifizierungsvorgang konfiguriert und in seinem System eingebunden.

__Ergebnis__                Der Authentifizierungsservice authentifiziert den User oder lehnt ihn ab.

__Hauptszenario__           Der User wird von der Interaktivität an den Authentifizierungsservice weitergeleitet. Der User authentifiziert sich. Der User kann die Eingabe der Interaktivität erfolgreich abschliessen.

__Alternativszenario__      Der User wird von der Interaktivität an den Authentifizierungsservice weitergeleitet. Der User wird vom System abgelehnt. Der User kann die Eingabe der Interaktivität nicht erfolgreich abschliessen.
-------------------------------------------------------------------------------

#### UC-41 Report eines Authentifizierungsvorgangs

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Die Verwendung des Authentifizierungsvorgangs ist übersichtlich dargestellt.

__Beschreibung__           	Um den Verwendung des Authentifizierungsvorgangs auszuwerten, soll ein Report erstellt werden.

__Akteure__                 Programmierer

__Vorbedingung__            Der Programmierer hat sich am System angemeldet. Der Programmierer hat einen neuen Authentifizierungsvorgang konfiguriert. (Der Authentifizerungsvorgang ist eingebunden und verwendet worden).

__Ergebnis__                Report eines Authentifizierungsvorgangs

__Hauptszenario__           Nach Beenden eines Quizes, Votings, Wettbewerbs logt sich der Programmierer im System ein und generiert einen automatisierten Report, um die Verwendung des Authentifizierungsvorgangs auszuwerten.

__Alternativszenario__      Um den Zwischenstand eines Quizes, Votings, Wettbewerbs auszuwerten logt sich der Programmierer im System ein und generiert einen automatisierten Report, um die Verwendung des Authentifizierungsvorgangs auszuwerten.
-------------------------------------------------------------------------------

\newpage
#### UC-51 Wartbarkeit des Authentifizierungsservices

-------------------------------------------------------------------------------
__Use-Case__
--------------------------- --------------------------------------------------
__Ziel__                    Der Authentifizierungsservice soll mit geringem Aufwand angepasst werden können.

__Beschreibung__           	

__Akteure__                 Entwicklungsteam-Mitglied

__Vorbedingung__            Das Entwicklungsteam-Mitglied hat Zugriff auf das Entwicklungs-Repository, Testsystem und Livesystem

__Ergebnis__                Die Anpassung ist integriert.

__Hauptszenario__           Dank eingehaltenen Coderichtlinien ist es einfach möglich, die Anpassung einzupflegen.

__Alternativszenario__      -
-------------------------------------------------------------------------------

\newpage

##Anforderungen
Die Anforderungen sollen basierend auf der Satzschablone erstellt werden. Ziel ist es, sprachliche Missverständnisse dadurch zu vermeiden. Die Schablone fördert eine syntaktische Eindeutigkeit der Anforderungen und einen optimalen Zeit- und Kostenrahmen für die Verfassung.

###Aufbau
Die folgenden Abbildungen zeigen den Aufbau der Satzschablonen. Es wird zwischen der grundlegenden Version ohne zeitlichen oder bedienungsorientierten Aspekt und der Schablone mit diesen Eigenschaften unterschieden.

![Basis Schablone  *Quelle Rupp*[^rupp]](images/basis-schablone.png)

![Erweiterte Schablone  *Quelle Rupp*[^rupp]](images/erweiterte-schablone.png)

[^rupp]: Rupp Bilder sind aus dem Buch Basiswissen Requirements Engineering [@rupp]


\newpage
##Funktionale Anforderungen
Die funktionalen Anforderungen legen die Funktionen des Authentifizierungsservices fest. Die Wünsche des Arbeitgebers sind als Anforderungen umformuliert. Die funktionalen Anforderungen dienen als Grundlage für die Testfälle. Die Testfälle wiederum, zeigen dass alle gewünschten Funktionen implementiert wurden.

Funktionale Anforderungen werden als FREQ-*Identifikation* bezeichnet.

### FREQ-111			Programmierer Registration

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11

__Beschreibung__        Ein Programmierer kann sich beim Authentifizierungsservice registrieren.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-112			Programmierer Login

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-12

__Beschreibung__        Ein Programmierer muss sich beim Authentifizierungsservice mittels E-Mail und Passwort anmelden.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-113			Programmierer Passwort vergessen

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11, UC-12

__Beschreibung__        Ein Programmierer kann ein Passwort per E-Mail anfordern.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-114			Programmierer Passwort ändern

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11, UC-12

__Beschreibung__        Ein Programmierer kann sein Passwort ändern. Dafür muss der Programmierer das alte und neue Passwort angeben.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

\newpage
### FREQ-211			Konfigurieren eines neuen Authentifizierungsvorgangs

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Programmierer kann einen neuen Authentifizierungsvorgang für seine Interaktivität erfassen.

__Techn. Risiko__       Niedrig

__Business Value__     	Sehr Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-212			Antworten der Umfrage in Authentifizerungsservice importieren

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Die Umfrageantworten müssen in den Authentifizerungsservice abgespeichert werden können. Der Import ist direkt über die Datenbank realisierbar.

__Techn. Risiko__       Niedrig

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### FREQ-213			Umfrageergebnisse zur Konfiguration nutzen

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Programmierer kann zur Konfiguration des Authentifizierungsvorangs die Umfrageergebnisse visualisiert nutzen. Dabei sollen verschiedene Auswertungsmöglichkeiten zur Anstrengung und Akzeptanz der Sicherheitsstufe möglich sein.

__Techn. Risiko__       Niedrig

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### FREQ-214			Anpassen eines Authentifizierungsvorgangs

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Programmierer kann den Authentifizierungsvorgang anpassen.

__Techn. Risiko__       Hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### FREQ-215			Authentifizerungs-Stufe auswählen

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Programmierer muss eine Authentifizerungsstufe für den Authentifizierungsvorgangs auswählen.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

\newpage
### FREQ-251			Generierung von Code für Einbinden in ein vorhandenes System

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25

__Beschreibung__        Ein Programmierer kann einen Code generieren lassen. Dieser Code soll ihm die Integration in sein System vereinfachen.

__Techn. Risiko__       Sehr Hoch

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-311			Authentifizieren

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-31

__Beschreibung__        Ein User kann sich über den Authentifizierungsservice authentifizieren, um an der Interaktivität teilzunehmen. Der Authentifizierungsservice authentifiziert oder lehnt den User ab.

__Techn. Risiko__       Mittel

__Business Value__     	Sehr Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-411			Report der Authentifizierungen generieren

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-41

__Beschreibung__        Der Programmierer kann einen Report generieren. Der Report soll die Verwendung übersichtlich darstellen.

__Techn. Risiko__       Mittel

__Business Value__     	Sehr Hoch
-----------------------------------------------------------------------------------------------------------------

\newpage
##Nicht Funktionale Anforderungen
Nicht Funktionale Anforderungen werden als NFREQ-*Identifikation* bezeichnet.

### NFREQ-110			Betriebsystemunabhängigkeit

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         Alle

__Beschreibung__        Der Authentifizierungsservice muss auf allen bekannten Betriebsystemen mit HTML5 und javascriptfähigen Browser verwendet werden können.

__Techn. Risiko__       Mittel

__Business Value__     	Sehr Hoch
-----------------------------------------------------------------------------------------------------------------

### NFREQ-115			Wartbarkeit

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-51

__Beschreibung__        Die Wartbarkeit des Systems soll sichergestellt werden.

__Techn. Risiko__       Mittel

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### NFREQ-120			Einfache Integration

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Der Authentifizierungsservice soll einfach im vorhandenen System eingebunden werden können.

__Techn. Risiko__       Mittel

__Business Value__     	hoch
-----------------------------------------------------------------------------------------------------------------




### NFREQ-122			Einfache und verständliche visuelle Konfiguration

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Der Authentifizierungsservice soll einfach und verständlich/optisch konfiguriert werden können.

__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------



### NFREQ-126			Einfache und verständliche Authentifizierung

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-31

__Beschreibung__        Der User soll einfach und verständlich/optisch authentifizieren können.

__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### NFREQ-127			Responsives Design für Authentifizerung

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Der User soll sich mit Desktop, Tablet und Smartphone authentifizieren können

__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

<!--mit dieser Anforderung kann man aufgehängt werden. ### NFREQ-128			Browser Kompatibilität der Authentifizierung des Users

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Möglichst viele User sollen an einer Authentifizierung teilnehmen können. Daher muss die Authentifizerungs des Users folgende Browser unterstützen:


__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
------------------------------------------------------------------------------------------------------------------ -->

### NFREQ-130			Performance

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-31

__Beschreibung__        Das System soll insbesondere an der Stelle der Authentifzierung performant sein.

__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### NFREQ-132			Skalierbar

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-31, UC-25, UC-21, UC22

__Beschreibung__        Das System soll eine hohe Skalierbarkeit aufweisen. 

__Techn. Risiko__       Sehr hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

### NFREQ-135			Hohe Verfügbarkeit

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Der Authentifizierungsservice soll eine Verfügbarkeit von mindestens 99.9% haben. 

__Techn. Risiko__       Hoch

__Business Value__     	Mittel
-----------------------------------------------------------------------------------------------------------------

\newpage

### NFREQ-210			Programmierer kann aus Vielzahl von verschiedenen Sicherheitsstufen auswählen

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Dem Programmierer stehen verschiedene Sicherheitsstufen zur Verfügung. Das Wort "verschieden" wurde durch folgende Aspekte mit dem Auftraggeber definiert:
						Abgeleitet von der Aufgabenstellung sind die Aspekte "Mehrfachteilnahme" und "Automatisierung" definiert worden. Beide Aspekte können durch eine Sicherheitsstufe mehr oder weniger verhindern werden.
						Abhängig von der Art der Interaktivität ist es wirtschaftlich sinnvoll, dass Kosten entstehen dürfen. Deshalb sind die Höhe der Kosten ein Aspekt.
						Ein weiterer Aspekt ist der Aufwand für den Benutzer. 		

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### NFREQ-212			Die verwendeten Sicherheitsstufen sind in der Schweiz verbreitet

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-25, UC-21, UC22

__Beschreibung__        Die eingesetzten Sicherheitsstufen sollten in der Schweiz verbreitet sein.			

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

\newpage


\newpage
##Risiken
Nachfolgend sind die im Gespräch mit dem Auftraggeber gefundenen Risiken bezüglich der Bachelorarbeit, sowie deren Auswirkungen, aufgeführt. <!-- Für die Risiken werden nur die zur Umsetzung ausgewählten Anforderungen berücksichtigt. -->

###R-01 Akzeptanz
Programmierer und insbesondere auch User, welche den Authentifizierungsservice verwenden sollen, sind völlig unterschiedlich. Deren unterschiedlichen Ansprüche machen es schwierig, eine Lösung zu entwickeln, welchen den Akteuren gerecht wird.

Da der Auftraggeber sowohl die Zielgruppe Programmierer wie auch User kennt, kann er hier gezielt Feedback geben.

Die Auswirkung bei Eintritt dieses Risikos ist im Rahmen der Bachelorarbeit gering, da der Erfolg der Arbeit nicht von der tatsächlichen Verwendung im produktiven Umfeld abhängt.

###R-02 Kosten
Da es sich bei diesem Projekt um eine Bachelorarbeit handelt, besteht kein Personalkostenrisiko. Kostenpflichtige Produkte Dritter werden nicht verwendet. Einzig der Betrieb/ das Hosting der Bachelorarbeit verursacht Kosten. Das Kostenrisiko kann dank fixen Leistungsparametern auf ein Minimum reduziert werden.

###R-03 Überkomplexität
Es besteht die Möglichkeit, dass die Komplexität des zu entwickelnden Systems viel höher ist, als angenommen. Da die Komplexität nur zu einem gewissen Grad durch Architekturentscheide beeinflusst werden kann, muss ein besonderes Augenmerk auf dieses Risiko gelegt werden.

Dieses Risiko wird mit hoher Wahrscheinlichkeit eintreten.

Die Auswirkung bei Eintritt dieses Risikos ist, dass nicht der gesamte Umfang der Bachelorarbeit erarbeitet werden kann, weil zur Lösung der Komplexitätsprobleme zusätzliche Zeit benötigt wird.

###R-04 Systemumfeldänderungen
Umsysteme könnten während der Projektphase dieser Bachelorarbeit massgeblich verändert werden.

Dieses Risiko wird mit sehr geringer Wahrscheinlichkeit eintreten.

Die Auswirkung bei Eintritt dieses Risikos kann nicht abgeschätzt werden. Situativ muss dieses Risiko behandelt werden.

###R-05 Schlechte/Unzureichende Framework
Die Bachelorarbeit wird basierend auf verschiedenen Frameworks umgesetzt. Das Risiko, dass Frameworks nicht wie beschrieben funktionieren, schlecht dokumtiert oder instabil sind besteht.

Dieses Risiko wird mit mittlerer Wahrscheinlichkeit eintreten.
Als Auswirkungen dieses Risikos sind Wechsel des Frameworks oder gar manuelle Entwicklungen und daraus zusätzlicher, nicht einschätzbarer Aufwand nötig.

###R-06 Termineinhaltung
Den fixen Abgabetermin der Bachelorarbeit gilt es einzuhalten. Das Risiko, dass die Arbeit verspätet abgegeben wird, besteht.

Dieses Risiko wird mit geringer Wahrscheinlichkeit eintreten.
Die Auswirkung bei Eintritt dieses Risikos ist das Nichtbestehen der Arbeit.

###R-07 Auslastung
Das Projekt wird durch einen Mitarbeiter getragen. Dieser ist sowohl im Beruf, wie auch privat stark ausgelastet. Der hohe schulische Aufwand kann beeinflusst werden. Mit zusätzlichen Ausfällen durch Krankheit oder nicht vorhersehbare Vorfällen muss gerechnet werden.

Das Risiko wird mit mittlerer Wahrscheinlichkeit eintreten.
Die Auswirkungen bei Eintritt dieses Risikos werden sich in der Qualität und Quantität der Arbeit widerspiegeln.

\newpage
### Risikomatrix

![Risikomatrix [^risikomatrix]](images/excel-statistik/risikomatrix.png)




R1	Akzeptanz

R2	Kosten

R3	Überkomplexität

R4	Systemumfeldänderungen

R5	Schlechte/Unzureichende Frameworks

R6	Termineinhaltung

R7	Auslastung


###Massnahmen
Um das Zusammenspiel der verschiedenen Technologien und die daraus resultierende Komplexität einschätzen zu können, wird vor Projektbeginn ein Prototyp mittels Durchstich durch alle Technologien erstellt. Danach kann die Komplexität im Zusammenspiel der Technologie eingeschätzt und bei Bedarf eine Technologie durch eine andere ersetzt werden. So kann das Risiko 3 "Überkomplexität" und Risiko 5 "Schlechte/Unzureichende Frameworks" minimiert werden.

Das Projekt ist über eine Anzahl von Feiertagen gelegt, welche gebraucht werden könnten. Zusätzlich ist vom Studenten eine Arbeitswoche Ferien eingeplant, welche im Notfall auch für die Arbeit verwendet werden könnte.  Durch diese Massnahmen soll das Risiko 6 "Termineinhaltung" minimal bleiben.
Das Risiko 7 "Auslastung" kann nicht direkt vermindert werden. Die Aktivitäten im Bereich der freiwilligen Arbeit ist auf ein Minimum reduziert. Für die restliche freiwilige Arbeit ist mit Freunden ein Notfallszenario entwickelt worden, so kann der Student bei Bedarf seine freiwillige Arbeit durch andere Personen übernehmen lassen kann. Der Kontakt mit dem Arbeitgeber wird intensiv gepflegt, um bei Bedarf die Arbeitsbelastung zu vermindern. Die Massnahmen, welche für Risiko 6 ergriffen sind, entschärfen auch Risiko 7.

[^risikomatrix]: Die Risikomatrix wurde basierend auf der Excel-Vorlage der Stadtpolizei Zürich Abteilung Informatik entworfen. [@vorlagerisikomatrix]
