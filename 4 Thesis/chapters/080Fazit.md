#Fazit
Diese Kapitel enthält die Schlussfolgerungen, welche aus der erarbeiten Bachelorarbeit gezogen werden können, einen Ausblick


Das Hauptziel dieser Bachelorarbeit ist ein Konzept eines Services, welcher Programmieren hilft Authentifizierungen für Interaktivitäten in einem neuen oder bestehenden System einzubinden und zu verwalten. In der Recherche wurde aufgezeigt, dass diese Art von Service nicht existiert. Das Basiswissen für Authentifizierungen ist in der Recherche erweitert und aufgefrischt worden und kompakt in dieser Arbeit nieder geschrieben. Verschiedene Authentifizierungensmethoden so genannte Sicherheitsstufen wurden recherchiert und auf ihre Möglichkeiten, Grenzen und Rahmenbediengugen geprüft. Basierend auf dem recherchierten Wissen wurde mit dem Auftraggeber die Anforderungen basierend auf der Aufgabenstellung und den Vorstellungen des Auftraggebers erstellt. Diese Anforderungen führten zu den verschiedenen

Ein Prototyp dieses Authentifizierungsservice konnte entwickelt und in einem vereinfachten neuen System wie in einem bekannten und verbreiteten alten System (Wp_Poll) integriert werden. 

In der Recherche konnten die Breite an Möglichkeiten

##Ausblick
Der erstellte Prototyp wird nun dem Auftraggeber, der Firma inaffect AG übergeben. In der Übergabephase werden entstandene Änderungen- und Erweiterungswünsche insbesondere im Bereich des Designs umgesetzt. Das 1. Projekt, welches bei erfolgreicher Betaphase den Authentifizierungensservice verwenden würde, ist eine Netzwerk-Eventveranstaltungsreihe mit Aufschaltung in 3 Monaten.
Es konnte zwar gezeigt werden, dass es möglich ist mit verschiedenen Sicherheitsstufen eine genügend hohe eindeutige Authentifizierung zu erreichen, jedoch ist dies immer mit Bekanntgabe von persönlichen Daten verbunden. Die Angst, dass diese Daten missbraucht werden ist hoch. Dies wurde mehrfach ungefragt in den Bemerkungen der Umfrage erwähnt. Ein Lösungsansatz wäre für Authentifizierung wie bei Onlinezahlungen ein vertrauliches Gateway zu schaffen. Diese Bachelorarbeit beschreibt genau dieses Gateway als Konzept Authentifizierungsservice. Es müsste eine Firma den Schritt wagen das Konzept als Produkt dem Endkunden zu präsentieren, als sicheren Ort für seine Daten für fairen Ablauf von Interaktivitäten. Auf der anderen Seite sollen müssten Sicherheitsstufen mit anderen technologischen Möglichkeiten folgen, welche nicht mehr persönliche Daten benötigen.

\newpage
##Validation
Die erarbeiteten Konzepte haben im Prototyp funktioniert. Nachfolgend wird die Erfüllung der Aufgabenstellung überprüft.

-----------------------------------------------------------------------------------------------------------
__Bereich__		__Beschreibung__																__Status__
-------------	-------------------------------------------------------------------------------	-----------
__Recherche__ 	Wurde eine Marktanalyse bestehende Produkte recherchiert und dokumentiert?		erfüllt

				Wurden verschiedene Sicherheitstufen (Arten und Methoden der Sicherheits- 	
				und Identitätsüberprüfung) recherchiert und dokumentiert						erfüllt

__Analyse__     Wurden die Anforderungen der Authentifizierungsschnittstelle mit dem 			erfüllt
				Arbeitgeber analysiert und dokumentiert? 	

__Konzept__		Wurde die Evaluation von geeigneten Authentifizierungsmethoden für 				erfüllt
				verschiedene Stufen dokumentiert?	
				
				Wurden eine Spezifikation einer Prototypenapplikation für die					erfüllt
				 Authentifizierungsschnittstelle entworfen und dokumentiert?	
				
				Wurden eine Spezifikation einer Prototypenapplikation für das Verwalten		
				erfüllt der Authentifizierungsschnittstelle entworfen und dokumentiert?	

				Wurde die Software-Architektur der Authentifizierungsschnittstelle 				erfüllt
				und dessen Verwaltung konzeptioniert?
				
__Studie__		Wurde eine Studie über Akzeptanz und Geschwindigkeit(Anstrengung)				erfüllt
				von Authentifizierungsmethoden ausgearbeitet?
				
				Wurde die Durchführung der Studie dokummentiert?								erfüllt
				
				Wurde die Auswertung dokumentiert und im Prototyp integriert?					erfüllt
				
__Proof of__	Wurde der Prototypen der Authentifizierungsschnittstelle und der Verwaltung		erfüllt
__Concept__		entwickelt?

				Wurden die Studienresultate im Prototypen integriert?							erfüllt

__Fazit__		Wurde das Fazit dokumentiert?													erfüllt				
-----------------------------------------------------------------------------------------------------------

\newpage
##Schlusswort
Bei der Erarbeitung dieser Bachelorarbeit konnte ich mich intensiv mit AngularJS und den Microsoft Web Technologien auseinander setzen. Insbesondere die Implementierung der Plugin-Architektur für die Sicherheitstufen forderte die Erarbeitung eines tiefen Wissens der Core Entwicklung von .net Web API und MVC. Bei der Ladung des PlugIns zur Laufzeit musste Methoden gefunden werden um kein Memoryleek zu generieren. Dadurch konnten tiefere Einblick in die Techniken und Standards gewonnen werden. Im Zusammenhang mit den Sicherheitsstufen-PlugIns war die Definition 
