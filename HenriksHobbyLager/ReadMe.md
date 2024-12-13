##Henriks Hobby Lager 2.0
Ett litet program för att enklare lagerhantering för Henriks Hobby Lager. Som behåller data även om programmet stängs av
och kan uppdateras och funka utan att förlora data.

Hanterar produkter och kategorier, samt lagerstatus och priser.

##Installationsinstruktioner
(Utgår ifrån att man skickar publicerade programmet i en zip-fil)
Extrahera zip-filen och kör HenriksHobbyLager.exe


##Hur man kör programmet
Programmet är en konsolapplikation och körs genom att köra HenriksHobbyLager.exe

För att importera data från Henriks Hobby Lager 1.0:
Välj Visa Alla och kopiera innehållet till en .txt-fil
Starta sedan HenriksHobbyLager 2.0 och välj 0 för att importera, ange fullständig sökväg till filen, t.ex. C:\Users\Henrik\Documents\HenriksHobbyLager.txt.

##Lista över implementerade patterns
- **Repository Pattern**
- **Dependency Injection**
- **Facade Pattern**
- **Templace Pattern**

##Kort beskrivning av databasstrukturen
Ett table för all data(id, name, price, stock, category, dateCreated, dateUpdated), med en trigger för att uppdatera datum för uppdaterad produkt.