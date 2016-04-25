#Konzept
In diesem Kapitel soll ein System für den Authentifizierungsservice entworfen werden. Das System soll den Anforderungen, welche im vorherigen Kapitel definiert wurden, entsprechen. 

Um die Komponenten unabhängig von einander zu entwickeln, wird bei der Entwicklung der Architektur des Authtenifizierungsservice darauf geachte möglichst gerine Kopplung aufzuweisen.

##Architektur
Der Authtentifizierungsservice besteht aus drei Hauptkomponenten: Web-API, Konfigurator und Autorisierung. Die folgende Abbildung zeigt die Verbindungen der drei Hauptkomponenten im Systemkontext des Authentifizierungservice auf.

![Übersicht der Hauptkomponenten](images/draw_io/BA_KomponentenDiagramm.png)

##Software Design
###Webservice

###

\newpage
##Genereller Ablauf Authentifizierung
Der User nimmt an einer Interaktivität eines Anbieters teil. Dabei füllt er den Wettbewerb, Umfrage aus oder löst die gegebene Aufgabe und sendet einmal oder mehrmals ein Feedback an die Anbieter Webseite zurück. Nach Abschluss der Interaktivität, werden die Datengespeichert und mit der daraus resultierenden eindeutigen Identität des Feedbacks wird die Authentifizierung gestartet. Das vom Programmierer definierte Authentifizierungsverfahren bestehend aus ein oder mehreren Sicherheitsstufen wird durchgeführt um Identität im gewünschten Masse sicher zustellen. User und das Anbieter System werden über erfolgreiche Authentifizierung informiert. Nach Möglichkeit wird auch eine fehlerhafte Authentifizierung mitgeteilt.

![Aufbau Inhalt im Card-Design](images/draw_io/BA_AutorisationOverview.png)

##Domänenmodel Differenziert
Ein differenziertes Domänemodel oder auch Domänenmodel Basis Level genannt, erlaubt eine vereinfachte Kommunikation zwischen Kunde/Auftraggeber und Entwicklungsteam/Entwicklungsperson. Die Denkweise im Model erfordert keine Programmierkenntnisse und fördert die strukturierte Wiedergabe von Datengefässen. Beim Domänenmodel werden die Begriffe aus der Domäne des Kunden verwendet und fördern so die Verständlichkeit auf beiden Seiten.

![Differenziertes Domänemodel des Authentifizierungservice](images/domaenenmodell.png)

<!--TODO beschreibung des Models-->

\newpage
##Datenbankdesign
In der Systemarchitektur des Authentifizierungservice stehen Objekte nur während der Ausführungszeit zur Verfügung. Um sie zu persitieren, werden sie in einer relationalen Datenbank gespeichert.
Die Pradigmen der Objektorientierten Programmiersprache und der relationalen Datenbank sind grundlegend verschieden. 
So kapseln Objekte ihren Zustand und ihr Verhalten hinter einer Schnittstelle und haben eine eindeutige Identität. Relationale Datenbanken basieren dagegen auf dem mathematischen Konzept der relationalen Algebra. Dieser konzeptionelle Widerspruch wurde in den 1990er Jahren als "object-relational impedance mismatch" bekannt.[^vietnamcomputerscience]
Um diesen Wiederspruch zu mindern stellt Microsoft das Entity-Framework zur Verfügung. 

###Entity-Framework
Das Entity-Framework hat verschiedene Konzeptionelle Ansätze um möglichst viele Bedürfnisse an den ORM-Mapper zu erfüllen. Es gilt nun den richtigen Ansatz für den Authenifizierungsservice zu wählen.

####Database First
Beim Database First Ansatz wird zuerst die Datenbank designt. Das Entity-Framework bildet aus der Datenbank die POCO-Klassen ab. Sollten Anpassungen an den Entitäten ergeben, werden diese zuerst in der Datenbank implementiert und daraus werden wiederum neuen POCO-Klassen generiert.

####Code First
Beim Code First Ansatz werden zuerst die POCO-Klassen erstellt. Das Entity-Framework bildet aus den POCO-Klassen die Tabellen in der Datenbank. Alle Anpassungen werden gleich in den POCO-Klassen umgesetzt und durch das Entity-Framework in der Datenbank geändert erstellt.

####Entscheidung
Wenn die POCO-Klassen gleich mehrheitlich für die Schnittstellendefinition als Parameterdefinition verwendet werden könnten, fallen Mehraufwendungen für Umwandlungen im Programmcode weg. Eine Schnittstellendefinition sollte aber nicht willkürlich durch eine Datenbankänderung beeinflusst werden. Der umgekehrte Fall ist aber minder wichtig, da die Datenbank nur von der Schnittstelle verwendet wird. Deshalb wird das Konzept Code First eingesetzt.

