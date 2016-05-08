

#Einführung


##Motivation


Die Digitalisierung fordert die Schweizer Wirtschaft heraus. Ob Banken, Pharmaindustrie, Detailhandel oder Medienhäuser – es gibt keine Branche, die nicht vor fundamentalen Veränderungen steht.[^digitalerevolutionhz] Da verwundert es nicht, dass Wettbewerbe oder Kreuzworträtsel nicht nur auf den letzten Seiten der Magazinen oder Zeitungen abgedruckt werden, sondern vermehrt online publiziert und durchgeführt werden und dass bei meinungsbildenden Umfragen oder Abstimmungen weniger auf Telefonumfragen zurückgegriffen wird, sondern immer mehr Umfragen im Internet durchgeführt werden. 

In der Schweiz konnten die grossen Medienhäuser ihre Zugriffszahlen auch 2015 steigern und ihre Toprangierungen beibehalten.[^netmatrixaudit] Um ihren Werbegewinn und ihre Resonanz zu bewahren oder sogar auszubauen, sind Medien darauf angewiesen, dass ihre Stories bzw. Inhalte auf den Social Media Kanälen verlinkt und so viral verbreitet werden. Neben altbekannten plakativen Titeln und interessanten Bildern beleben die Medienhäuser immer mehr ihren Inhalt mit so genannten "Playful Content" oder auf Deutsch: Mit Interaktivitäten. Dabei handelt es sich um Abstimmungen, Wettbewerbe und Umfragen oder andere Interaktivitäten im Zusammenhang mit dem verfassten Inhalt. Diese Social-Module werden gerne verlinkt und fördern so die Verbreitung des Contents und dadurch einen Anstieg der Besucherzahlen.
 
Bei den meisten angebotenen Umfragen, Abstimmungen und Wettbewerben ist es mit geringem technischen Verständnis möglich mehrfach teilzunehmen oder gefälschte Daten zu übermitteln. Dies ist auf zu einfach realisierte Programmierungen zurückzuführen, was der Glaubwürdigkeit solcher Angebote schadet. Interaktivitäten bedürfen somit einer Authentifizierung, um Betrug oder falschen Stimmabgaben vorzubeugen. Die Eigenentwicklung einer angemessenen Authentifizierung für eine Interaktivität übersteigt meist die kleinen Budgets für diese Angebote. 

Die Glaubwürdigkeit der Umfragen, Abstimmungen und Wettbewerbe ist durch die aktuelle Situation gefährdet und soll wiederhergestellt werden. Deshalb soll diese Bachelorarbeit die Möglichkeiten eines Authentifizierungsservices erörtern. Mit dieser sollen Programmierer über eine visuelle Oberfläche die Bedürfnisse eines Angebots konfigurieren und in ihren jeweiligen Modulen einbinden können.

[^digitalerevolutionhz]:[@digitalerevolutionhz]
[^netmatrixaudit]: [@netmatrixaudit] 

\newpage

##Aufgabenstellung

###Ausgangslage
Bei populären Medienhäusern und grösseren Unternehmen werden häufig Umfragen, Abstimmungen oder Gewinnspiele im Internet durchgeführt. Bei den meisten angebotenen Programmen ist es relativ simpel (gewisses Know-How vorausgesetzt) mehrfach teilzunehmen oder gefälschte Daten zu übermitteln. Dies ist auf zu einfach realisierte Programmierungen zurückzuführen, was der Glaubwürdigkeit solcher Angebote schadet. Social-Media Module wie Umfragen, Abstimmungen oder Wettbewerbe bedürfen somit einer Authentifizierung, um Betrug oder falschen Stimmabgaben vorzubeugen. Die Eigenentwicklung der gewünschten Authentifizierung für ein Modul übersteigt meist die kleinen Budgets für diese Angebote. Die Firma inaffect AG erstellt Individuallösungen und Webapplikationen im Bereich neuer Medien. Sie ist auf der Suche nach einem Authentifizierungsservice, welche ihre Programmierer mit einer visuellen Oberfläche den Bedürfnissen eines Angebots konfigurieren und in ihr jeweiliges Modul einbinden können.

