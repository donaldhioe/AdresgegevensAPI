# AdresgegevensAPI
Voordat de API's kunnen worden gebruikt, zijn er eerst een aantal programma's nodig:

1.  Visual Studio Community 2022(Betaalde versie kan ook).
2.  .NET Core 6.0 is het meest aangeraden om de applicatie te runnen.
3.  Start de applicatie op om de API's te gebruiken via Swagger.

Ik ben tevreden over het gemaakte project voor de .NET case. Er waren een aantal onderdelen dat niet volledig was gelukt om te implementeren.

Ik ben trots op de onderdelen van:

De framework gebruiken om de API's gemakkelijker te implementeren. Met de framework scheelde wat tijd om het hele project op te zetten, dus scheelde het tijd om aan andere onderdelen aan te werken.

De SQLite database opzetten om de data daar op te slaan. Met de database was het simpeler dan andere databases zoals MySQL om snel een lokale database op te zetten.


Ik ben minder tevreden op de onderdelen van:

Het zou mogelijk zijn dat ik bepaalde packages heb geinstalleerd die toch niet nodig waren geweest voor het project. Het was eerst onderzoeken welke packages nodig waren om API's te implementeren.

Het is niet volledig gelukt om alles goed te kunnen filteren of te sorteren. Het is alleen mogelijk om van alle kolommen van de tabel eenmalig te sorteren bij de API. Bij het sorteren wilde ik het op een ander manier code implementeren, maar huidige oplossing is via if statements om te checken welk kolom wordt gesorteerd.

Voor het filteren was het alleen mogelijk om van één kolom van de tabel filteren bij de API. Met meerdere kolommen is het niet gelukt.

Voor de geolocation was het niet gelukt om een goede API te vinden, maar ik heb wel ideeën wat er wel nodig is om de afstand te kunnen berekenen.

Om de afstand van twee locaties te berekenen heb je voor beide locaties de longitude en latitude nodig om voor coördinaten te krijgen van de locaties. 

De latitude en longitude zouden mogelijk te vinden zijn als de adres en andere gegevens bekend zijn.

In de adresgegevens zijn gegevens van straat, huisnummer, postcode, plaats en land bekend. Dus de kans dat je de verkeerde longitude of latitude terugkrijgt zou klein zijn.

Als de twee coördinaten bekend zijn zou het programma loodrecht van elkaar de afstand berekenen in kilometers.