[^vietnamcomputerscience]: [@the-vietnam-of-computer-science]
###ERD
Durch den Codefirst Ansatz werden die Datenbank und alle zugehörigen Tabellen durch das Entity Framework selbständig generiert


\newpage
##Integration der Schnittstelle
Wie in der Anforderungsanalyse <!--TODO Punkt beschreiben --> und Aufgabenstellung  <!--TODO Punkt beschreiben -->geschrieben, soll die Schnittstelle möglichst einfach in Bestehende Systeme integriert werden können. Bevor wir untersuchen wie wir die Integration umsetzten können, bedarf es die wichtigsten bestehenden Systeme zu kennen um evtl für diese Systeme eine spezifisch einfach Integration zu entwickeln.

###Bestehende Systeme für Votings, Wettbewerbe und Quizes
Das bestehende Social-Media Modul wird als Teil einer Webseite in einer Webapplikation geführt. Webapplikation, welche Inhalte verwalten, werden sinngemäss Content Management Systeme genannt. Die Abkürzung CMS hat sich im IT-Fachjargon etabliert. Statista.com  wertetet mehrmals im Jahr die Verbreitung der verschiedenen CMS aus [^statisticinfostatista]. Folgend ist die Erhebung aus dem November 2015 abgebildet:

![Nutzungsanteil CMS weltweit *Quelle:de.statista.com*](images/cms_statistik_november2015.JPG)

Die von statista.com veröffentlichten Zahlen wurden mit Werten von W3techs.com verglichen[^statisticinfow3techs]. Die Unterschiede sind für unsere Verwendung minimal und liegen im 10tels Prozentbereich. Da beide bekannten Statistik unternehmen auf die selben Werte gekommen sind, kann von einem hohen Warheitsgrad ausgegangen werden.
Beim Betrachten der Statistik fällt auf das Wordpress mit 25,2 mit Abstand am meisten genutzt wird. Alle dynamischen Webseiten unter den Top 10 basieren auf Systemen in PHP[^phpinfotag]. Adobe Dreamviewer und FrontPage sind keine Systeme welche auf dem Server betrieben werden. Sie sind Editoren welche auf dem jeweiligen Computer ausgeführt werden und danach mehrheitlich HTML, CSS und Javascript Code an den Server ausliefern. Funktionalitäten werden mit den beiden Editoren manuell geschrieben. 

Basierend auf diesen statistischen Erkenntnissen lohnt es sich die Wordpress Welt kennen zu lernen und recherchieren wie dort eine Authentifizierungsschnittstelle eingebunden werden könnte.

### Wordpress PlugIn Hook
Erweiterungen im Wordpress nennen sich Plugins. Die Plugins können direkt über das CMS-Backend eingespielt werden. Alternativ können Sie natürlich manuell installiert werden. Zum Beispiel in dem man ein Plugin selber Programmiert oder beim Hersteller oder über das Plugin-Verzeichnis von Wordpress[^plugin-verzeichnis] downloadedt. Wordpress sammelt zugleich die aktiven Installationen der PlugIns (sofern man als Entwickler den Informationsaustausch nicht unterbindet). Die Gesamtzahl wird im CMS-Backend Wordpress und auf Ihrer Plugin-Verzeichnis Webseite[^plugin-verzeichnis] veröffentlicht. Dank dieser Kennzahl kann nun die meist verbreiteten Plugins herrausgefunden werden. 

<!--TODO Auflistung von bekannten Plugins -->

Wordpress basiert auf einem sogennanten Hook-System. "Hook" eins zu eins übersetzt bedeutet "Haken", "Aufhänger" oder "Greifer". Ein Hook ist im Wordpress eine definierte Codestelle bei der man seinen eigenen Code  einhaken kann. Der PlugIn Entwickler definiert diese Hooks um anderen PlugIns oder Funktionalitäten zu erlauben sein PlugIn zu erweitern. Auch der Core vom Wordpress enthält solche Hooks. Dadurch soll verhindert werden, dass PlugIn's oder der Core von Wordpress direkt umgeschrieben werden muss und dann nicht mehr einfach so unabhängig upgedatet werden kann. Um unsere Schnittstelle einzubinden, könnten wir evtuell also solche Hooks verwenden. Dieser "Hook"/Haken hat lustigerweise auch einen Haken: Der PlugIn-Entwickler kann selbständig bestimmen ob und wo er solche Hooks einsetzen will und welche Möglichkeiten dann zur Verfügung stehen. Kommerzielle PlugIn's verfolgen vielfach den Weg möglichst verschlossen zu agieren um mögliche Erweiterungen monetär umzusetzen und so eine Abhängigkeit zu erzeugen. Diese These gilt es nun zu untersuchen. Dafür wurden verschiedene Social Plugin's ausgewählt. Die Top 1000 installierten Wordpress PlugIns welche von der Art Social-Media Modul waren, ein paar Stichproben von kommerziellen Plugins und Stichproben aus in Beiträgen empfohlenen PlugIns: [^plugin-verzeichnis2], [^plugin-market2]

