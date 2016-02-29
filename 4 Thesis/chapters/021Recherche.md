\newpage

#Recherche

## Fachbegriffe
Eine ausführliche Erklärung der Fachbegriffe befindet sich im Anhang unter dem Kapitel "[Glossar]".

## Erläuterung der Grundlagen
In diesem Kapitel werden Funktionsweisen und Grundlage ausgeführt, die als für die Bearbeitung dieser Bachelorthesis herangezogen wurden.

###Authentifizierung
Authentifizierung - beglaubigen, die Echtheit von etwas bezeugen [^duden]

Eine Person oder Objekt eindeutig zu **authentifizieren** bedeute zu ermitteln ob die oder derjenige auch der ist als welcher er sich ausgibt. [^authentifizierungsdef] Dies unterstreicht auch die Ableitung des Wortes vom Englischen Verb *authenicate*, was auf Deutsch sich als *echt erweisen, sich verbürgen, glaubwürdig sein* bedeutet.  Das bekannteste Verfahren der Authenfizierung ist die Eingabe von Benutzernamen und Passwort. Weiter ist die PIN-Eingabe bei Bankautomaten oder Mobiletelefon häufig verbreitet. Die Möglichkeiten der Authentifizierung nahe zu grenzenlos.
[^authentifizierungsdeforg]

###Autorisierung
Autorisierung - Befugnis, Berechtigung, Erlaubnis, Genehmigung [^duden]

Wenn die Authenfizierung[Authentifizierung] erfolgreich war erteilt das System die Autorisierung. Dabei wird der Person oder Objekt erlaubt bestimmte Aktionen/Zugriffe durchzuführen. Meist verfügen unterschiedliche Benutzer eines Systems über verschiedene Zugriffsrechte. Die korrekte Zuweisung der individuellen Rechte ist ebenfalls Bestandteil der Autorisierung.

Der Begriff Authentifizierung wird vielfach mit dem Begriff Autorisierung verwechselt. Die Authentifizierung wird vom Benutzer initiiert. Sie dient dem Nachweis, zur Ausübung bestimmter Rechte befugt zu sein. Die anschließende Autorisierung erfolgt automatisch durch das System selbst. Im Zuge der Autorisierung werden dem Benutzer seine Zugriffsrechte zugewiesen.
[@authentifizierungsdeforg]



[^authentifizierungsdef]: [@authentifizierungsdef] 
[^authentifizierungsdeforg]: [@authentifizierungsdeforg]



\newpage
###OAuth
OAuth ist ein Protokoll. Es erlaubt sichere API-Autorisierungen.

####Das Bedürfnis nach OAuth
2006 implementiere Blaine Cook OpenID für Twitter. Ma.gnolia erhielt dabei ein Dashboard welches sich durch OpenID autorisieren lies. Deshalb suchten die Entwickler von Ma.gnolia und Blaine Cook eine Möglichkeit OpenID auch für die Verwendung von APIs zu gebrauchen. Sie diskutierten Implementierungen und stellten fest, dass es keinen offenen Standart für API-Access Delegation gab. So fingen sie an den Standard zu entwickeln. 2007 entstand daraus eine Google Group. Am 3. October 2007 war dann der OAuth Core 1.0 bereits released worden.

####Funktionalität von OAuth
Ein Programm/API (Consumer) stellt über das OAuth-Protokoll einem Endbenutzer(User) Zugriff (Autorisierung) auf seine Daten/Funktionalitäten zur Verfügung. Dieser Zugriff wird von einem anderen Programm (Service) gemanagt.
Das Konzept ist nicht generell neu. OAuth ist ähnlich zu Google AuthSub, aol OpenAuth, Yahoo BBAuth, Upcoming api, Flickr api, Amazon Web Services api. OAuth studierte die existierenden Protokolle und standardisiert und kombinierte die existierende industriellen Protokolle. Der wichtigste Unterschied zu den existierenden Protokollen ist, das OAuth sowohl offen ist und es geschafft hat genügend Einsatzgebiete zu finden um als Standard zu gelten.
Jeden Tag entstehen neue Webseite welche neue Funktionalitäten und Services offerieren und dabei Funktionalitäten von anderen Webseiten brauchen. OAuth stellt dem Programmierer einerseits eine standardisierte Implementierung zur Verfügung. Anderseites erhält der Endbenutzer dank dieses Protokolls die Möglichkeit Teile seiner Funktionalität/Daten bei einem anderen Anbieter zur Verfügung zu stellen. Zum Beispiel bei Facebook OAuth kann der Endbenutzer seine Posts zur Verfügung stellen nicht aber seine Freunde bekannt geben.

