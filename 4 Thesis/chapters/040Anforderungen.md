#Anforderungen
Dieses Kapitel beschreibt das Durchführen einer Anforderungsanalyse festgehalten. Anhand der Anforderungsanalyse sollen die Anforderungen für die entwickelnden Software ermittelt werden. Die Anforderungen bilden die Basis für die Architektur, das Softwaredesign, die Implementationund die Testfälle. Ihnen ist dem entsprechend ein sehr grosser Stellenwert zuzuschreiben.


##Use-Cases
Im Nachfolgenden werden alle UseCases aufgelistet die im Rahmen dieser Thesis gefunden wurden.

##Akteure

-------------------------------------------------------------------------------
__Akteure__
--------------------------- --------------------------------------------------
__Developer__				Der Developer ist der Entwickler der Webseite. Er möchte sein programmiertes oder sein verwendetes Social-Media Modul mit dem Authentifizierungsschnittstellen-Service schützen.

__User__           			Der User ist der Endkunde. Er nimmt am Social-Media Modul teil und authentifiziert sich über den Authentifizierungsschnittstellen-Service
-------------------------------------------------------------------------------

###Diagramm

<!--TODO YUML.me diagramm erstellen -->

#### UC-11 Registration

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Ein Developer ist am Authentifizierungsschnittstellen-Service registrieren


__Beschreibung__           	Ein Developer muss sich am Authentifizierungsschnittstellen-Service registrieren können

__Akteure__                 Developer

__Vorbedingung__            Keine

__Ergebnis__                Registrierter Developer

__Hauptszenario__           Der Developer füllt ein Registrationsformular aus und bestätigt seine E-Mail Adresse

__Alternativszenario__      -
-------------------------------------------------------------------------------

#### UC-12 Login

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Ein Developer kann sich beim Authentifizierungsschnittstellen-Service

__Beschreibung__           	Ein Developer muss sich am Authentifizierungsschnittstellen-Service authentifizieren können

__Akteure__                 Developer

__Vorbedingung__            Der Developer ist registriert.

__Ergebnis__                Authentifizierter und eigeloggter Developer

__Hauptszenario__           Der Developer loggt sich mit E-Mail und Passwort am Authentifizierungsschnittstellen-Service ein.

__Alternativszenario__      Der Developer sendet sich das verpasste Passwort per E-Mail zu. Erstellt über den im erhaltenden E-Mail enthaltenen Link ein neues Passwort und loggt sich mit E-mail und dem neuen Passwort am Authentifizierungsschnittstellen-Service ein.
-------------------------------------------------------------------------------

#### UC-21 Konfigurieren einer neuen Social-Media Modul Authentifizierungsvorgang

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Es ist eine neuer Authentifizierungsvorgang für ein neus Social Media-Modul konfiguriert

__Beschreibung__           	Der Developer kann ein neuer Authentifizierungsvorgang eröffnen

__Akteure__                 Developer

__Vorbedingung__            Der Developer hat sich am System angemeldet

__Ergebnis__                Neuer Authentifizierungsvorgang

__Hauptszenario__           Der Developer eröffnet einen neuen Authentifizierungsvorgang. Er benennt ihn sinnig. Die zu verwende(n) Authentifizierungskomponennten werden ausgewählt. Bei der Konfiguration unterstützen die Resultate die Studie den Developer für die optimalte Konfiguration. Am Ende der Konfiguration werden die Akzeptanzkritieren für eine erfolgreiche Authtentifizierung festgelegt.

__Alternativszenario__      Ein bestehender Authentifizierungsvorgang wird dupliziert
-------------------------------------------------------------------------------


#### UC-25 Einbinden in vorhandenes System

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Die Authentifizierungsschnittstelle kann in ein (bestehendes) System eingebunden werden

__Beschreibung__           	Der Developer kann die Authentifizierungsschnittstelle in seinem System integrieren

__Akteure__                 Developer

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsvorgang konfiguriert

__Ergebnis__                Der Developer hat eine Möglichkeit die Authentifizierungsschnittstelle mit seinem konfigurierten Authentifizierungsvorgangs in seiner Software einzubinden

__Hauptszenario__           Der Developer öffnet die Einbindeseite. Es werden ihm alle Schritte zur Erfolgreichen Einbindung aufgelistet. Der Code liegt individualisiert vor. Der Developer kopiert den Code in sein Programm

__Alternativszenario__      -
-------------------------------------------------------------------------------

#### UC-31 Einbinden in vorhandenes System

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Die Authentifizierungsschnittstelle kann in ein (bestehendes) System eingebunden werden

__Beschreibung__           	Der Developer kann die Authentifizierungsschnittstelle in seinem System integrieren

__Akteure__                 Developer

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsvorgang konfiguriert

__Ergebnis__                Der Developer hat eine Möglichkeit die Authentifizierungsschnittstelle mit seinem konfigurierten Authentifizierungsvorgangs in seiner Software einzubinden

