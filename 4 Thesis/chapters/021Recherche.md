\newpage

#Recherche


## Fachbegriffe
Eine ausführliche Erklärung der Fachbegriffe befindet sich im Anhang unter dem Kapitel [Glossar].

## Erläuterung der Grundlagen
In diesem Kapitel werden Funktionsweisen und Grundlagen ausgeführt, welche für die Bearbeitung dieser Bachelorthesis herangezogen wurden. 

###Authentifizierung
Authentifizieren - beglaubigen, die Echtheit von etwas bezeugen [^duden]

Eine Person oder ein Objekt eindeutig zu **authentifizieren** bedeutet zu ermitteln, ob die- oder derjenige auch die Person ist, als welche sie oder er sich ausgibt. [^authentifizierungsdef] Dies unterstreicht auch die Ableitung des Wortes vom Englischen Verb *authenticate*, was auf Deutsch "sich als *echt erweisen, sich verbürgen, glaubwürdig sein*" bedeutet.  Das bekannteste Verfahren der Authenfizierung ist die Eingabe von Benutzernamen und Passwort. Weiter ist die PIN-Eingabe bei Bankautomaten oder Mobiltelefonen häufig verbreitet. Die Möglichkeiten von verschiedenen Authentifizierungen ist nahezu grenzenlos.
[^authentifizierungsdeforg]

###Autorisierung
Autorisierung - Befugnis, Berechtigung, Erlaubnis, Genehmigung [^duden]

Wenn die [Authentifizierung] erfolgreich war, erteilt ein System die Autorisierung. Dabei wird der Person oder dem Objekt erlaubt, bestimmte Aktionen oder Zugriffe durchzuführen. Meist verfügen unterschiedliche Benutzer eines Systems über verschiedene Zugriffsrechte. Die korrekte Zuweisung der individuellen Rechte ist ebenfalls Bestandteil der Autorisierung.

Der Begriff Authentifizierung wird vielfach mit dem Begriff Autorisierung verwechselt. Die Authentifizierung wird vom Benutzer initiiert. Sie dient dem Nachweis, zur Ausübung bestimmter Rechte befugt zu sein. Die anschliessende Autorisierung erfolgt automatisch durch das System selbst. Im Zuge der Autorisierung werden dem Benutzer seine Zugriffsrechte zugewiesen.
[@authentifizierungsdeforg]



[^authentifizierungsdef]: [@authentifizierungsdef] 
[^authentifizierungsdeforg]: [@authentifizierungsdeforg]


\newpage


[^stand20160108]: Stand 4. Januar 2016

\newpage
##Sicherheitsprinzipien
In diesem Abschnitt werden die Grundlagen der Sicherheitsprinzipien vermittelt, auf denen eine Authentifizierungssoftware aufgebaut werden kann.

###KISS
KISS steht für **K**eep **I**t **S**tupid *and* **S**imple

Ein verbreitetes Problem unter Softwareentwickern und Programmiern heute ist, dass dazu tendiert wird, Probleme zu kompliziert und verschachtelt zu lösen. Acht bis neun von zehn Entwickeln machen den Fehler, Probleme zu wenig auseinanderzubrechen und alles in einem grossen Programm zu lösen, anstatt es in kleinen Paketen verständlich zu programmieren.[^apachekiss]


Die folgenden Punkte listen die Vorteile für Softwareentwickler beim Verwenden von Kiss auf:

- Mehr Probleme sollen schneller gelöst werden
- Der Entwickler kann komplexe Probleme mit wenigen Zeilencodes lösen
- Die Codequalität steigt
- Der Entwickler kann grössere Systeme erstellen und unterhalten
- Der Code wird flexibler werden, einfach wieder zu verwenden und zu modifizieren
- Die Zusammenarbeit in grösseren Entwicklerteams und Projekten wird vereinfacht, da der Code bei allen "stupid and simple" ist


Die Begründung, warum KISS die Sicherheit fördert, liefert Saltzer und Schroeder: "*Ungewollte Zugriffspfade können nur durch zeilenweise Codeinspektion entdeckt werden und dies wiederum setzt voraus, dass Designs einfach und klein sind. Designs müssen so beschaffen sein, dass sie abgeschlossene Bereiche enthalten, über die konkrete und sichere Aussagen über Zugriffsmöglichkeiten und Effekte getroffen werden können.*" [^sicheresysteme_93]


###Default-is-deny
Ob eine Person oder ein Programm Zugriff auf Daten und Funktionen hat, sollte nicht durch Verbote, sondern durch eine explizite Erlaubnis geregelt werden. Dies bedeutet, dass solange keine explizite Erlaubnis gesetzt ist, kann das Programm oder die Person nicht auf die Daten oder Funktionen zugreifen. You *deny* it. So simpel und logisch diese Idee klingt, umso verwunderlicher ist es, dass viele Organisationen und Entwickler dieses Vorgehen nicht anwenden. Zum Beispiel Filesysteme setzen auf Verbote anstatt auf explizite Erlaubnisse.[^sicheresysteme_94] [^defaultdeny]

\newpage 

###Open Design
Abgeleitet von der Theorie der Kryptografie gilt Folgendes: Nicht das Design der Software sollte die Sicherheit sein, sondern der verwendete Schlüssel. Dieses Konzept gilt es in der Softwareentwicklung und Systemtechnik nur bedingt einzuhalten. Die Software soll eher nach dem Ansatz entworfen werden: Mindestens intern soll das Software-Design durch einen Design-Review Prozess analysiert werden. In manchen Fällen macht es jedoch Sinn, das Softwaredesign geheimzuhalten, um einem Angreifer nicht zu viele Informationen zur Verfügung zu stellen.
[^sicheresysteme_95]