Dank der weiten Verbreitung gibt es nun in allen bekannten Programmiersprachen eine Implementierung sowohl von Client wie auch vom Server. Weitere Infos dazu unter oauth.net[1]

[1]: http://oauth.net/2/

\newpage
## Ähnliche Produkte auf dem Markt
Dieses Unterkapitel erläutert existierenden Produkte auf dem Markt.

###OAuth-Provider
Die grössten [OAuth]-Provider wie Google, Facebook und Twitter erziehlen eine weiter Verbreitung weltweit:

![Aktive Nutzer Weltweit [^socialmediaweltweit]](images/excel-statistik/socialmedia-aktivenutzer.jpg)

Ganze *78%* [@goldbachsocial] der Schweizer Bevölkerung nutzten SocialMedia und besitzen dadurch einen OAuth-Account:

![Anzahl Schweizer Nutzer [^socialmediaschweiz]](images/excel-statistik/socialmedia-schweiz.jpg)


[^socialmediaweltweit]: Das Statistik wurde basierend auf den Daten von socialmedia-institute [@smi]erstellt. Facebook und Twitter Daten sind am 5. November 2015 und die Google Daten sind im 2014 erhoben worden.

[^socialmediaschweiz]: Das Statistik wurde basierend auf den Daten von Goldbach Interactive [@goldbachsocial] generiert. Die Daten sind im März 2015 erhoben.

\newpage
####Vorteile
Mindestes 78% der Schweizer Bevölkerung besitzt bereits einen OAuth Account. Das Protokoll ist ein etablierter Standard.

####Nachteile
Mehrfachregistrierungen sind möglich. Jenach OAuth-Provider werden verschiedene Daten zur Verfügung gestellt. Pro OAuth Provider kann man sich registrieren einen Abgleich der verschiedenen OAuth Provider wird vom [OAuth]-Protokoll nicht zur Verfügung gestellt. Ein Teil der Bevölkerung müsste sich vor Nutzung noch registrieren. Die Implementierung ist trotz vielen Libaries nicht ohne tiefere Programmierkenntnisse möglich.

\newpage

###playbuzz.com
Youtube von Google ist im Jahr 2015 mit Abstand die meist verbreiteste Videopublishing-Plattform[^statista]. Medienhäuser nutzen Youtube um einfach Ihren Artikel mit einem Video zu ergänzen. Neben der einfachen Integration profitieren die Medienhäuser von der zusätzlichen Verbreitung über youtube.com und der einfachen viralen Verbreitungsmöglichkeiten von youtube. PlayBuzz möchte das Youtube für Votings, Quiz und ähnlicher Embeded Content zu werden. Neben MTV, Focus, Time oder Bild verwendet seit Herbst 2015 auch ein grosses Medienhaus der Schweiz die Plattform. Tamedia erfasst neu auf 20minuten Votings und Umfragen mit PlayBuzz.

2012 wurde Playbuzz von Shaul Olmert (Sohn des Premie Minster von Israel Ehuad Olmert) und Tom Pachys ins Leben gerufen. Der offizielle Launch war im Dezember 2013. Im Juni 2014 wurde Playbuzz bereits das 1. Mal unter den Top 10 Facebook Shared Publishers aufgelistet. Im Juni 2014 konnte Playbuzz bereits 70 millionen unique views aufweisen. Im September 2014 kamen 7 von den 10 Top Shares auf Facebook laut forbes.com von Playbuzz. Playbuzz setzt nach eigenen Angaben auf Content wie Votes und Quizes welcher gerne Viral geteilt wird und ermöglicht Endnutzer und Redaketeueren einfache Verwendung. [^t3nplaybuzz] [^playbuzz]

####Vorteile
Playbuzz ist kostenlos und lässt sich einfach integrieren. Durch Verwendung von Playbuzz kann die Verbreitung des eigenen Inhalts gesteigert werden. Die Verwaltungsoberfläche und Reports sind übersichtlich und einfach zu bedienen.

