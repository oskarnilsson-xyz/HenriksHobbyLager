##Henriks Hobby Lager 2.0
Ett litet program f�r att enklare lagerhantering f�r Henriks Hobby Lager. Som beh�ller data �ven om programmet st�ngs av
och kan uppdateras och funka utan att f�rlora data.

Hanterar produkter och kategorier, samt lagerstatus och priser.

##Installationsinstruktioner
(Utg�r ifr�n att man skickar publicerade programmet i en zip-fil)
Extrahera zip-filen och k�r HenriksHobbyLager.exe


##Hur man k�r programmet
Programmet �r en konsolapplikation och k�rs genom att k�ra HenriksHobbyLager.exe

F�r att importera data fr�n Henriks Hobby Lager 1.0:
V�lj Visa Alla och kopiera inneh�llet till en .txt-fil
Starta sedan HenriksHobbyLager 2.0 och v�lj 0 f�r att importera, ange fullst�ndig s�kv�g till filen, t.ex. C:\Users\Henrik\Documents\HenriksHobbyLager.txt.

##Lista �ver implementerade patterns
- **Repository Pattern**
- **Dependency Injection**
- **Facade Pattern**
- **Templace Pattern**

##Kort beskrivning av databasstrukturen
Ett table f�r all data(id, name, price, stock, category, dateCreated, dateUpdated), med en trigger f�r att uppdatera datum f�r uppdaterad produkt.