###Zusammenfassung der Sicherheitsprinzipien
Die Sicherheitsprinzipien sind folgend gekürzt zusammen gefasst:

* Die Software muss aus kleinen, isolierten Einheiten aufgebaut werden, deren externe
Beziehungen am Interface deutlich werden. Damit werden sowohl praktische
Schadensreduzierung durch Isolation als auch eine schnelle und einfache Sicherheitsanalyse
möglich.
* Zugriffsentscheidungen dürfen nur auf der Basis expliziter, minimaler und
keinesfalls durch immer und global verfügbare Permissions fallen.
* Das Softwaredesign von Applikationen sollte wenn möglich öffentlich sein. Zumindest sollte
ein interner Review-Prozess stattfinden, in dessen Verlauf eine Sicherheitsanalyse
durch nicht an der Entwicklung Beteiligte erstellt wird.


[^sicheresysteme_93]: [@sicheresysteme pp.93]
[^sicheresysteme_94]: [@sicheresysteme pp.94]
[^sicheresysteme_95]: [@sicheresysteme pp.95]
[^apachekiss]: [@apachekiss]
[^defaultdeny]: [@defaultdeny]


\newpage 

##Martkanalyse
Dieses Unterkapitel erläutert existierenden Produkte auf dem Markt.

###OAuth-Provider

OAuth ist ein Protokoll. Es erlaubt sichere API-Autorisierungen.

####Das Bedürfnis nach OAuth
2006 implementierte Blaine Cook OpenID für Twitter. Ma.gnolia [^magnolia] erhielt dabei ein Dashboard, welches sich durch OpenID autorisieren liess. Deshalb suchten die Entwickler von Ma.gnolia und Blaine Cook eine Möglichkeit, OpenID auch für die Verwendung von APIs zu gebrauchen. Sie diskutierten verschiedene Implementierungen und stellten fest, dass es keinen offenen Standart für API-Access Delegation gab. So fingen sie an, einen Standard zu entwickeln. 2007 entstand daraus eine Google Group. Am 3. October 2007 war dann der OAuth Core 1.0 bereits veröffentlicht worden.

####Funktionalität von OAuth
Ein Programm/API (Consumer) stellt über das OAuth-Protokoll einem Endbenutzer(User) Zugriff (Autorisierung) auf seine Daten/Funktionalitäten zur Verfügung. Dieser Zugriff wird von einem anderen Programm (Service) gemanagt.
Das Konzept ist nicht generell neu. OAuth ist ähnlich zu Google AuthSub, aol OpenAuth, Yahoo BBAuth, Upcoming api, Flickr api, Amazon Web Services api. OAuth studierte die existierenden Protokolle und standardisierte und kombinierte die existierenden industriellen Protokolle. Der wichtigste Unterschied zu den existierenden Protokollen ist, dass OAuth sowohl offen ist als es auch geschafft hat, genügend Einsatzgebiete zu finden, um als Standard zu gelten.
Jeden Tag entstehen neue Webseiten, welche neue Funktionalitäten und Services offerieren und dabei Funktionalitäten von anderen Webseiten brauchen. OAuth stellt dem Programmierer einerseits eine standardisierte Implementierung zur Verfügung. Anderseites erhält der Endbenutzer dank dieses Protokolls die Möglichkeit, Teile seiner Funktionalität oder Daten bei einem anderen Anbieter zur Verfügung zu stellen. Bei Facebook OAuth kann der Endbenutzer zum Beispiel seine Posts zur Verfügung stellen, nicht aber seine Freunde bekannt geben.

Dank der weiten Verbreitung gibt es nun in allen bekannten Programmiersprachen eine Implementierung, sowohl von Client wie auch vom Server. Weitere Infos dazu unter oauth.net[1]

[1]: http://oauth.net/2/

\newpage 

Die grössten [OAuth]-Provider wie Google, Facebook und Twitter erziehlen eine weite Verbreitung weltweit. Ganze *78%* [@goldbachsocial] der Schweizer Bevölkerung nutzten SocialMedia und besitzen dadurch einen OAuth-Account.

![Aktive Nutzer weltweit und in der Schweiz [^socialmediaweltweit]](images/excel-statistik/socialmedia-aktivenutzer.png)



[^socialmediaweltweit]: Die Statistik der aktiven Nutzer weltweit wurde basierend auf den Daten von SocialMedia-Institute [@smi]erstellt. Facebook- und Twitter-Daten sind am 5. November 2015 und die Google-Daten im 2014 erhoben worden.
Die Statistik der aktiven Nutzer in der Schweiz wurde basierend auf den Daten von Goldbach Interactive [@goldbachsocial] generiert. Die Daten sind im März 2015 erhoben worden.
[^magnolia]: Ma.gnolia ist eine Lesezeichen-Webseite auf der User Lesezeichen bis 2009 bewerten und auch privat verwalten konnten.

####Vorteil
Mindestes 78% der Schweizer Bevölkerung besitzt bereits einen OAuth Account. Das Protokoll ist ein etablierter Standard.