###Ziel der Arbeit
Es soll ein Konzept für eine Authentifizierungsschnittstelle erstellt werden. Dieser Service wird über mehrere Sicherheitsstufen verfügen, die sich in der Menge und Art der zu übermittelnden User-Informationen unterscheiden. Diese Stufen sollen für den Programmierer eines Angebots über eine grafische Oberfläche individuell konfigurierbar sein. Das Konzept soll in Form eines Prototypen umgesetzt werden. 
Weiter soll mit mehreren Usern eine Studie zur Akzeptanz und Geschwindigkeit der verschiedenen Sicherheitsstufen durchgeführt werden. Die Ergebnisse der Studie werden im Prototyp integriert sein und sollen den Programmierer bei der Auswahl der Sicherheitsstufe unterstützen. 

###Aufgabenstellung
Im Rahmen der Bachelorarbeit werden vom Studenten folgende Aufgaben durchgeführt:

Recherche

- Research und Marktanalyse bestehender Produkte
- Arten und Methoden der Sicherheits- und Identitätsüberprüfung
- Durchführung einer Anforderungsanalyse für eine Authentifizierungsschnittstelle

Konzept

- Evaluation von geeigneten Authentifizierungsmethoden für verschiedene Stufen
- Spezifikation einer Prototypenapplikation für die Authentifizierungsschnittstelle
- Spezifikation einer Prototypenapplikation für das Verwalten der Authentifizierungsschnittstelle
- Erstellen einer Software-Architektur für die Authentifizierungsschnittstelle und dessen Verwaltung
- Ausarbeiten einer Studie über Akzeptanz und Geschwindigkeit von Authentifizierungsmethoden

\newpage

Studie

- Durchführen der ausgearbeiteten Studie
- Auswertung der Studie

Proof of Concept

- Entwicklung eines Prototypen der Authentifizierungsschnittstelle und der Verwaltung, basierend auf den erarbeiteten Spezifikationen und Architektur
- Integration der Studienresultate im Prototypen

Fazit

###Erwartete Resultate
Im Rahmen dieser Bachelorarbeit werden vom Studenten folgende Resultate erwartet:

Recherche

- Dokumentation des Research und Marktanalyse bestehender Produkte
- Dokumentation der Arten und Methoden der Sicherheits- und Identitätsüberprüfung

Analyse

- Dokumentierte Anforderungsanalyse für eine Authentifizierungsschnittstelle

Konzept

- Dokumentation der Evaluation von geeigneten Authentifizierungsmethoden für verschiedene Stufen
- Dokumentierte Spezifikation einer Prototypenapplikation für die Authentifizierungsschnittstelle
- Dokumentierte Spezifikation einer Prototypenapplikation für das Verwalten der Authentifizierungsschnittstelle
- Dokumentation der Software-Architektur für die Authentifizierungsschnittstelle und dessen Verwaltung
- Dokumentation des Ausarbeitens einer Studie über Akzeptanz und Geschwindigkeit von Authentifizierungsmethoden

Studie

- Dokumentation der Studien-Durchführung
- Dokumentation der Auswertung der Studie


Proof of Concept

- Dokumentierte Entwicklung eines Prototypen der Authentifizierungsschnittstelle und der Verwaltung, basierend auf den erarbeiteten Spezifikationen und Architektur
- Dokumentierte Integration der Studienresultate im Prototypen
- Dokumentiertes Fazit



##Rahmenbedingungen der Bachelorarbeit
Die vorliegende Bachelorarbeit umfasst gemäss Regelment unter anderem folgende Punkte:

- Der offizielle Projektstart ist der 18. November 2015. Das Projekt muss bis
spätestens 18.05.2016 abgegeben werden.
- Die Bachelorarbeit muss zwei Wochen vor der Präsentation abgegeben werden
- Eine Bachelorarbeit besteht aus einer konzeptionellen Arbeit und deren Umsetzung. Der
Schwerpunkt liegt auf dem konzeptionellen Teil, in dem die theoretischen und methodischen
Grundlagen einer Entwicklung oder eines Konzeptes ausgearbeitet und dargelegt
werden. Im Umsetzungsteil erfolgt anschliessend die Beschreibung der Implementierung
bzw. der Anwendung. Die Umsetzung besteht zumindest aus einem „Proof of Concept“,
um die prinzipielle Realisierbarkeit darzulegen. Die Bachelorarbeit ist als praxisnahes Projekt
durchzuführen.
- Der Aufwand für die Fertigstellung einer Bachelorarbeit beträgt insgesamt mindestens 360
Stunden.
- Die Bachelorarbeit hat die Form eines technischen Berichtes. [^bachelorreglement]

[^bachelorreglement]: [@bachelorreglement]