####Nachteile
Der Verweis auf Playbuzz ist ersichtlich. Auch beim Posten auf den SocialMedia-Kanälen ist die Herkunft von Playbuzz offensichtlich. Die Möglichkeiten in Funktionalität und Design haben Grenzen. Individuelle Erweiterungen sind nicht einfach möglich.

[^statista]: [@statista]
[^t3nplaybuzz]: [@t3nplaybuzz] 
[^playbuzz]: [@playbuzz]

\newpage

###WebSMS.com Zwei-Faktor-Authentifizierung
WebSMS.com bittet eine Zwei-Faktor-Authentifizierung über SMS an. Der User gibt seine Mobilnummer in der Webmaske der Schnittstelle ein und erhält einen Code welcher der User danach in der Webschnittstelle eingibt. Dadurch kann sichergestellt werden dass der User zur eingegebenen Mobilenummer passt. Der Service kostet monatlich 20 CHF und weitere 0.08 CHF pro SMS [^websmskosten]

Die Stärke und Sicherheit dieses Service ist direkt mit mit dem Umgang von Mobilenummern/SIM-Karten und dessen Authentifizierung verbunden.

Seit 1. Juli 2004 müssen auch bei Prepaid-Karten in der Schweiz Personalien hinterlegt werden.[^uvek] Dadurch ist eine eindeutige Authentifizierung über Mobilennummer gewährleistet. Die Mobilefunkanbieter schrenken die Anzahl SIM-Karten auf maximal 5 pro Person ein. Dieses Maximum konnte aber auf den Webseiten der Anbieter nicht direkt gefunden werden. Daher galt es den Wert zu untersuchen und mögliche abweichungen ausfindig zu machen.

####Swisscom
Die Swisscom hat kein öffentlich zugängigliches Dokument welches die maximale Anzahl SIM-Karten pro Person beschreibt. Mündlich durch das Verkaufspersonal des Swisscom-Shops Zürich HB Dezember 2015 und im Chatprotokoll [^swisscom_chat] wurde der Wert bestätigt. Es  hingewiesen, dass nicht ein Dokument mit dieser Zahl vorhanden ist.

#####Selbstversuch
Es wurde versucht bei zwei unabhängigen Handyanbieter mehr als 5 Swisscom-Perpaid-Abos abzuschliessen. Dabei wurden von Thomas Bachmann über 4 Wochen verteilt bei dem Anbieter Interdiscount im Manor Winterthur bei verschiedenem Kaufspersonal ein Prepaidhandy eingekauft. Beim Einkauf des 6. Handys wurde der Verkauf von der Kasse abgelehnt. Die Fehlermeldung der Kasse beinhaltete den Hinweis, dass sich die Nummer nicht erneut auf den Kunden registrieren lassen kann, da er schon 5 SIM Karten bei der Swisscom besitzt.
Christian Bachmann kaufte über 2 Wochen verteilt bei dem Anbieter Migros Electronics in der Migros Limmat, Interdiscount im Manor Winterthur, Interdiscount im Zürich HB  bei verschiedenem Kaufspersonal ein Swisscom Prepaidhandy. Beim Einkauf des 6. Handys wurde der Verkauf von der Kasse abgelehnt. Die Nummer liess sich nicht erneut auf den Kunden registrieren, da er schon 5 SIM Karten bei der Swisscom besitzt.

####Sunrise
Die Sunrise hat nach Rücksprache ein PDF mit Ihren Bestell- und Lieferbedingunge zugesendet.[^sunrise_lieferbedienungen] Die maximale Anzahl SIM-Karten ist in diesen Bestell- und Lieferbedingungen festgelegt. Auch die Sunrise hat das Maximum auf 5 pro Person festgelegt.

####SALT
Bei der Die Firma SALT konnte mir ebenfalls kein Dokument mit der Kennzahl gegeben werden. SALT stellt vergibt ihrer schriftlichen Auskunft [^salt_email] pro Person maximum 3 SIM Karten.


####Vorteile
Die mehrfache Registrierung ist auf maximal 5 beschränkt. Durch die Kosten für eine SIM-Karte/Mobilenummer wird der Wert zusätzlich gemindert. Bei Missbrauch kann der User eindeutig identifiziert werden. Eine Automatisierung ist nahe zu unmöglich.