####Nachteil
Mehrfachregistrierungen sind möglich. Jenach OAuth-Provider werden verschiedene Daten zur Verfügung gestellt. Pro OAuth Provider kann man sich registrieren. Ein Abgleich der verschiedenen OAuth Provider wird vom [OAuth]-Protokoll nicht zur Verfügung gestellt. Ein Teil der Bevölkerung müsste sich vor Nutzung noch registrieren. Die Implementierung ist trotz vielen Libraries nicht ohne höhere Programmierkenntnisse möglich.

\newpage

###playbuzz.com
Youtube von Google ist im Jahr 2015 mit Abstand die meist verbreiteste Videopublishing-Plattform[^statista]. Medienhäuser nutzen Youtube, um ihren Artikel einfach mit einem Video zu ergänzen. Neben der einfachen Integration profitieren die Medienhäuser von der zusätzlichen Verbreitung über youtube.com und der einfachen viralen Verbreitungsmöglichkeiten von youtube. PlayBuzz möchte das Youtube für Votings, Quiz und ähnlicher Embeded Content werden. Neben MTV, Focus, Time oder Bild verwendet seit Herbst 2015 auch ein grosses Medienhaus der Schweiz die Plattform. Tamedia erfasst neuerdings immer wieder auf 20minuten Votings und Umfragen mit PlayBuzz.

2012 wurde Playbuzz von Shaul Olmert (Sohn des Premier Ministers von Israel *Ehuad Olmert*) und Tom Pachys ins Leben gerufen. Der offizielle Launch war im Dezember 2013. Im Juni 2014 wurde Playbuzz bereits das 1. Mal unter den Top 10 Facebook Shared Publishers aufgelistet. Im Juni 2014 konnte Playbuzz bereits 70 Millionen unique views aufweisen. Im September 2014 kamen sieben von den zehn Top Shares auf Facebook laut forbes.com von Playbuzz. Playbuzz setzt nach eigenen Angaben auf Content wie Votes und Quizes, welche gerne viral geteilt werden, und ermöglicht Endnutzern und Redakteuren eine einfache Verwendung. [^t3nplaybuzz] [^playbuzz]

####Vorteile
Playbuzz ist kostenlos und lässt sich einfach integrieren. Durch Verwendung von Playbuzz kann die Verbreitung des eigenen Inhalts gesteigert werden. Die Verwaltungsoberfläche und die Reports sind übersichtlich und einfach zu bedienen.

####Nachteile
Der Verweis auf Playbuzz ist immer klar ersichtlich. Auch beim Veröffentlichen auf den SocialMedia-Kanälen ist die Herkunft von Playbuzz offensichtlich. Die Möglichkeiten in Funktionalität und Design sind eher begrenzt. Individuelle Erweiterungen sind nicht einfach möglich. Bestehende Interaktivitäten, solche die nicht von PlayBuzz erstellt werden, können nicht verwendet werden. Mehrfachteilnahmen waren ebenfalls möglich.

[^statista]: [@statista]
[^t3nplaybuzz]: [@t3nplaybuzz] 
[^playbuzz]: [@playbuzz]

\newpage

###WebSMS.com Zwei-Faktor-Authentifizierung
WebSMS.com bietet eine Zwei-Faktor-Authentifizierung über SMS an. Der User gibt seine Mobilnummer in der Webmaske der Schnittstelle ein und erhält einen Code, welcher der User danach in der Webschnittstelle eingibt. Dadurch kann sichergestellt werden, dass der User zur eingegebenen Mobilenummer passt. Der Service kostet monatlich 20 CHF und weitere 0.08 CHF pro SMS. [^websmskosten]

Die Stärke und Sicherheit dieses Services ist direkt mit dem Umgang von Mobilenummern/SIM-Karten und dessen Authentifizierung verbunden.

Seit 1. Juli 2004 müssen auch bei Prepaid-Karten in der Schweiz Personalien hinterlegt werden.[^uvek] Dadurch ist eine eindeutige Authentifizierung über Mobilennummern gewährleistet. Die Mobilfunkanbieter schränken die Anzahl SIM-Karten auf maximal fünf pro Person ein. Dieses Maximum konnte aber auf den Webseiten der Anbieter nicht direkt gefunden werden. Daher galt es den Wert zu untersuchen und mögliche Abweichungen ausfindig zu machen.

####Swisscom
Die Swisscom hat kein öffentlich zugängliches Dokument, welches die maximale Anzahl SIM-Karten pro Person beschreibt. Mündlich durch das Verkaufspersonal des Swisscom-Shops Zürich HB im Dezember 2015 und im Chatprotokoll [^swisscom_chat] wurde der Wert bestätigt. Es wurde darauf hingewiesen, dass kein Dokument mit dieser Zahl vorhanden ist.
 \
__Selbstversuch__ \
Es wurde versucht, bei zwei unabhängigen Handyanbietern mehr als fünf Swisscom-Prepaid-Abos abzuschliessen. Dabei wurde von Thomas Bachmann über vier Wochen verteilt bei dem Anbieter Interdiscount im Manor Winterthur bei unterschiedlichen Verkäufern ein Prepaidhandy gekauft. Beim Einkauf des sechsten Handys wurde der Verkauf durch die Kasse abgelehnt. Die Fehlermeldung der Kasse beinhaltete den Hinweis, dass die Nummer nicht erneut auf den Kunden registriert werden könne, da er schon fünf SIM Karten bei der Swisscom besitze.
Christian Bachmann kaufte über zwei Wochen verteilt bei dem Anbieter Migros Electronics in der Migros Limmat, Interdiscount im Manor Winterthur, Interdiscount im Zürich HB bei unterschiedlichen Verkäufer ein Swisscom Prepaidhandy. Der Einkauf des sechsten Handys wurde ebenfalls durch die Kasse abgelehnt. Die Nummer liess sich nicht erneut auf den Kunden registrieren, da er schon fünf SIM Karten bei der Swisscom besass.