--------------------------------------------------- -------------------------
__PlugIn__					  		
--------------------------- -----------	-----------	------------------------
__WP-Polls__                kostenlos	100000+		Über "wp_polls_add_poll" könnte man den erstellten Poll authentfizieren und bei fehlerhafter Authentifizierung löschen

__Polldaddy Polls & Ratings__ Freemium 	20000+		-

__Wp-Pro-Quiz__				kostenlos	20000+		Hooks vorhanden. Nicht für eine Authentifizierungsschnittstelle zu gebrauchen.
	
__Responsive Poll__         15$			-			Keine Hooks. Laut Hersteller sind welche geplant (Zeitpunkt ungewiss)

__TotalPoll Pro__           18$			-			Hooks vorhanden. Ähnlich wie bei WP-Polls könnte man evtl. den erstellten Datensatz löschen. Jedoch ist dies ohne Kauf nicht ersichtlich.

__Easy Polling__			15$			-			-

__Opinion Stage__           kostenlos	10000+		-

__Wedgies__                	Freemium	800+		- 

-------------------------------------------------------------------------------
Table: Recherche PlugIn's  


Wir haben nun verschiedene Wordpress-Plugin's für Umfragen, Wettbewerbe & Abstimmungen auf Hooks untersucht. Alle PlugIn's bieten gar keinen Hook an oder keinen Hook, welcher unseren Anforderungen einer einfachen Integration genügt. Die aufgelisteten Plugins bilden eine wesentliche Verbreitung ab. Selbst wenn wieder erwartet alle nicht untersuchten Plugin's eine perfekte Hookanbindung liefern würden, hätten wir, mit den nicht getesteten Plugin's eine zu geringe Verbreitung. Der Ansatz die Integration per Hooks zu machen muss also fallen gelassen werden.

[^statisticinfostatista]: CMS Nutzungsstatistik von statista.com [@statisticinfostatista]
[^statisticinfow3techs]: CMS Nutzungsstatistik von w3techs.com [@statisticinfow3techs]
[^phpinfotag]: Die Information wurde von den jeweiligen Hersteller- bzw. Communitywebseiten bezogen.
[^plugin-verzeichnis2]: Das Pluginverzeichnis befindet sich unter http://de.wordpress.org/plugins
[^plugin-market2]: Envato bietet eine Plattform für den Verkauf von Wordpress-Plugin's an http://market.envato.com



\newpage

### Parallellen im ähnliches Anwendungsfeld 
Der vertieften Research der letzten Kapitel wird verlassen und es wird probiert einen anderen Herangehensweise zur Findung der Lösung zu nehmen: Forscher adaptieren immer wieder erfolgreiche Modelle aus anderen Bereich in ihr Gebiet. Vielfach wird die Natur als erfolgreiches Vorlagemodell genommen. Ganz soweit wird hier nicht gegangen. Payment-Gateways wie der Schweizer Anbieter Datatrans müssen Webshop-Entwicklern auch eine Möglichkeit bieten das Gateway einfach in Ihren Webshop einbinden zu können. Auch bei Ihnen steht die Sicherheit auf der obersten Stufe und eine einfache Integration ist für den Erfolg trotz internationalem Druck von nöten. 
Dabei fährt Datatrans eine Zweiwegstrategie. Sie stellen für bekannte Shopsysteme gleich ganze PlugIns zur Verfügung[^dt-plugin]. Auf der anderen Seite bieten Sie ausführliche beschriebene und einfache Schnittstellen an.

#### Datatrans Zahlungsablauf
Um die Gateway-Implementation der Datatrans als Ganzes zu verstehen, führen wir uns der generellen Ablauf eines Payment Gateways eines Webshopeinkaufs bei Datatrans vor Augen. Der Ablauf:

![Nutzungsanteil Zahlungsablauf Webshop mit Datatrans *Quelle:datatrans*](images/datatrans-autorisierung.JPG)

1.	Der Endkunde wählt Produkt aus und schliesst die Bestellung ab
2. 	Der Webshop/Merchant zeigt Zahlungsseite von Datatrans, Karteninhaber gibt seine Kartendaten ein.
3.-7.Datatrans autorisiert und verarbeitet wennmöglich  die Transaktion zum Acquirer.
8. 	Datatrans zeigt den Status dem Kunden an und sendet Status dem Merchant zurück.
9. 	Merchant zeigt dem Karteninhaber die Antwortseite (erfolgreich oder abgelehnt)
[^dt-api]

