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
__Ziel__                    Ein Developer kann sich an der Authentifizierungsschnittstelle registrieren


__Beschreibung__           	Der Developer kann die Authentifizierungsschnittstelle in seinem System integrieren

__Akteure__                 Developer, System

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsprogramm konfiguriert

__Ergebnis__                Der Developer hat eine individuellen Zugang zur Authentifizierungsschnittstelle seines Authentifizierungsvorgangs

__Hauptszenario__           Der Developer möchte nach konfigurieren seines Authentifizierungsprogramm den Zugang für die Implmentierung auslösen.

__Alternativszenario__      -
-------------------------------------------------------------------------------


#### UC-01 Einbinden in vorhandenes System

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Die Authentifizierungsschnittstelle muss in ein (bestehendes) System eingebunden werden können


__Beschreibung__           	Der Developer kann die Authentifizierungsschnittstelle in seinem System integrieren

__Akteure__                 Developer, System

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsvorgang konfiguriert

__Ergebnis__                Der Developer hat eine Möglichkeit die Authentifizierungsschnittstelle mit seinem konfigurierten Authentifizierungsvorgangs in seiner Software einzubinden

__Hauptszenario__           Der Developer öffnet die Einbindeseite. Es werden ihm alle Schritte zur Erfolgreichen Einbindung aufgelistet. Der Code liegt individualisiert vor. Der Developer kopiert den Code in sein Programm

__Alternativszenario__      -
-------------------------------------------------------------------------------




#### UC-01 Einbinden in vorhandenes System

-------------------------------------------------------------------------------
__UseCase__
--------------------------- --------------------------------------------------
__Ziel__                    Die Authentifizierungsschnittstelle muss in ein (bestehendes) System eingebunden werden können


__Beschreibung__           	Der Developer kann die Authentifizierungsschnittstelle in seinem System integrieren

__Akteure__                 Developer, System

__Vorbedingung__            Der Developer hat sich am System angemeldet. Der Developer hat ein neues Authentifizierungsvorgang konfiguriert

__Ergebnis__                Der Developer hat eine Möglichkeit die Authentifizierungsschnittstelle mit seinem konfigurierten Authentifizierungsvorgangs in seiner Software einzubinden

__Hauptszenario__           Der Developer öffnet die Einbindeseite. Es werden ihm alle Schritte zur Erfolgreichen Einbindung aufgelistet. Der Code liegt individualisiert vor. Der Developer kopiert den Code in sein Programm

__Alternativszenario__      -
-------------------------------------------------------------------------------