####Sunrise
Die Sunrise hat nach Rücksprache ein PDF mit ihren Bestell- und Lieferbedingungen zugesendet.[^sunrise_lieferbedienungen] Die maximale Anzahl SIM-Karten ist in diesen Bestell- und Lieferbedingungen festgelegt. Auch die Sunrise hat das Maximum auf fünf SIM-Karten pro Person festgelegt.

####SALT
Bei der Firma SALT konnte mir ebenfalls kein Dokument mit einer Kennzahl gegeben werden. SALT vergibt gemäss ihrer schriftlichen Auskunft [^salt_email] pro Person maxmal drei SIM Karten.


####Vorteile
Die mehrfache Registrierung ist auf maximal fünf SIM-Karten/Rufnummern beschränkt. Durch die Kosten für eine SIM-Karte/Mobilenummer wird der Wert zusätzlich gemindert. Bei Missbrauch kann der User eindeutig identifiziert werden und eine Automatisierung ist nahezu unmöglich.

####Nachteile
Der Versand von SMS verursacht Kosten. Die Implementation bedarf spezifisches technisches Know-How.

[^websmskosten]: Die Kosten sind am 28. Dezember 2015 unter folgendem Link abgerufen worden: \ https://websms.ch/preise#at-preisuebersicht 
[^swisscom_chat]: Chat-Protokoll Swisscom 12.Februar 2016 http://bit.ly/swisscom-chat
[^salt_email]: E-Mail von Salt 13.Februar 2016 http://bit.ly/salt-email
[^sunrise_lieferbedienungen]: Kopie Bestell- und Lieferbedingungen http://bit.ly/sunrise-bedienungen
[^uvek]: Meldung des UVEKS über Gesetzesänderung: [@uvek]


###SuisseID
Die SuisseID schafft die rechtlichen und technischen Voraussetzungen für den elektronischen Geschäftsverkehr. Als digitaler Identitätsausweis im Internet bietet sie ihren Anwenderinnen und Anwendern eine sichere Authentifikation zu Web-Applikationen, eindeutige Identifikation für Internet-Dienste und digitales, rechtsgültiges Signieren von Dokumenten.
Der Erwerb einer solchen SuisseID kostet den Endkunden eine beträchtliche Summe Geld. Den Anbieter der Authentifizierung erwarten keine grossen Kosten. Dadurch ist eine kleine Verbreitung für den privaten Nutzen offensichtlich. Entwickler von Integrationen erhalten eine umfangreiches SDK und Kontaktmöglichkeiten.

####Vorteile
Hohe Sicherheit durch sichere und eindeutige Authentifikation ist gewährleistet. Rechtliche Vorraussetzungen sind gegeben. Enwickler von Integrationen werden unterstützt.

####Nachteile
Kleine Verbreitung und hohe Kosten für den Endnutzer sind die Nachteile von SuisseID.


##Findings
Auf dem Markt sind verschiedene Anbieter, welche Interaktivitäten schützen können oder gar ganze Packages anbieten. Ein Service, welcher es erlaubt individuell konfigurierbare Sicherheitsstufen festzulegen und diese in eine bestehende Interaktivität einzubauen, wurde nicht gefunden. Einige Anbieter könnten als einzelne Sicherheitsstufe in der Umsetzung berücksichtigt werden. [^stand20160108]



## Authentifizierungs-Komponenten
Die Authentifizierung kann mit verschiedenen Komponenten durchgeführt werden. Folgend gilt es, die Komponenten zu erklären.

###Cookie
Ein Cookie ist ein kurzes Text-Snippet, welches beim Besuch einer Webseite an den Browser gesendet wird. Dabei kann das Cookie serverseitig vom Webserver an den Browser gesendet werden oder in einem Skript wie Javascript erstellt werden. Der Browser sendet das Cookie bei jeder Aufforderung wieder der Webseite zu. 
Der Erfinder der Cookie-Technologie ist Vita Lou Montulli, der 1994 nach seinem Studienabbruch bei Netscape einstieg und zudem den Navigator mitentwickelte.
Der Betreiber der Interaktivität speichert also im Cookie die Teilnahme. Beim erneuten Aufruf erhält er das Cookie und weiss so, dass der Teilnehmer schon einmal teilgenommen hat oder nicht. 
Das Absichern von Interaktivitäten durch Cookies ist weit verbreitet. Durch die browserseitige/clientseitige Speicherung kann diese Speicherung auch clientseitig relativ einfach manipuliert werden.  [^google-cookies]

####Automatisierungsmöglichkeit und Mehrfachteilnahme
Die Automatisierung ist ohne IT-Know-How möglich. Es stehen einige Browser Plugins zur Verfügung, welche es ermöglichen, sein Surfverhalten über einfache Record-Funktionen aufzunehmen und danach Cookies zu löschen. So kann mehrfach an einer Interaktivität wie z.B. Umfragen teilgenommen werden.