[^dt-plugin]: Übersicht der Web-Shop PlugIn's [@datatrans-plugin]

\newpage

#### Datatrans XML/SOAP API Lightbox Mode
Bei Schritt 2 des Zahlungsablaufs ruft der Webshop das Datatransgateway auf. Beim "Lightbox Mode" wird dabei ein iframe in einem Overlay über die Webseite gelegt und der Webshop ansich verdunkelt dargestellt.

![Datatrans Lightbox Integration *Quelle:datatrans*](images/datatrans-lightbox.JPG)



Das Gateway muss eine minimum an Informationen erhalten, um den Zahlungsvorgang überhaupt starten zu können. So muss es wissen, wer der Verchäufer ist. Datatrans regelt dies über eine Merchan-ID. Wie viel Geld in welcher Währung verkauft werden sollte, muss Datatrans über amount und currceny mitgeteilt werden. Um dem Shop später mitteilen zu können, welche Bestellung erfolgreich verarbeitet wurde, braucht es eine Referenznummer. Die Referenznummer nennt Datatrans singemäss refno. Die Ganzen Parameter werden optional mit einem sign-Parameter gesichert und mittels Html-Form dem Javascript übergeben:[^dt-api]

\newpage

Implementierungscode der Datatrans:

~~~~~~~
<script src="https://code.jquery.com/jquery-1.11.2.min.js"></script>
<script src="https://pilot.datatrans.biz/upp/payment/js/datatrans-1.0.2.js"></script>

	<form id="paymentForm"
		 data-merchant-id="1100004624"
		 data-amount="1000"
		 data-currency="CHF"
		 data-refno="123456789"
		 data-sign="30916165706580013">
		 <button id="paymentButton">Pay</button>
	</form>
	
<script type="text/javascript">
	 $("#paymentButton").click(function () {
		Datatrans.startPayment({'form': '#paymentForm'});
	 });
</script>
~~~~~~~

### Integrationsentscheid

Die Stragtegie der Paymentintegration von Datatrans soll für den Authentifizierungservice genutzt werden. 

Durch automatisches Öffnen der Lightbox erreicht der Endbenutzer mühelos den Schritt der Authentifizierung. Die Authentifzierung springt ihm nahe zu entgegen. Dadurch ist eine Hohe Effiktivität gegeben. Der User bleibt auf der selben Seite und wird dadurch nicht aus dem Fluss der Abarbeitung der Interaktivität geworfen. 
Das Verfahren ist sehr effizient. Die Javascript und CSS Daten werden beim Laden der Interaktivität bereits mit geladen. So entsteht eine minimale Wartezeit beim Einblenden der Lightbox. Dies ist für den User nicht spürbar oder störend.

Bei der Darstellung der Authentifizierung auf einer einzelnen Seite müsste das Web-Design des Interaktivitäs-Anbiter adaptiert werden können. Da die Authentifizierungs-Lightbox auf seiner Seite dargestellt wird, braucht der Interaktivitäts-Anbieter nicht sein Design mühsam für eine Authentifizierungsseite zu konfigurieren. 

Die Lightbox des Authenifizierungsservice wird mit einer grösseren Verbreitung einen gewissen Wiedererkennungswert erhalten. So wird die Lösung als professionelles Produkt wahrgenommen werden. Das Ziel das Benutzer und Entwickler den Authenifizierungsservice als ein sicheres und glaubwürdiges Produkt für Interaktivitäten wahrnehmen wird so versteckt werden.

### Integrationskonzept

### Integrationsparameter

------------------------------------------------------------------------------------
__Feldname__				__Wert__		__Beschreibung__												
--------------------------- ---------------	----------------------------------------
__as_projectid__            Integer			Project ID			

__as_id_provider__ 			String			Die ID um die Interaktivität seitens Interaktionsanbieter eindeutig zu erkennen
	
__as_sign__					String			Signatur, welche die Eingaben überprüft.

-----------------------------------------------------------------------------------
Table: Parameter Authenifizierungsservice Lightbox


#### Einfache Signature
Die Verwendung einer einfachen Signatur beugt Eingabefehler vor. Wenn auch nur geringfügig, der Aufwand erschwert den Missbraucht. 
Um eine korrekte Signatur zu erstellen werden folgende Parameter konkateniert und mit einem Plus separiert.

- as_projectid
- as_id_provider

Beispiel: 30045+12

Der daraus resultierende String wird mit SHA1 verschlüsselt

