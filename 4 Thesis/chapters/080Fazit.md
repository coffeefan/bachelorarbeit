#Fazit


##Ausblick
Der erstellte Prototyp wird nun dem Auftraggeber, der Firma inaffect AG, übergeben. In der Übergabephase werden entstandene Änderungs- und Erweiterungswünsche umgesetzt. Das erste Projekt, welches bei erfolgreicher Betaphase den Authentifizierungsservice verwenden soll, ist eine Netzwerk-Eventveranstaltungsreihe mit Aufschaltungsdatum in drei Monaten.\
Einen Verkauf an oder Lizenzierung mit einem grösseren Medienunternehmen wäre möglich. Ein grösseres Medienunternehmen möchte vielfach  alles inhouse betreiben. Diesem Wunsch entspricht das Konzept des Authentifizierungsservice. Der Service kann auch auf jedem besseren IIS-Server, auf welchem Microsoft-MVC und Web-API ausführbar und eine SQL-Datenbank installiert ist, betrieben werden. Die ausgelagerten Konfigurationsdateien und Views erlauben es, die Authentifizierung ohne neue Kompilierung der Logik den optischen und inhaltlichen Ansprüchen anzupassen.
\
Es konnte gezeigt werden, dass es möglich ist, mit verschiedenen Sicherheitsstufen eine genügend eindeutige Authentifizierung zu erreichen, jedoch ist dies immer mit Bekanntgabe von persönlichen Daten verbunden. Die Angst, dass diese Daten missbraucht werden, ist hoch. Dies wurde mehrfach ungefragt in den Bemerkungen der Studienumfrage erwähnt. Ein Lösungsansatz wäre, für Authentifizierungen wie bei Onlinezahlungen ein vertrauliches Gateway zu schaffen. Diese Bachelorarbeit beschreibt genau dieses Gateway als Konzept. Nun müsste nur noch eine Firma den Schritt wagen, dieses Konzept als Produkt zu vermarkten und es dem Endkunden bekannt zu machen.


##Offene Fragen
Q1 Wie soll das Konzept als Produkt einem breiten Publikum bekannt gemacht werden? \
Q2 Wie kann dem Publikum hinreichend Sicherheit für das Konzept vermittelt werden?
Q2 Wie skaliert das System bei gleichzeitiger Nutzung von über 500 Endbenutzern?

##Limitationen
Im Prototyp sind vier Sicherheitsstufen implementiert worden. Für eine grössere Konfigurationswahl sollen weitere Sicherheitsstufen integriert werden. Der Authentifizierungsservice verrechnet die Kosten noch nicht selbständig an den Programmierer weiter. Hier sollte ein geeignetes Preismodell definiert und eine automatisierte Abrechnung implementiert werden. Das Produkt ist für die Deutschschweiz entwickelt worden. Auch wenn Multilingualität keine Anforderung war, wurde sie angedacht und in grossen Teilen des Prototyps implementiert. Für den multilingualen Betrieb müssten insbesondere Textbausteine für andere Sprachgebiete entworfen werden und in den fehlenden Teilen die Multilingualität implementiert werden. 


\newpage
##Validation
Die erarbeiteten Konzepte haben im Prototyp funktioniert. Nachfolgend wird die Erfüllung der Aufgabenstellung überprüft.

------------------------------------------------------------------------------------------------------------------------------------	
__Bereich__		__Beschreibung__															__Status__  	__Verweise__
-------------	---------------------------------------------------------------------------	--------------- ------------------------
__Recherche__ 	Wurde eine Marktanalyse bestehender Produkte recherchiert und 				erfüllt     	[Martkanalyse]
				dokumentiert?		
				
				Wurden verschiedene Sicherheitsstufen (Arten und Methoden der Sicherheits- 	erfüllt     	[Authentifizierungs-Komponenten]           
				und Identitätsüberprüfung) recherchiert und dokumentiert?						
																											
__Analyse__     Wurden die Anforderungen der Authentifizierungsschnittstelle mit dem 		erfüllt     	[Anforderungen]
				Arbeitgeber analysiert und dokumentiert? 	                                            	
																											