####Kosten
Cookies verursachen keine direkten Kosten.

###Flash-Cookies
Ein Flash-Cookie ist, wie es der Name bereits vermuten lässt, ein Cookie, das an den Adobe-Flash Player gebunden ist. Da der Flash-Player im Betriebsystem installiert wird, funktionieren die Flash-Cookies browserunabhängig. Die Bedienungen dieser Flash-Cookies werden von Adobe festgelegt und der Browser kann nicht direkt in das Handling eingreifen. Auch hier wird die Speicherung clientseitig durchgeführt und es kann auch diese Speicherung clientseitig manipuliert werden.
Seit Steve Jobs mit Apple keinen Support für die mobilen Geräte in Aussicht stellte und auf die Probleme und Risiken hinwies, verliert die Plattform durch immer wieder auftretende Sicherheitsprobleme User. So haben am 1. Januar 2016 noch knapp 10%[^flashussage] aller Webseitenbesucher den Flash-Player installiert. 

[^flashussage]:[@flashussage]

####Mehrfachteilnahme
Flash-Cookies können je nach Betriebsystem mit verschiedenem Aufwand gelöscht werden und dadurch ist eine Mehrfach-Teilnahme möglich.

####Automatisierungsmöglichkeit
Die automatisierte Teilnahme und Löschung ist im Gegensatz zu klassischen Cookies aufwendiger, aber durchaus machbar.

####Kosten
Flash-Cookies verursachen keine direkten Kosten.

###IP-Adresse
Bei der Nutzung einer Interaktivität wird die IP-Adresse des Teilnehmers gespeichert. So kann bei erneutem Teilnehmen die Teilnahme verweigert werden.
Das Internetprotokoll, kurz "IP", sieht für jedes Gerät, welches an einem IP-Netzwerk angeschlossen ist, eine eindeutige Adresse vor. Generell wird im Internet über den "IP Version 4 Standart" kommuniziert. Damit lassen sich aber nur 4,22 Milliarden eindeutige Adressen im World Wide Web vergeben. Deshalb mussten einige Methoden entwickelt werden um vorerst das Problem umgehen zu können. Unter anderem identifiziert sich ein Router wie ein Rechner, und nutzt intern mittels sub-netting andere IP-Adressen. Gegen aussen haben also alle Nutzer des Netzwerks die selbe IP-Adresse. Dadurch entsteht die Problematik an dieser Methode, dass in einem Grossraumbüro mit einem Internetanschluss auch nur eine Person an einem Wettbewerb teilnehmen kann.[^pclexikon-ip]


####Mehrfachteilnahme
Es gibt verschiedene Möglichkeiten, die IP-Adresse zu wechseln. Eine einfache Möglichkeit ist durch Verwenden von Proxy-Servern eine andere IP-Adresse zu benutzen. Die Mehrfachteilnahme ist also einfach möglich.

####Automatisierungsmöglichkeit
Das automatisierte Wechseln eines Proxys ist etwas aufwendiger und braucht technisches Know-How aber durchaus möglich.

####Kosten
Das Authentifzieren via IP-Adresse verursacht keine direkten Kosten.




[^google-cookies]: [@google-cookies]
[^pclexikon-ip]: [@pclexikon-ip]]

\newpage

###Ausweisnummer: Schweizer Pass oder Identitätskarte
Die Schweiz führt für ihre Bürger zwei Ausweisarten: Den Schweizer Pass und die Identitätskarte. Diese dienen zum Nachweis der Schweizer Staatsangehörigkeit und der Identität. In der Schweiz besteht weder eine Ausweispflicht noch eine Mitführpflicht, niemand muss eine Identitätskarte oder einen Pass besitzen oder gar bei sich tragen.
Auf der Rückseite der Identitätskarte oder auf der ersten Innenseite des Passes befindet sich im unteren Bereich eine maschinenlesbare Zone, welche auch von Menschen gelesen werden kann. Die verschiedenen Bereiche werden in der folgenden Abbildung beschrieben. Die orange umrandeten Zahlen sind jeweils Checksummen. Der orange Bereich ist die Gesamtchecksumme.

![Beispiel der maschinenlesbaren Zone einer Identitätskarte und eines Passes](images/ausweis.png)

####Checksummenberechnung
Die Checksummenberechnung funktioniert wie folgt:

1. Stelle wird mit 7 multipliziert,
2. Stelle wird mit 3 multipliziert,
3. Stelle wird mit 1 multipliziert,
4. Stelle wird wieder mit 7 multipliziert, usw.

Alle diese Produkte werden dann summiert und daraus Modulo 10 berechnet. \
Bemerkung: Buchstaben werden in Zahlen umgewandelt. Dabei wird die Position des Alphabets beginnend ab 0 gezählt. Also A=0, B=1, C=2 und so weiter. Das Zeichen "<" wird in eine 0 umgewandelt.



~~~~~~~
Beispiel: „C1234567<“ => „212345670“
2 × 7 =	14
1 × 3 =	3 
2 × 1 =	2
3 × 7 =	21
4 × 3 =	12
5 × 1 =	5
6 × 7 =	42
7 × 3 =	21
0 × 1 =	0
Summe = 120
120 mod 10 = 0
~~~~~~~

\newpage
Es gibt aus Datenschutzgründen keinen öffentlichen Service, über welchen man die Identität anhand der Passangaben überprüfen könnte. So besteht nur die Möglichkeit zu überprüfen, ob das eingegebene Muster anhand der Checksummen stimmt und ob bereits dieselben Informationen vorhanden sind.