Beim Beispiel gäbe es die Signatur 8a2298ebfe7208ebe63dd11cdbf5b6cafb56d09c


\newpage
##Sicherheitstufen integrieren

Im Kapitel Recherche wurden einige Sicherheitskomponenten recherchiert und illustriert. Es gilt nun ein Setting an Komponenten zu finden, welche dem Developer eine Breite Auswahlmölgichkeit ([NFREQ-210](###NFREQ-210)) bietet  und eine genügende Verbreitung in der Schweiz hat ([NFREQ-212](###NFREQ-212)), ihn aber nicht durch komplexes Auswählen der Sicherheitstufen aufhaltet ([NFREQ-222](###NFREQ-222)),.


####Cookie
Durch Speicherung des Cookies soll ein Benutzer der bereits an einer Interaktivität teilgenommen hat, identifiziert werden. Da die Cookies clientseitig verwaltet werden, können diese auch vom Anwender manipuliert werden. Mit Browser Makro Tools wie iMacro kann ganz einfach ein Cookie gelöscht werden. Dadurch ist sowohl das Verhindern mehrfacher Teilnahme als auch das verhindern einer automatisierten Teilnahme an einer Interaktivität ungenügend geschützt. Vorteilhaft für die Cookiemethode ist, dass der Benutzer keinen Aufwand betreiben muss und es keine Kosten verursacht.


####IP-Adresse
Durch Speicherung der IP-Adresse soll ein Benutzer der bereits an einer Interaktivität teilgenommen hat, identifiziert werden. Eine IP Adressen vertritt gegen Aussen alle Benutzer mit dem selben "Internetanschluss"[!internetanschluss]. Dadurch könnte nur einmal pro Internetanschluss an einer Interaktivität teilgenommen werden. Dass durch Wechseln des Proxys eine andere IP-Adresse verwendet werden kann und dies auch ohne IT-Know How durch Tools möglich ist, lässt sowohl Eindeutigkeit und Verhinderung von Automatisierung als ungenügend bewerten. Die Methode kann als kostenlos eingestuft werden und generiert beim Endbenutzer keinen Aufwand

####Browser Fingerprint
Durch Generierung eine Browser Fingerprints (siehe Recherche) identifiziert werden. Das Verfahren kann zu 94% ein User wiedererkennen. Dass Verwenden mehrerer Browser oder Geräte führt zu verschiedenen Browser Fingerprints. iPhone taugt nicht für die Methode. Deshalb muss  Eindeutigkeit und Verhinderung von Automatisierung als ungenügend bewertet werden. Die Methode kann als kostenlos eingestuft werden und generiert beim Endbenutzer keinen Aufwand.

####SMS Authentifizierung
Der Benutzer gibt seine Mobilenummer ein. Durch versenden eines Codes wird sichergestellt, dass dem Benutzer die Telefonnumer gehört. In der Schweiz können maximal 5 Mobilenummern bei den Anbietern gekauft werden.<!--TODO Siehe-->(Siehe Kapitel Recherche) Der Benutzer kann eindeutig anhand der Mobilenummer erkannt werden. Die möglichen Mobilenummern pro User sind beschränkt. Eine Automatisierung ist praktisch unmöglich. Die Kosten pro SMS sind tragbar. Der Benutzer muss bei dieser Methode sein Handy bei sich tragen und den Code übertragen.

####Telefon Authentifizierung
Der Benutzer gibt seine Telefonnumer ein. Der Benutzer swird automatisiert angerufen und die Computerstimme liest ein Code vor, welcher der Benutzer im Rückbestätigungsformular einträgt. Dadurch wird sichergestellt, dass die Telefonnummer dem Benutzer gehört. Mobilenummern sind wie vorhin erwähnt eingeschränkt. Festnetzanschlüsse unterliegen einer finanziellen Hürde. 

####Postversand Authentifizierung
Der Benutzer gibt seine Adresse ein. Um sicherzustellen, dass die Adresse dem User gehört wird automatisiert ein Brief an die Adresse gesendet. Da die Gefahr besteht dass falsch adressierte Briefe den Empfänger trotzdem erreichen, deshalb wird Unique mit gut und nicht sehr gut bewertet. Eine Automatisierung ist praktisch unmöglich. Die Kosten pro Brief sind von allen aufgelisteten Methoden am höchsten. Der Benutzer muss bei dieser Methode den Brief nach erhalten auf einer Webseite quittieren


###Sicherheitstufen bewerten
Die Recherche der verschiedenen Sicherheitsstufen wurden dem Auftraggeber vorgelegt. Der Auftraggeber hat die verschiedenen Stufen anhand den 4 definierten Aspekten und dem Musskriterium Verbreitung aus der Anforderungsanalyse bewertet.

------------------------------------------------------------------------- -------------------------------------------------
__Sicherheitsstufen__		__Verhinderung		 __Automat-			__Kosten__	   	__Aufwand	  	     __Verbreitung	
							Mehrfachteilnahme__	sierung__							Benutzer__			 in der Schweiz__				
--------------------------  ------------------- ------------------- --------------- ------------------- -------------------
__Cookie__				  	2.5 		     	2.5 				6				6                	6
 
__Flash-Cookie__		  	2.5 		     	3					6				6                	6 
                                                                          
__IP__				      	3					3 					6				6             		6
                                                                          
                                                                          
__Browser 					3.5					3.5	 				6				6             		6
Fingerprint__			                                                      
                
__E-Mail__					4					4.5					6				4.5           		6
                                                                              
                                                                              
__SMS__						5.5					5.75				5				4.5           		5.5
						                                                      
                                                                              
						                                                      
__Telefon__					5.25				5.75				5				4.5           		5.75
						                                                      
                                                                              
						                                                      
__Ausweis-					3.5					3.5					6				5          	  		6
nummer__        
                
                
__SuisseID__				5.5					5.75				5				5			  		3
																		      		
------------------------------------------------------------------------- -------------------------------------------------
Table: Übersicht der Authentifizierungs Methoden

[!internetanschluss]: Der Begriff Internetanschluss ist schwamig eingesetzt.


###Auswahl der zu integrierenden Sicherheitsstufen
SuisseID und Flash-Cookies erreichen beim Musskriterium Verbreitung in der Schweiz ([NFREQ-212](###NFREQ-212)) keine genügende Note und wird daher ausgeschlossen. Um die geforderte Breite an Sicherheitsmethoden zu erlangen wurden die folgenden Methoden mit verschiedenen Stärken in Aspekten durch den Auftraggeber ausgewählt:
 

\newpage
##Modularität und Erweiterbarkeit
Wie in der Einführung zur Architektur erwähnt <!--TODO Siehe-->, sollte eine Architektur so konstruiert werden dass Sie möglichst Modular aufgebaut ist. Auch wenn wir die zu verwendenden Authentifizierungsmethoden im vorherigen Kapitel definiert haben, werden sich diese in Zukunft ändern. Anderseits kann sich auch die Authentifizierungsmethoden an sich komplett verändern. Sehr realistisch ist, dass für einen Browser Fingerprint neue Berechnungsmethodiken bekannt werden. Der Anbieter der hinter eine Authentifizierungsmethode steht, kann sich verändern oder dessen Anbindung. Kurz gesagt, die Modularität der Authentifizierungsmethoden muss unbedingt gewährleistet sein. Eine Implementation der Sicherheitsstufe SMS wie im folgenden einfachen Beispiel sollte nicht verwendet werden.

~~~~~~~
SMSSecurityStep inst = new SMSSecurityStep();
~~~~~~~

###Design by Contract
Das Design Pattern "Design by Contract" soll das Zusammenspiel von Modulen durch eine Definition/Vertrag regeln. Herr Bertrand Meyer führte das Pattern bei der Enwicklung der Programmiersprache Eiffel ein. Die Verträge enthält besteht aus

- precondition: "Die Zusicherung die der Aufrufer einzuhalten hat"
- postcondition: "Die Zusicherung die der Aufgegrufene einhalten wird"
- Invariants:	"Invariants sorgen dafür,dass bei Eintritts- und Austrittspunkten des Server Codes gewisse Conditions erfüllt bzw. Zustände gewahrt sind. Invariants sind in gewisser Weise also Pre- und Postconditions."

Im Grunde geht es darum den Operator new zu eliminieren.

Der Beispielcode als Design by Contract Pattern:

~~~~~~~
ISecurityStep proxy = new SomeFactory.GetSecurityStep(...);
~~~~~~~

ISecurityStep-Vertrag ist im Beispielcode der Vertrag. Die Instanz proxy Liefert ein Objekt zurück, welches das nach ISecurityStep-Vertrag definiert ist. Welches Objekt (Implementierung) sich dahinter verbirgt, ist uninteressant da diese Komponente gegen eine andere Implementierung ausgetauscht werden kann. In diesem konkreten Fall, könnten beispielsweise die Komponenten SMSSecurityStep und CookieSecurityStep die Schnittstelle ISecurityStep implementieren.

SomeFactory muss für die Umsetzung von Desing by Contract implementiert werden. Dafür gibt es in der .net Welt einiges an Beispiel Code und Frameworks zu finden. Ein beliebtes Framework ist die Windows Communication Foundation [^design-By-Contract]



###MEF - Managed Extensibility Framework
MEF das Managed Extensibility Framework ist seit der Version 4.0 Bestandteil des Frameworks. MEF ist eine Bibliothekt und Implementiert das Problem der Erweiterbarkeit sogar zur Laufzeit. Es vereinfacht die Implementierung von erweiterbaren Anwendungen und bietet Ermittlung von Typen, Erzeugung von Instanzen und Composition Fähigkeiten an.

![Vereinfacht die Architektur des Managed Extensibility Framework Quelle: msdn.microsoft.com](images/mef_architektur.jpg)

Die Abbilldung <!--TODO Siehe --> zeigt eine stark vereinfachte Architektur von MEF auf. Die Hauptmodule vom MEF-Core sind Catalog und CompositionContainer.
Der Catalog kontrolliert und stellt das Laden der Komponenten sicher. Der CompositionContainer erzeugt aus den Komponenten Instanzen und bindet diese an die entsprechenden Variablen.
Parts sind die Objekte die vom Type Export oder Import sein können. Die Komponenten die geladen und instanziert sind nennen sich Exports. Imports sind die Variabeln an den Exports gebunden werden sollen. 

Um das Konzept besser zu verstehen, soll der Beispielcode von Design by Contract <!--TODO Siehe --> herangezogen werden. Die Variable proxy vom Type ISecurityStep die die Instanz dieser Komponente enthalten soll, wäre ein „Import“ in einer MEF Anwendung. Der SMSSecurityStep oder CookieSecurityStep wären in einer MEF Anwendung ein Export.

MEF automatisiert die Instanzierung mit Hilfe von Catalog und Container.

###Entscheidung
MEF stellt den vollen Umfang an Funktionalität, zur Lösung der Problematik, zu Verfügung. Der Ansatz der Umsetzung des Design by Contract bräuchte eine geeignete Integration für die Factory. MEF bietet des weiteren die Möglichkeit die DLL's zur Laufzeit auszutauschen und eine automatisierte Instanzierung.

\newpage
### Sicherheitsstufen Libaray-Übersicht anhand MEF
Basierend auf dem Managed Extensibility Framework wird wir der Aufbau unstrukturiert. Neu wird nicht alles in einer Library im Webservice gespeichert sondern mehrere Libarays erstellt. Die Libaray SecurityStepContracts beinhaltet den Contract/Vertrag der Sicherheitsstufen ISecurityStep. Es besteht keine Abhängigkeit zwischen dem Authenifizierungsservice und den Sicherheitsstufen. 

![UML Library Overview](images/mef_library_overview.png)

[^design-By-Contract]: [@design-By-Contract]



   




\newpage
##Mockup
Ein Mockup ist eine grobe Vorlage für die Design-Umsetzung. Es ist eine ideale Möglichkeit das visuelle Konzept ab zu bilden und mit dem Auftraggeber vorgängig anzuschauen. Die folgenden Unterkapitel bilden die Mockups der App ab.

###Konfigurator Template
Der Konfigurator soll den Programmierer visuell beim Konfigurieren und Verwalten seiner Authentifizierungssoftware unterstützen. Bei der Zielgruppe handelt es sich um Programmierer. Es kann deshalb von einem hohen Know-How ausgegangen werden. Die Oberfläche soll möglichst effizient gestaltet sein. Die Designelemente sollen deshalb klar und einheitlich gestaltet werden. Generell ist davon auszugehen, dass der Programmierer beim Einrichten seines Projektes am Desktop arbeitet. Für Auswertungen und Präsentationen kann der Programmierer durchaus auch mobile Endgeräte verwenden. Deshalb soll die Umsetzung responsive gestaltet werden.

![Mockup Konfigurator Template Desktop](images/mockups/General.png)



\newpage

![Mockup Konfigurator Template Mobile](images/mockups/Mobile.png)

####Seitenaufbau
Im Header wird der Programmierer anhand des Seitentitels gleich über seinen aktuellen Standort orientert. 

####Navigation
Im Designkonzept wurde von einer Klappmenü oder Topnavigation abgesehen. Die Wichtigkeit durch einen Klick alle Navigationspunkte zuerreichen, überwiegte den Platzersparnissen in der Breite. Die wenigen Navigationspunkte erlauben eine flache Navigationsstruktur. Dadurch kann in der Desktopansicht links immer alle Navigationspunkte angezeigt werden. Der Programmierer kann rasch auf die gewünsche Seite switchen. In der Mobileansicht kann durch einen einzigen Klick auf die "Burger-Navigation" das gesamte Menü eingefahren werden. Der Entscheid, für eine statische linke Navigationsstruktur in der Desktopansicht, wurde ausserdem bekräftigt durch den Wunsch den Konfigurator gestalterisch mit Farb und Bild aufzuwerten. Dies ist über die linke Spalte einheitlich und einfach umsetzbar.

####Inhaltaufbau
Trotz unterschiedlichstem Inhalt (Text, Tabellen, Diagramme, Bilder und Formulare) und Grösse soll eine einheitliche Struktur geschaffen werden. Die Struktur soll es erlauben einerseits Übersichten wie Dashboards mit verschiedenen Inhalten auf einer Seite abzubilden. Die selbe Struktur soll aber auch für Seiten mit nur einem Inhaltselement wie Registration oder Login-Seite verwendet werden können. Verschiedene Designe lösen diese Problematik mit einem Karten-Konzept English genannt Card Based Design. Dabei wird jedes Inhaltselement als "Card" dargestellt. Die "Card" hat einen klar abgerenzten Darstellungsbereich. Die Card ist in Header und Content unterteilt. Im Header wird mittels Titel (wenn auch repetitiv) dem Anwender kommuniziert, was für ein Inhalt im Breich Content der "Card" zu erwarten ist. [^card-based-design]

![Aufbau Inhalt im Card-Design](images/mockups/card.jpg)




![Aufbau Inhalt im Card-Design](images/mockups/Kundenimplementation-Desktop.png)

![Aufbau Inhalt im Card-Design](images/mockups/Kundenimplementation-Mobile.png)

###Hinweis zur Zusammenarbeit mit dem Auftraggeber
Die hier abgebildeten Mockups und weitere Ansichten sind das Ergebnis aus den Absprache mit dem Auftraggeber. Sie sind vom Auftraggeber abgenommen und zur Impelmentation freigegeben[^freigabeMockups]

[^card-based-design]: Weitere Informationen und Beispiele auf webdesigner.com [@card-based-design]
[^freigabeMockups]: Alle Freigaben sind in der Beilage-Datei oder auf dem gihtub-Account einsehbar
\newpage

##Wahl des Applikation Hosters
###Asp.net Shared Hosting
Ein Asp.net Shared Hosting ist durchaus für komplexere Webapplikationen wie der Authentifizierungservice ausgerichtet. Die Kosten sind jährlich fix und nicht abhängig von der eigentlichen Nutzung. Überschreitet die Applikation den Speicherbedarf, Zugriffszahlen oder Traffic kann auf ein grösseres Paket aktualisiert werden. Wechsel zu einem kleineren Paket ist meist nur jährlich möglich. Die Skalierbarkeit ist stark eingeschränkt. Die Daten können innerhalb der Schweiz gespeichert werden. Der zuständige Systemtechniker ist meist direkt oder indirekt kontaktierbar. Spezielle Konfigurationen am Hosting sind nicht möglich. Die Datencenter sind meist nicht redundant geführt. Fällt das Datencenter aus ist, die Applikation nicht verfügbar.

###Cloud Hosting
Die Serverkosten sind direkt von der eigentlichen Nutzung abhängig. Das Hosting ist skalierbar und kann sich automatisiert an den aktuellen Nutzungsbedürfnissen anpassen. Die realen Kosten sind im vornherein schwerer zu definieren. Die Daten sind in der Cloud redundant geführt. Fällt ein Datencenter aus kann ein anderes dessen Aufgabe übernehmen. Ein Anbieter der direkt Asp.net Webservice als Hostingservice anbietet wurde nicht gefunden.[^cloudservicech] Indirekt über z.b. über ein Docker Image könnte auch ein Schweizer Anbieter berücksichtigt werden. Die genutzten Serverdienste können komplett an seinen eigenen Bedürfnissen angepasst werden.

###Entscheidung
Skalierbarkeit, nutzungsabhängige Kosten, Freiheit in der Serverdienst-Konfiguration überwiegen der einfachen Speicherung der Daten in der Schweiz. Ausserdem wird das einfache publishen (veröffentlichen) einer Web-Application aus dem Visual Studio bei allen Cloudanbieter angeboten (bei Shared Hosting sind es nur vereinzelte Anbieter), was den Development Workflow erheblich unterstützt.


[^cloudservicech]: Stand 18. Dezember 2015


##Authentifizierungsmöglichkeiten






##Domänenmodell
###Entitäten

##Systemarchitektur
Gemäss den nichtfunktionalen Anforderungen muss die Serversoftware - unter anderem - folgende Eigenschaften erfüllen:

- Hohe Verfügbarkeit von 99.9%
- Wartbarkeit
- Performance

Die Softwarearchitektur wurde im Hinblick auf diese Anforderungen erstellt.




[^dt-api]: Für die Bachelorarbeit wurde die V 9.1.13 verwendet [@datatrans-api]


