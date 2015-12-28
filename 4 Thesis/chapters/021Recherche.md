\newpage

#Recherche

## Fachbegriffe
Eine ausführliche Erklärung der Fachbegriffe befindet sich im Anhang unter dem Kapitel "[Glossar]".

## Erläuterung der Grundlagen
In diesem Kapitel werden Funktionsweisen und Grundlage ausgeführt, die als für die Bearbeitung dieser Bachelorthesis herangezogen wurden.

###Authentifizierung
Authentifizierung - beglaubigen, die Echtheit von etwas bezeugen verfolgt das Ziel [@duden] 

Eine Person oder Objekt eindeutig zu **authentifizieren** bedeute zu ermitteln ob die oder derjenige auch der ist als welcher er sich ausgibt. [@authentifizierungsdef] Dies unterstreicht auch die Ableitung des Wortes vom Englischen Verb *authenicate*, was auf Deutsch sich als *echt erweisen, sich verbürgen, glaubwürdig sein* bedeutet.  Das bekannteste Verfahren der Authenfizierung ist die Eingabe von Benutzernamen und Passwort. Weiter ist die PIN-Eingabe bei Bankautomaten oder Mobiletelefon häufig verbreitet. Die Möglichkeiten der Authentifizierung nahe zu grenzenlos.
[@authentifizierungsdeforg]

###Autorisierung
Autorisierung - Befugnis, Berechtigung, Erlaubnis, Genehmigung [@duden]

Wenn die Authenfizierung[Authentifizierung] erfolgreich war erteilt das System die Autorisierung. Dabei wird der Person oder Objekt erlaubt bestimmte Aktionen/Zugriffe durchzuführen. Meist verfügen unterschiedliche Benutzer eines Systems über verschiedene Zugriffsrechte. Die korrekte Zuweisung der individuellen Rechte ist ebenfalls Bestandteil der Autorisierung.

Der Begriff Authentifizierung wird vielfach mit dem Begriff Autorisierung verwechselt. Die Authentifizierung wird vom Benutzer initiiert. Sie dient dem Nachweis, zur Ausübung bestimmter Rechte befugt zu sein. Die anschließende Autorisierung erfolgt automatisch durch das System selbst. Im Zuge der Autorisierung werden dem Benutzer seine Zugriffsrechte zugewiesen.
[@authentifizierungsdeforg]

###Captcha
Captcha - Test, mit dem festgestellt werden kann, ob sich ein Mensch oder ein Computer eines Programms bedient [@duden]

Im Jahre 2000 wurde das Captcha an der Carnegie Mellon University erfunden. Captcha steht für **C**ompletely **A**utomated **P**ublic **T**uring test to tell **C**omputers and **H**umans **A**part. Luis von Ahn, Professor der Entwickler-Gruppe, erklärte die Dringlichkeit von Captcha damals so: "Anybody can write a program to sign up for millions of accounts, and the idea was to prevent that".
[@captcha]

####Captcha Zahlen
In 2014 wurden 200 Million Captchas  pro Tag eingegeben. Dabei braucht ein User durchschnittlich 10 Sekunden das entspricht 500'000 Stunden.[^statisticinfo]

![Beispiele von Captchas *Quelle:drupal.org*](images/captcha.png)


[^statisticinfo]: Die statistischen Daten wurden von Google 2014 in ihrem Blog publiziert [@googlecaptcha]

\newpage
###OAuth
OAuth ist ein Protokoll. Es erlaubt sichere API-Autorisierungen.

####Das Bedürfnis nach OAuth
2006 implementiere Blaine Cook OpenID für Twitter und Ma.gnolia erhielt ein Dashboard welches sich durch OpenID autorisieren lies. Deshalb sich die Entwickler von Ma.gnolia und Blaine Cook um eine Möglichkeit zu finden OpenID auch für die Verwendung von APIs zu gebrauchen. Sie diskutierten ihre Implementierungen und stellten fest das es keinen offenen Standart für API-Access Delegation gab. So fingen sie an den Standart zu entwickeln. 2007 entstand daraus eine Google Group. Am 3. October 2007 war dann der OAuth Core 1.0 bereits released worden.

####Funktionalität von OAuth
Ein Programm/API (Consumer) stellt über das OAuth-Protokoll einem Endbenutzer(User) Zugriff (Autorisierung) auf seine Daten/Funktionalitäten zur Verfügung. Dieser Zugriff wird von einem anderen Programm (Service) gemanagt. 
Das Konzept ist nicht generell neu. OAuth ist ähnlich zu Google AuthSub, aol OpenAuth, Yahoo BBAuth, Upcoming api, Flickr api, Amazon Web Services api. OAuth studierte die existierenden Protokolle und standardisiert und kombinierte die existierende industriellen Protokolle. Der wichtigste Unterschied zu den existierenden Protokollen ist, das OAuth sowohl offen ist und anderseits zu einem Standard geworden ist.
Jeden Tag entstehen neue Webseite welche neue Funktionalitäten und Services offeriert und dabei Funktionalitäten von anderen Webseiten braucht. OAuth stellt dem Programmierer einerseits eine standartisierte Implementierung zur Verfügung. Der Endbenutzer erhält dank dieses Protokoll die Möglichkeit teile seiner Funktionalität/Daten bei einem anderen Anbieter zur Verfügung zu stellen. So kann der Endbenutzer bei der Facebook OAuth z.b. seine Posts zur Verfügung stellen nicht aber seine Freunde bekannt geben. 

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
78% der Schweizer Bevölkerung besitzt bereits einen OAuth Account. Das Protokoll ist ein etablierter Standard. 

####Nachteile
Mehrfachregistrierungen sind möglich. Jenach OAuth-Provider werden verschiedene Daten zur Verfügung gestellt. Pro OAuth Provider kann man sich registrieren einen Abgleich der verschiedenen OAuth Provider wird vom [OAuth]-Protokoll nicht zur Verfügung gestellt. 22% der Bevölkerung müsste sich vor Nutzung noch registrieren. Die Implementierung ist trotz vielen Libaries nicht ohne tiefere Programmierkenntnisse möglich.

\newpage
This is just a sample. You can play around with your own text right here.



...is really just ordinary text, *plain and simple*. How is it good for you?

- You just **type naturally**, and the result looks good.
- You **don't have to worry** about clicking formatting buttons.
  - Or fiddling with indentation. (Two spaces is all you need.)

To see what else you can do with Markdown (including **tables**, **images**, **numbered lists**, and more) take a look at the [Cheatsheet][2]. And then try it out by typing in this box!

[2]: https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet

  Right     Left     Center     Default
-------     ------ ----------   -------
     12     12        12            12
    123     123       123          123
      1     1          1             1


![This is the caption](images/image.jpg)

Test  |test2   | saleti
--|---|--
olé  | Thats the way   |  
  |   |  

This is the day

\newpage

#Grundlagen
Dieses Kapitel erläutert die Grundlagen. Ein grosser Teil der Arbeit stützt sich auf den Grundlagen ab [@rupDatenbanken pp.105]

##Basisbegriffe

###Authentifizierung
###Autorisierung
Saleti