####Mehrfachteilnahme und Automatisierungsmöglichkeit
Der Algorithmus der Checksummen kann nachgebaut werden und so können automatisiert Identitätskarten generiert werden. Dadurch kann mehrfach und automatisiert an der Aktivität teilgenommen werden werden.

####Kosten
Die Überprüfung verursacht keine direkten Kosten. [^ausweis1] [^ausweis2]

[^ausweis1]:[@ausweis1]
[^ausweis2]:[@ausweis2]

\newpage

###Captcha
Captcha ist ein Test, mit dem festgestellt werden kann, ob sich ein Mensch oder ein Computer eines Programms bedient [^duden].

Im Jahr 2000 wurde das Captcha an der Carnegie Mellon University erfunden. Captcha steht für **C**ompletely **A**utomated **P**ublic **T**uring test to tell **C**omputers and **H**umans **A**part. Luis von Ahn, Professor der Entwickler-Gruppe, erklärte die Dringlichkeit von Captcha damals so: "Anybody can write a program to sign up for millions of accounts, and the idea was to prevent that".[^captcha]

####Captcha Zahlen
In 2014 wurden 200 Millionen Captchas  pro Tag eingegeben. Dabei braucht ein User durchschnittlich 10 Sekunden. Das entspricht 500'000 Stunden.[^statisticinfo]

![Beispiele von Captchas *Quelle:drupal.org*](images/captcha.png)

####Automatisierungsmöglichkeit
Die Automatisierung wird unterbunden.

####Mehrfachteilnahme
Eine manuelle Mehrfachteilnahme ist möglich.

####Kosten
Es entstehen keine direkten Kosten.


[^duden]: [@duden]
[^captcha]: [@captcha]

[^statisticinfo]: Die statistischen Daten wurden von Google 2014 in ihrem Blog publiziert [@googlecaptcha]

###Zwei-Faktor-Authentifizierung
Die Zwei-Faktor-Authentifizierung wird häufig 2FA genannt. Der User wird mittels zweier unabhängiger Faktoren identifiziert. Der Begriff "Faktor" umschreibt dabei eine Komponente oder Authentifizierungsmethode. [^cnet-2fa]

Die Zwei-Faktor-Authentifizierung ist in der Schweiz durch das E-Banking bekannt geworden. Der User gibt als ersten Faktor Username/Vertragnummer und Passwort ein. In einem zweiten Schritt gibt er vom System gewünschten Code aus der Codekarte oder des elektrischen Rechners als zweiten Faktor ein. 
Im Alltag bei einem Einkauf im Detailhandel authentifiziert sich der EC-Kartenchip als erster Faktor. Als zweiter Faktor hat sich der Kunde einen PIN-Code auswendig gemerkt, welchen er eingibt.

Die folgenden Authenfizierungen basieren auf den Prinzip der Zwei-Faktor-Authentifizierung.

###E-Mail-Bestätigungscode
Im Registrationsprozess ist das Erhalten eines E-Mails mit Bestätigungscode quasi zum Standart geworden. Durch diese Methodik kann man garantieren, dass die angegebene E-Mail Adresse auch tatsächlich existiert und der User darauf Zugriff hat. Der User soll also auch bei der Authentifizierungsschnittstelle seine E-Mail Adresse eintragen und erhält dann umgehend den Bestätigungslink an diese zugesandt.

####Automatisierungsmöglichkeit
Das automatische Auslesen von E-Mails ist möglich. Jedoch ist der Aufwand dafür sehr hoch.

####Mehrfachteilnahme
Ein User kann verschiedene E-Mail Adressen besitzen. Das Erstellen von neuen E-Mail Adressen ist mit Aufwand verbunden, aber einfach möglich.

Anbieter wie 10-Minutes Mail [^10minutemail] stellen auf Knopfdruck für einige Minuten eine temporäre E-Mail Adresse zur Verfügung. Dadurch können schnell einige E-Mail Adressen erstellt werden. 
Diese Domains müssen über eine aufwendige Blacklist gefiltert werden oder durch ein zeitversetztes Bestätigungsmail ausgehebelt werden.

####Kosten
Bei der Annahme, dass jedes Unternehmen bereits ein E-Mail Server oder ein E-Mail Konto bei einem kostenlosen Anbieter besitzt, verursacht das Versenden von E-Mails über einen SMTP-Server ist generell keine zusätzlichen Kosten. Bei hohem Gebrauch dieser Komponente lohnt es sich, die E-Mails über eine professionelle Infrastruktur für Massenversendungen zu versenden und zu analysieren. Dadurch können weitere Kosten enstehen. Beispiele dafür sind Mailchimp [^mailchimp] oder Sendgrid. [^sendgrid]


###SMS- Bestätigungscode
Das Konzept des in einem vorherigen Kapitel erwähnten Anbieters WebSMS soll von der Authentifizierungsschnittstelle ebenfalls implementiert werden. Der User gibt im ersten Schritt seine Mobilenummer ein. Er erhält dann einen Code per SMS zugesandt. Im zweiten Schritt gibt der User den erhaltenen Mobilecode im Webform ein und bestätigt so, dass ihm die Mobilenummer gehört.
Zum Versenden der SMS ist ein SMS-Gateway nötig.

<!--TODO- Gateway-->

