#Architektur

##Integration der Schnittstelle
Wie in der Anforderungsanalyse <!--TODO Punkt beschreiben --> und Aufgabenstellung  <!--TODO Punkt beschreiben -->geschrieben, soll die Schnittstelle möglichst einfach in Bestehende Systeme integriert werden können. Bevor wir untersuchen wie wir die Integration umsetzten können, bedarf es die wichtigsten bestehenden Systeme zu kennen.

###Bestehende Systeme für Votings, Wettbewerbe und Quizes
Das bestehende Social-Media Modul wird als Teil einer Webseite in einer Webapplikation geführt. Die Webapplikation zum Verwalten von Inhalten kurz CMS werden von Statista.com mehrmals im Jahr ausgewertet [^statisticinfostatista]. Folgend ist die letzte Erhebung abgebildet:

![Nutzungsanteil CMS weltweit *Quelle:de.statista.com*](images/cms_statistik_november2015.JPG)

Die Zahlen wurden mit Werten von W3techs.com verglichen[^statisticinfow3techs]. Die Unterschiede sind für unsere Verwendung minimal und liegen im 10tels Prozentbereich. 
Beim Betrachten der Statistik fällt auf das Wordpress mit 25,2 mit Abstand am meisten genutzt wird. Alle dynamischen Webseiten unter den Top 10 basieren auf Systemen in PHP[^phpinfotag]. Adobe Dreamviewer und FrontPage sind keine Systeme welche auf dem Server betrieben werden. Sie sind Editoren welche auf dem jeweiligen Computer ausgeführt werden und danach mehrheitlich HTML, CSS und Javascript Code an den Server ausliefern. Funktionalitäten werden mit den beiden Editoren manuell geschrieben. 

#### Wodpress PlugIn
Erweiterungen im Wordpress nennen sich Plugins. Die Plugins können direkt über das CMS-Backend eingespielt werden. Alternativ können Sie natürlich manuell installiert werden. Zum Beispiel in dem man ein Plugin selber Programmiert oder beim Hersteller oder über das Plugin-Verzeichnis von Wordpress[^plugin-verzeichnis] downloadedt. Wordpress sammelt zugleich die aktiven Installationen der PlugIns (sofern man als Entwickler den Informationsaustausch nicht unterbindet). Die Gesamtzahl wird im CMS-Backend Wordpress und auf Ihrer Plugin-Verzeichnis Webseite[^plugin-verzeichnis] veröffentlicht. Dank dieser Kennzahl kann nun die meist verbreiteten Plugins herrausgefunden werden. 

<!--TODO Auflistung von bekannten Plugins -->


#### Möglichkeit ein Wordpress PlugIn zu erweitern
Wordpress basiert auf einem sogennanten Hook-System. Übersetzt man "Hook" vom Englischen ins Deutsch erhält Haken, Aufhänger oder Greifer. Ein Hook ist im Wordpress eine definierte Code-stelle bei der man seinen eigenen Code  einhaken kann. Der PlugIn Entwickler definiert diese Hooks um anderen PlugIns oder Funktionalitäten zu erlauben sein PlugIn zu erweitern. Auch der Core vom Wordpress enthält solche Hooks. Dadurch soll verhindert werden, dass PlugIn's oder der Core von Wordpress direkt umgeschrieben werden muss und dann nicht mehr einfach so unabhängig upgedatet werden kann. Um unsere Schnittstelle einzubinden, könnten wir auf den ersten Blick also solche Hooks verwenden. Dieser "Hook"/Haken hat lustigerweise auch einen Haken: Der PlugIn-Entwickler kann selbständig bestimmen ob und wo er solche Hooks einsetzen will und welche Möglichkeiten dann zur Verfügung stehen. Kommerzielle PlugIn's verfolgen vielfach den Weg möglichst verschlossen zu agieren um mögliche Erweiterungen monetär umzusetzen und so eine Abhängigkeit zu erzeugen. Im nächsten Kapitel ista analysieret ob und wie die grossen Social-Media Module von Wordpress Hooks einsetzen.

##### Wordpres Social-Media Hooks
<!--TODO Beschreibung von bekannten Plugins Hooks-->
 

[^statisticinfostatista]: CMS Nutzungsstatistik von statista.com [@statisticinfostatista]
[^statisticinfow3techs]: CMS Nutzungsstatistik von w3techs.com [@statisticinfow3techs]
[^phpinfotag] Die Information wurde von den jeweiligen Hersteller- bzw. Communitywebseiten bezogen.
[^plugin-verzeichnis] Das Pluginverzeichnis befindet sich unter https://de.wordpress.org/plugins/ 