__Konzept__		Wurde die Evaluation von geeigneten Authentifizierungsmethoden für 			erfüllt     	[Sicherheitsstufen integrieren],
				verschiedene Stufen dokumentiert?	                                                    	[Sicherheitsstufen bewerten]
																											
				Wurden eine Spezifikation einer Prototypenapplikation für die				erfüllt     	[Konzept]
				 Authentifizierungsschnittstelle entworfen und dokumentiert?	                        	
																											
				Wurde eine Spezifikation einer Prototypenapplikation für das Verwalten		erfüllt     	[Konzept]            
				der Authentifizierungsschnittstelle entworfen und dokumentiert?	                					
																											
				Wurde die Software-Architektur der Authentifizierungsschnittstelle 			erfüllt     	[Konzept]   
				und dessen Verwaltung konzeptioniert?                                                   	
																											
__Studie__		Wurde eine Studie über Akzeptanz und Geschwindigkeit(Anstrengung)			erfüllt     	[Studie]
				von Authentifizierungsmethoden ausgearbeitet?                                           	Anhang Studie
																											
				Wurde die Durchführung der Studie dokumentiert?								erfüllt     	[Studie]
																											
				Wurde die Auswertung dokumentiert und im Prototyp integriert?				erfüllt     	[Auswertung]
																											[Visualisierung von Daten],
																											[Visualisierung der Umfrageresultate]
																											
__Proof of__	Wurden die Prototypen der Authentifizierungsschnittstelle und der 			erfüllt     	[Proof of Concept],
__Concept__		Verwaltung entwickelt?                                                                   	[AngularJS-Konfigurator],
																											[Authentifizierungs-Lightbox]
																											
				Wurden die Studienresultate im Prototypen integriert?						erfüllt     	[Visualisierung von Daten],
																											[Visualisierung der Umfrageresultate]
																											
__Fazit__		Wurde das Fazit dokumentiert?												erfüllt			[Fazit]				
----------------------------------------------------------------------------------------------------------- ---------------------
	
\newpage
##Schlusswort
Bei der Erarbeitung dieser Bachelorarbeit konnte ich mich intensiv mit AngularJS und den Microsoft Web-Technologien auseinandersetzen. Insbesondere die Implementierung der Plugin-Architektur für die Sicherheitsstufen forderte die Erarbeitung eines tiefen Wissens der Core-Entwicklung von .Net Web -PI und MVC. Bei Ladungen des PlugIns zur Laufzeit mussten Methoden gefunden werden, um kein Memoryleak zu generieren. Dadurch konnten tiefere Einblick in die Techniken und Standards gewonnen werden. Im Zusammenhang mit den Sicherheitsstufen-PlugIns war die Definition des geeigneten Interfaces eine konzeptionelle Herausforderung. Einerseits sollte die Definition möglichst flexibel sein um jegliche Arten von Sicherheitsstufen einzubinden. Andererseits sollten doch klare Richtlinien geschaffen werden, um nicht unnötig mehrfach den gleichen Code schreiben oder mit komplexen Algorithmen die Daten prüfen zu müssen. \
Ich konnte im Verlauf des Projekts alle gesetzten Ziele erreichen.(Siehe Kapitel [Validation]). Die Bachelorarbeit hatte viele verschiedene Komponenten, welche ineinander spielen mussten. Die breite Abstützung des gewählten Themas, sowie die Terminplanung dieser Arbeit war durchaus gewagt. Doch gerade diese Freiheit ermöglichte es mir, tief in das Themengebiet vorzustossen. Der klare Projektplan verhalf mir dabei immer wieder fokussiert zu arbeiten.
Das Vorgehen der Anforderungsanalyse habe ich in Anlehnung an das Modul "Software Engineering" und basierend auf dem Buch "Basiswissen Requirements Engineering" umgesetzt. Rückblickend bin ich überrascht, dass sich in dieser Zeit so viel Unklares und Unausgesprochenes basierend auf diesem Muster herausfinden liess. Dieses Vorgehensmuster werde ich deshalb auch in Zukunft versuchen einzusetzen.\
Bei der Studie hat mich überrascht, dass so viele Personen davon ausgehen, dass Sie noch nie an einer Umfrage teilgenommen haben, an welcher gemogelt hätte werden können.\
Mit dem Resultat meiner Arbeit bin ich sehr zufrieden. Nicht nur durfte ich durch das Erarbeiten der Studie Einiges lernen, sondern ich konnte auch einen funktionsfähigen Prototypen zur Lösung der Problematik für den Arbeitgeber entwickeln. Es hat mir viel Spass bereitet, neue Technologien und Lösungsansätze zu erkunden.