####Automatisierungsmöglichkeit
Die Automatisierung kann als nicht möglich eingestuft werden.

####Mehrfachteilnahme
Die mehrfache Teilnahme wurde bereits im Kapitel zum Anbieter WebSMS eingehenden behandelt. Daraus resultierte, dass in der Schweiz maximal fünf Mobilenummern pro Anbieter und Person bezogen werden können.

####Kosten
Je nach SMS-Gateway, Mobileanbieter des Empfängers und Verwendungsintensität belaufen sich der Versand eines SMS zwischen 0.04 CHF und 0.15 CHF. [^smspreise]


###Telefonanruf mit Bestätigungscode
Nach Eingabe der Telefonnummer oder Mobilenummer erhält der User einen digitalen Anruf. Die Computerstimme liest dem User einen Code vor, welcher er danach in der Webpage eingibt.

####Automatisierungsmöglichkeit
Die Automatisierung kann als nicht möglich eingestuft werden.

####Mehrfach Teilnahme
Die Teilnahmeanzahl ist von den vorhandenen Telefonanschlüssen abhängig und daher nur eingeschrenkt möglich.

####Kosten
Die Kosten berechnen sich bei den analysierten Anbietern basierend auf einer geringen Monatspauschale zwischen CHF 1.00 und CHF 2.00 und Kosten pro Minute je nach Telefonanbietern des Empfängers und Voicegateway zwischen CHF 0.10 und CHF 0.65.[^voiceprice].



###Postversand
Im Telefonbuch digital oder analog waren früher fast alle Personen erfasst. Immer weniger Personen haben heute einen Fixanschluss und einige lassen ihr Nummern nicht mehr eintragen. Nur vereinzelte Personen tragen ihre mobile Telefonnummer und Adresse im Telefonbuch ein.
Google steht vor dem gleichen Problem mit ihrem Produkt Google Maps. In Google Maps sollen schnell neue Firmendaten, Veranstaltungslocations oder andere Adresseinträge erfasst werden können. Doch sollen Betrüger oder Spassvögel daran gehindert werden, Falscheinträge zu machen. Daher versendet Google zur Verifikation einfach einen Code per Brief bzw.Postkarte an die Adresse.[^googlebusiness]
Dieses simple Konzept kann auch für die Authentifizierungsschnittstelle umsetzt werden, um die Adresse eindeutig zu verifizieren. Einen Haken hat dieses Konzept jedoch. Jemand muss den Brief ausdrucken, in ein Couvert legen, frankieren und per Post versenden. Dies kann als Service, z.B. beim Schweizer Startup pingen.com eingekauft werden. 

####Automatisierungsmöglichkeit
Die Automatisierung kann als nicht möglich eingestuft werden.

####Mehrfachteilnahme
Die Teilnahmeanzahl ist von den vorhandenen Adressanschriften abhängig und daher ist eine Mehrfachteilnahme nur eingschränkt möglich.

####Kosten
Die Kosten berechnen sich für den Versand in der Schweiz bei den analysierten Anbietern je nach Druck und Versandart des Empfängers zwischen CHF 1.20 und CHF 1.65.[^pingen]

\newpage
###OAuth
Die Zwei-Faktor-Authentifizierung OAuth wurde im Kapitel [OAuth-Provider] ausführlich erläutert.

####Automatisierungsmöglichkeit
Eine OAuth-Registrierung kann als nicht automatisierbar eingestuft werden. Automatisierbares Anmelden und Verwenden von verschiedenen Accounts ist durchaus möglich. Plattformen wie kingfluencers.ch zeigen Möglichkeiten auf, wie automatisiert auf SocialMedia Plattformen von Dritten zugegriffen werden kann und Tätigkeiten ausgeführt werden können.

####Mehrfachteilnahme
Eine Mehrfachregistration ist möglich.

####Kosten
OAuth bewirkt keine direkten Kosten.



###SuisseID Integration
SuisseID wurde bereits im Kapitel [SuisseID] erläutert. 


####Automatisierungsmöglichkeit
Eine Automatisierung ist nahezu unmöglich.

####Mehrfachteilnahme
Eine Mehrfachteilnahme ist nahezu unmöglich.

####Kosten
Für den Betreiber fallen geringe Kosten an. Der Endnutzer zahlt aber einen relativ hohen Preis.

\newpage

###Browser Fingerprints

Der Fingerabdruck ist aus der Kriminaltechnik nicht mehr wegzudenken. Bereits vor 2000 Jahren haben Chinesen ihre Schuldscheine mit Fingerabdrücken unterzeichnet. Es sollten über 19 Jahrhunderte vergehen, bis der Fingerabdruck auch in der Kriminaltechnik eingesetzt wurde. Seit über 100 Jahren, genauer seit 1913, ist der Fingerabdruck auch im Dienst der Schweizer Eidgenossenschaft. 
Im Gegensatz zur DNA unterscheidet sich der Fingerabdruck bei Zwillingen klar, auch wenn ähnliche Merkmale erkennbar sind. Bereits nach nur vier Monaten Schwangerschaft sind die Muster der Papillarleisten beim Embryo festgelegt. Der einzigartige Fingerabdruck des Menschen ist bereits dann fertig gestellt. Dieses Muster ändert sich bis zur Auflösung des Körpers nach dem Tod nicht mehr. [^derfingerabdruck]

![Fingerabdruck: Mit Kohlepulver werden Fingerabdrücke sichtbar gemacht und auf Klebefolie gesichert. *Quelle:phi-hannover.de*](images/fingerabdruck.jpg)

