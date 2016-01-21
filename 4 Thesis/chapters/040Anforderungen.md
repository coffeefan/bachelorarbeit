#Anforderungen
Dieses Kapitel beschreibt das Durchführen einer Anforderungsanalyse festgehalten. Anhand der Anforderungsanalyse sollen die Anforderungen für die entwickelnden Software ermittelt werden. Die Anforderungen bilden die Basis für die Architektur, das Softwaredesign, die Implementationund die Testfälle. Ihnen ist dem entsprechend ein sehr grosser Stellenwert zuzuschreiben.


##Vorgehensweise
Die Schlüsselwörter „muss“, „muss nicht“, „erforderlich“, „empfohlen“, „sollte“, „sollte nicht“, „kann“ und „optional“ in allen folgenden Abschnitten sind gemäss RFC 2119 zu interpretieren. [@rfc2119]

<!-- TODO: Übersetzten
file:///C:/Users/chris/Downloads/doku.pdf 3.2
-->

##Use-Cases
Im Nachfolgenden werden alle UseCases aufgelistet die im Rahmen dieser Thesis gefunden wurden.

#### UC-01 Registration

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

#### UC-01 Login

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

#### UC-01 Konfigurieren einer neuen Social-Media Modul Authentifizierungsvorgang

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Es ist eine neuer Authentifizierungsvorgang für ein neus Social Media-Modul konfiguriert


__Beschreibung__           	Der Developer kann eine neue Aktivität eröffnen

__Akteure__                 Developer

__Vorbedingung__            Der Developer hat sich am System angemeldet

__Ergebnis__                Neuer Authentifizierungsvorgang

__Hauptszenario__           Der Developer eröffnet einen neuen Authentifizierungsvorgang. Er benennt ihn sinnig. Die zu verwende(n) Authentifizierungskomponennten werden ausgewählt. Bei der Konfiguration unterstützen die Resultate die Studie den Developer für die optimalte Konfiguration. Am Ende der Konfiguration werden die Akzeptanzkritieren für eine erfolgreiche Authtentifizierung festgelegt.

__Alternativszenario__      Ein bestehender Authentifizierungsvorgang wird dupliziert
-------------------------------------------------------------------------------


#### UC-01 Einbinden in vorhandenes System

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

#### UC-01 Report eines Authentifizierungsvorgangs

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