__Hauptszenario__           Der Developer öffnet die Einbindeseite. Es werden ihm alle Schritte zur Erfolgreichen Einbindung aufgelistet. Der Code liegt individualisiert vor. Der Developer kopiert den Code in sein Programm

__Alternativszenario__      -
-------------------------------------------------------------------------------

#### UC-41 Report eines Authentifizierungsvorgangs

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Die Verwendung des Authentifizierungsvorgangs ist übersichtlich dargestellt

__Beschreibung__           	Um den Verwendung des Authentifizierungsvorgangs auszuwerten soll ein Report erstellt werden

__Akteure__                 Developer

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsvorgang konfiguriert. (Der Authentifizerungsvorgang ist eingebunden und verwendet worden)

__Ergebnis__                Report eines Authentifizierungsvorgangs

__Hauptszenario__           Nach Beenden eines Quizes, Votings, Wettbewerbs logt sich der Developer im System ein und generiert einen automatisierten Report um die Verwendung des Authentifizierungsvorgangs auszuwerten.

__Alternativszenario__      Um den Zwischenstand deines Quizes, Votings, Wettbewerbs auszuwerten logt sich der Developer im System ein und generiert einen automatisierten Report um die Verwendung des Authentifizierungsvorgangs auszuwerten.
-------------------------------------------------------------------------------

\newpage
##Anforderungen
Die Anforderungen sollen basierend auf der Satzschablone erstellt werden. Ziel ist sprachliche Missverständnisse dadurch zu vermeiden. Die Schablone fördert eine syntaktische Eindeutigkeit der Anforderungen und eine optimalen Zeit- und Kostenrahmen für die Verfassung.

###Aufbau
Die folgenden Abbildungen zeigen den Aufbau der Satzschablonen. Es wird zwischen der grundlegenden Version ohne zeitlichem oder Bedienungsorientiertem Aspekt und der Schablone mit diesen Eigenschaften unterschieden.

![Basis Schablone  *Quelle Rupp*[^rupp]](images/basis-schablone.jpg)

![Erweiterte Schablone  *Quelle Rupp*[^rupp]](images/erweiterte-schablone.jpg)

[^rupp]: Rupp Bilder sind aus dem Buch Basiswissen Requirements Engineering [@rupp]

\newpage
##Funktionale Anforderungen
Die funktionalen Anforderungen legen die Funktionen des Authentifizierungsschnittstellen-Service fest. Die Wünsche des Arbeitgebers aus <!--TODO Vorgehensschritten 1-4 (Kapitel 3.2)--> sind als Anforderungen umformuliert. Die funktionalen Anforderungen dienen als Grundlage für die Testfälle. Die Testfälle wiederum, bringen den Beweis dar, dass alle gewünschten Funktionen implementiert wurden.

Funktionale Anforderungen werden als FREQ-*Identifikation* bezeichnet

### FREQ-111			Developer Registration

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11

__Beschreibung__        Ein Developer kann sich an der Authentifizierungsschnittstellen-Service registrieren.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-112			Developer Login

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-12

__Beschreibung__        Ein Developer muss sich an der Authentifizierungsschnittstellen-Service mittels E-Mail und Passwort anmelden.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-113			Developer Passwort vergessen

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11, UC-12

__Beschreibung__        Ein Developer kann ein Passwort per E-Mail anfordern.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-114			Developer Passwort ändern

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-11, UC-12

__Beschreibung__        Ein Developer kann sein Passwort ändern. Dafür muss der Developer das alte und neue Passwort angeben.

__Techn. Risiko__       Niedrig

__Business Value__     	Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-211			Konfigurieren einer neuen Social-Media Modul Authentifizierungsvorgang

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Developer kann ein neuer Authentifizierungsvoragn für sein neus Social-Media Modul erfassen.

__Techn. Risiko__       Niedrig

__Business Value__     	Sehr Hoch
-----------------------------------------------------------------------------------------------------------------

### FREQ-212			Anpassen eines Authentifizierungsvorgangs

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Developer kann ein neues Social-Media Modul erfassen

__Techn. Risiko__       Hoch

__Business Value__     	Niedrig
-----------------------------------------------------------------------------------------------------------------

### FREQ-212			Anpassen eines Authentifizierungsvorgangs

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-21

__Beschreibung__        Ein Developer kann verschiedene Authentifizierungsvorgang

__Techn. Risiko__       Hoch

__Business Value__     	Niedrig
-----------------------------------------------------------------------------------------------------------------

### FREQ-311			Generierung von Code für einbinden in vorhandenes System

--------------------	-----------------------------------------------------------------------------------------
__UC-Referenz__         UC-31

__Beschreibung__        Ein Developer kann einen Code generieren lassen. Dieser Code soll ihm die Integration in sein System vereinfachen

__Techn. Risiko__       	Hoch

__Business Value__     	Niedrig
-----------------------------------------------------------------------------------------------------------------



