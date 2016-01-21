#Architektur

##Integration der Schnittstelle
Wie in der Anforderungsanalyse <---TODO Punkt beschreiben --> und Aufgabenstellung  <---TODO Punkt beschreiben -->geschrieben, soll die Schnittstelle möglichst einfach in Bestehende Systeme integriert werden können. Bevor wir untersuchen wie wir die Integration umsetzten können, bedarf es die wichtigsten bestehenden Systeme zu kennen.

###Bestehende Systeme für Votings, Wettbewerbe und Quizes
Das bestehende Social-Media Modul wird als Teil einer Webseite in einer Webapplikation geführt. Die Webapplikation zum Verwalten von Inhalten kurz CMS werden von Statista.com mehrmals im Jahr ausgewertet [^statisticinfostatista]. Folgend ist die letzte Erhebung abgebildet:

![Nutzungsanteil CMS weltweit *Quelle:de.statista.com*](images/cms_statistik_november2015.JPG)

Die Zahlen wurden mit Werten von W3techs.com verglichen[^statisticinfow3techs]. Die Unterschiede sind für unsere Verwendung minimal und liegen im 10tels Prozentbereich. 
Beim Betrachten der Statistik fällt auf das Wordpress mit 25,2 mit Abstand am meisten genutzt wird. Alle dynamischen Webseiten unter den Top 10 basieren auf Systemen in PHP[^phpinfotag]. Adobe Dreamviewer und FrontPage sind keine Systeme welche auf dem Server betrieben werden. Sie sind Editoren welche auf dem jeweiligen Computer ausgeführt werden und danach mehrheitlich HTML, CSS und Javascript Code an den Server ausliefern. Funktionalitäten werden mit den beiden Editoren manuell geschrieben. 

#### Wodrepress PlugIn
Erweiterungen im Wordpress nennen sich Plugins. 



 

[^statisticinfostatista]: CMS Nutzungsstatistik von statista.com [@statisticinfostatista]
[^statisticinfow3techs]: CMS Nutzungsstatistik von w3techs.com [@statisticinfow3techs]
[^phpinfotag] Die Information wurde von den jeweiligen Hersteller- bzw. Communitywebseiten bezogen.