####Nachteile
Der Versand von SMS verursacht Kosten. Die Implementation bedarf hohes technisches Know-How.

[^websmskosten]: Die Kosten sind am 28. Dezember 2015 unter folgendem Link abgerufen worden: https://websms.ch/preise#at-preisuebersicht 
[^swisscom_chat]: Chat-Protokoll Swisscom 12.Februar 2016 http://bit.ly/swisscom-chat
[^salt_email]: E-Mail von Salt 13.Februar 2016 http://bit.ly/salt-email
[^sunrise_lieferbedienungen]: Kopie Bestell- und Lieferbedingungen http://bit.ly/sunrise-bedienungen
[^uvek]: Meldung des UVEKS über Gesetzesänderung: [@uvek]






\newpage
##Grundlegende Sicherheitsprinzipien
In diesem Unterkapitel werden die Grundlagen der Sicherheitsprinzipien vermittelt auf denen eine Authentifizierungssoftware aufgebaut werden kann.

###KISS
**K**eep **I**t **S**tupid *and* **S**imple

Ein verbreitetes Problem unter Software Engineers und Programmier heute ist, dass sie dazu tendiert wird, Probleme zu kompliziert und verschachtelt zu lösen. 8-9 von 10 Entwickeln machen den Fehler, Probleme zu wenig auseinander zu brechen und alles in einem grossen Programm zu lösen. Anstatt es in kleinen Paketen verständlich zu programmieren.[^apachekiss]


Die folgenden Punkte listen die Vorteile für Software Entwickler bei verwenden von Kiss auf:

- Mehr Probleme sollen schneller gelöst werden
- Der Entwickler kann komplexe Probleme in wenigen Zeilen Code lösen
- Die Codequalität steigt
- Der Entwickler kann grössere System erstellen und unterhalten
- Der Code wird flexibler werden, einfach wieder zu verwenden und zu modifizieren
- Die Zusammenarbeit in grösseren Entwicklerteams und Projekten wird vereinfacht da der Code bei allen "stupid simple" ist


####KISS fördert die Sicherheit
Die Begründung warum KISS die Sicherheit fördert, liefert Saltzer und Schroeder: Ungewollte Zugriffspfade können nur durch zeilenweise Codeinspektion entdeckt werden und die wiederum setzt voraus, dass
Designs einfach und klein sein sind. Designs müssen so beschaffen sein, dass sie abgeschlossene Bereiche enthalten, über die konkrete und sichere Aussagen über Zugriffsmöglichkeiten und Effekte getroffen werden können. [^sicheresysteme_93]


###Default-is-deny
Ob eine Person oder Programm Zugriff auf Daten/Funktionen haben, sollte nicht durch Verbote sondern durch explizite Erlaubnis geregelt werden. Dies bedeutet solange keine explizite Erlaubnis gesetzt ist, kann das Programm oder die Person nicht auf die Daten oder Funktionen zugreifen. You *deny* it. So simpel und logisch diese Idee klingt, umso verwunderlich ist wie viele Organisationen und Entwicklungsfirma nicht dieses vorgehen verwenden. z.B. Filesysteme setzten auf Verbote anstatt auf explizite Erlaubnise.[^sicheresysteme_94] [^defaultdeny]


###Open Design
Abgeleitet von der Kryprotografie: Nicht das Design der Software sollte die Sicherheit sein, sondern der verwendete Schlüssel. Dieses Konzept gilt es in der Softwareentwicklung und Systemtechnik nur bedingt einzuhalten. Die Software soll nach dem Ansatz entworfen werden. Mindestens intern soll das Software-Design durch einen Design-Review Prozess analysiert werden. In manchen Fällen macht es jedoch das Softwaredesign geheimzuhalten um einem Angreifer nicht zu viele Informationen zur Verfügung zu stellen.
[^sicheresysteme_95]


###Zusammenfassung der Sicherheitsprinzipien
Die wichtigsten Sicherheitsprinzipien zusammengefasst:

* Software muss aus kleinen, isolierten Einheiten aufgebaut werden, deren externe
Beziehungen am Interface deutlich werden. Damit wird sowohl praktische
Schadensreduzierung durch Isolation als auch eine schnelle und einfache Sicherheitsanalyse
möglich.
* Zugriffsentscheidungen dürfen nur auf der Basis expliziter, minimaler und
keinesfalls durch immer und global verfügbare Permissions fallen.
* Das Softwaredesign von Applikationen sollte wenn möglich öffentlich sein. Zumindest sollte
ein interner Review-Prozess stattfinden, in dessen Verlauf eine Sicherheitsanalyse
durch nicht an der Entwicklung Beteiligte erstellt wird.

[^sicheresysteme_93] : [@sicheresysteme pp.93]
[^sicheresysteme_94] :[@sicheresysteme pp.94]
[^sicheresysteme_95] :[@sicheresysteme pp.95]
[^apachekiss]: [@apachekiss]
[^defaultdeny]: [@defaultdeny]

<!-- TODO: Weitere Konzepte Sicherheitssystem Seite 104 -->

## Authetentifizierungskomponenten
Die Authentifizierung kann mit verschiedenen Komponenten durchgeführt werden. Folgend gilt es die Komponenten zu erklären.

###Captcha
Captcha - Test, mit dem festgestellt werden kann, ob sich ein Mensch oder ein Computer eines Programms bedient [^duden]

Im Jahre 2000 wurde das Captcha an der Carnegie Mellon University erfunden. Captcha steht für **C**ompletely **A**utomated **P**ublic **T**uring test to tell **C**omputers and **H**umans **A**part. Luis von Ahn, Professor der Entwickler-Gruppe, erklärte die Dringlichkeit von Captcha damals so: "Anybody can write a program to sign up for millions of accounts, and the idea was to prevent that". ****
[^captcha]

####Captcha Zahlen
In 2014 wurden 200 Million Captchas  pro Tag eingegeben. Dabei braucht ein User durchschnittlich 10 Sekunden das entspricht 500'000 Stunden.[^statisticinfo]

![Beispiele von Captchas *Quelle:drupal.org*](images/captcha.png)


[^duden]: [@duden]
[^captcha]: [@captcha]

[^statisticinfo]: Die statistischen Daten wurden von Google 2014 in ihrem Blog publiziert [@googlecaptcha]

###Zweiweg Authentifizierung
Die Zwei-Faktor-Authentifizierung wird häufig 2FA genannt. Der User wird mittels zweier unabhängigen Faktoren identifiziert. Der Begriff Faktor umschreibt dabei eine Komponente oder Authentifizierungsmethode. [^cnet-2fa]

Die Zwei-Faktor-Authentifizierung ist in der Schweiz durch das E-Banking bekannt geworden. Der User gibt als 1. Faktor Username/Vertragnummer und Passwort ein. In einem 2. Schritt gibt er vom System gewünschten Code aus der Codekarte oder des elektirschen Rechners als 2. Faktor ein. 
Im Alltag bei einem Einkauf im Detailhandel authentifiziert sich der EC-Karten Chip als 1. Faktor. Als 2. Faktor hat sich der Kunde ein Passwort auswendig gemerkt welches er eingibt.

Diese 2 Faktor Authentifizierung hatte die Entwicklung und Förderung der Vielfalt von Faktoren/Komponenten zu folge von welchen wir nun für unsere Authentifizierung profitieren können:

###E-Mail Bestätigungs-Code
Im Registrationsprozess ist das Erhalten eines E-Mails mit Bestätigungs-Code zum quasi Standart geworden. Durch diese Methodik kann man garantieren, dass die angegebene E-Mail Adresse auch tatsächlich existiert und der User darauf Zugriff hat.

####Automatisierungsmöglichkeit
Das automatische Auslesen von E-Mails ist möglich. Jedoch ist der Aufwand dafür sehr hoch.

####Mehrfach Teilnahme
Ein User kann verschiedene E-Mail Adressen besitzen. Dass Erstellen von neuen E-Mail Adressen ist mit Aufwand verbunden. Aber möglich.

Anbieter wie 10-Minutes Mail [^10minutemail] stellen auf Knopfdruck für einige Minuten eine temporäre E-Mail Adresse zur Verfügung. Dadurch können schnell einige E-Mail Adressen erstellt werden. 
Diese Domains müssen über eine aufwendige Blacklist gefiltert werden.

###SMS Bestätigungs-Code



[^10minutemail]: 10-Minute Mail [@10minutemail]


[^cnet-2fa]
[^cnet-2fa]: [@cnet-2fa]
