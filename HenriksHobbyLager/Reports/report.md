# Individuell Rapport

Svara på frågorna nedan och lämna in det som en del av din inlämning.

## Hur fungerade gruppens arbete?
Bra *_* *_*
## Beskriv gruppens databasimplementation
En enkel singel table databas med en trigger för att hantera datum för uppdaterad produkt.
Det finns absolut mening med att köra en robustare databas om kunden har större krav på features. Men att framtidssäkra
den i detta steget kändes out of scope.
## Vilka SOLID-principer implementerade ni och hur?
Alla klasser gör bara en sak, men kanske något edge-case för att inte ha fööör många klasser.
Massor av interfaces för att framtidssäkra och dela upp koden så den blir enkel att förstå och underhålla.
Minimerat beroendet mellan klassen genom att undvika konkreta klasser och istället använda interfaces.
Main-klassen är nog en out-lier här. Jag tror man hade kunnat inetiera alla grejer i en specifik klass och sedan skicka dem till
ConsoleMenuHandler som skickar vidare vid behov. Men jag behövde sluta polera någonstans.
## Vilka patterns använde ni och varför?
Repository och Facade pattern såklart. Men även Dependency Injection genom constructors i tex ProductService och ConsoleMenuHandler.
Template pattern används i ProductFacade skapa ramverk till andra klasser att använda.
## Vilka tekniska utmaningar stötte ni på och hur löste ni dem?
Det svåraste för mig var att fatta hur DB skapandet och initierandet funkade, visade sig mest vara en tanke vurpa men det är vad som tog mest tid.
Dependency Injection var också en utmaning, är inte helt van vid att hålla alla bollar i luften som blir med interfaces och patterns.
## Hur planerade du ditt arbete?
Jag följde inte riktigt backloggen, för mitt sätt att tänka var det viktigt att få till ProductRepository så att jag fick en bättre bild av
hur programmet skulle aggera med och mot databasen. 
Nästa steg vad att fixa ut meny och funktioner till ConsoleMenuHandler och sedan sy ihop alla delar som jag skapat, för att sedan se till att jag
hade ett fungerande program som uppfyllde MVP för Henrik.
Därefter så gjorde jag en stor refactoring av ConsoleMenuHandler för att uppnå bättre SOLID-principer. Följt att implementering av att kunna importera
data från programmet som tuffar på Henriks dator.
Slutligen så gjorde jag en sista genomgång av all kod, kommenterade TODOs som jag hade gjort om jag skulle lägga ännu mer tid.
## Vilka dela gjorde du?

## Vilka utmaningar stötte du på och hur löste du dem?

## Vad skulle du göra annorlunda nästa gång?