Der Fingerabdruck eignet sich zur Authentifizierung einer Person durch folgende Merkmale:

- Der Fingerabdruck ist eindeutig.
- Der Fingerabdruck ist über den Tod hinaus beständig.
- Der Fingerabdruck ist von aussen einfach "abrufbar". Er ist von blossem Auge sichtbar und wir hinterlassen das Muster der Papillarleisten auf Gegenständen wie Gläsern.



####Fingerabdruck des Browsers
Im Gegensatz zum Datenschutz wäre es aus Sicht der eindeutigen Identifikation wünschenswert, wenn digitale Personen oder deren Geräte auch einen Fingerabdruck von sich geben würden, der sowohl eindeutig, beständig als auch abrufbar ist. Immer wieder versuchten unter dem Thema "Hardware Fingerprint" oder "Browser Fingerprint" Personen und Organisationen ein Verfahren zu entwickeln, das genau dies ermöglicht.
Microsoft führte laut eigenen Angaben [^xpactivation] mit Windows XP Produktaktivierung ein Verfahren ein, das aus Prozesser-Typ, Grafikkarteninformationen und Festplatte einen Fingerabdruck des Geräts erstellt. So konnte bei einer zweiten Aktivierung mit dem selben Registrationsschlüssel Massnahmen getroffen werden.

Auch der Browser übermittelt an den Server verschiedene Informationen:

\newpage
####Passives Fingerprinting
Die Kommunikation zwischen Client und Browser ist paketbasiert. Es besteht keine feste Leitung zwischen Client und Server. Ausserdem ist der Kommunikationsweg nicht zwingend gleich bleibend. Jedes HTTP-Paket besitzt Header-Daten aus den verschiedenen OSI-Layern. So können aus IP-Header, TCP-Header und HTTP-Header unter anderem folgende Daten gelesen werden: 

---------------------------------------------------------------
Bezeichnung 										Schicht
--------------------------------------------------- -----------
Quell-IP-Adresse 									IP

Quellport 											TCP

Aufrufende Seite 					 				HTTP

Bezeichnung des Browsers („User-Agent“) 			HTTP

Akzeptierende Dateitypen 							HTTP

Akzeptierende Zeichensätze 							HTTP

Akzeptierende Kompressionsformate 					HTTP

Akzeptierende Sprachen 								HTTP
---------------------------------------------------------------
Table: Übersicht möglicher passiven Daten

Diese Daten werden zwingend an den Server gesendet und könnten passiv, also ohne dass ein zusätzliches "Programm" beim Client läuft, ausgelesen werden.



####Aktives Fingerprinting 
Beim aktiven Fingerprinting werden per Javascript mögliche Browserkennzahlen abgefragt. In der folgenden Tabelle sind die komplexeren Gewinnungen von Kennzahlen aufgelistet.  

---------------------------------------------------------------------------------------------------------------------------------------------------
Bezeichnung				Beschreibung	 						
----------------------- ---------------------------------------------------------------------------------------------------------------------------
__Browser-Plugins__		Die Funktionalität der Browser wird mit Browsererweiterungen ausgebaut. Bekannte Plugins: Adobe Reader, Adobe Flash \
						Abfrage: navigator.plugins
					
__Unterstütze 			Internetdokument können verschiedene Datenarten so genannte MIME-Type unterstützen. \
Datenarten__			Abfrage: navigator.mimeTypes

__Installierte			Mittels CSS kann geprüft werden welche Schriftarten beim Client installiert sind. Dabei wird probiert einen Katalog darzustellen. Die installierten Schriften können dargestellt werden.
Schriften__

__Performance			Basierend auf Javascript Performance-Tests kann unter Berücksichtigung der Implemenation von JavaScript im Browser die Performance des Rechners ermittelt werden.
Messung__
---------------------------------------------------------------------------------------------------------------------------------------------------
Table: Komplexere Kennzahlen aktives Fingerprinting

\newpage
Das aktive Fingerprinting kann vom Endbenutzer festgestellt werden, da Javascript-Code in seinem Browser ausgeführt werden. Noch offensichtlicher wird es, wenn nach der Analyse die Daten auch an den Server übertragen werden.

Eine Beispielimplementation von Browserfingerprints wurde umgesetzt: <http://www.christianbachmann.ch/minifingerprint/> [^tillmannfingerprint]





[^tillmannfingerprint]: Die kleine Testimplementation wurde basierend auf der Vorlage von Hennig Tillmann umgesetzt: [@tillmannfingerprint]
[^xpactivation]: [@xpactivation]
[^derfingerabdruck]: [@derfingerabdruck]
[^googlebusiness]: [@googlebusiness]
[^10minutemail]: 10-Minute Mail [@10minutemail]
[^mailchimp]: www.mailchimp.com
[^sendgrid]: sendgrid.com
[^smspreise]: Die Preise wurden am 1. März 2016 auf aspsms.ch/instruction/prices.asp, tropo.com/pricing und twilio.com/sms/pricing abgefragt
[^voiceprice]: Die Preise wurden am 1. März 2016 auf nexmo.com/products/voice/, tropo.com/pricing und twilio.com/voice/pricing abgefragt
[^pingen]: Die Preise wurdem am 10. März 2016 auf pingen.com abgefragt
[^cnet-2fa]: [@cnet-2fa]


