# Kravspecifikation: Uppgradering av Henriks HobbyLager™ 2.0

_"För att min bror ska sluta sälja helikoptrar till halva priset!"_

## PROJEKTÖVERSIKT

- Leveranstid: 1 vecka
- Startdatum: Omgående
- Prioritet: AKUT (datorn behöver verkligen stängas av)
- Budget: 25% rabatt på alla produkter i butiken

## Bakgrund

Henrik Hobbykodare startade för två år sedan sitt företag "Henriks Hobbyprylar AB" från sitt garage. Med stora drömmar och begränsade kodkunskaper skrev han ett lagerhanteringsprogram en sen kväll efter några Red Bull. Programmet, döpt till "Henriks HobbyLager™ 1.0", har förvånansvärt nog fungerat helt okej för att hålla koll på hans växande sortiment av modellflygplan, radiostyrda bilar och andra hobbyprylar.

## Nuvarande Situation

Programmet är skrivet i C# (.NET) och består av en enda fil med cirka 300 rader kod. All data lagras i en List<Product> som nollställs varje gång programmet startas om (vilket Henrik löst genom att aldrig stänga av sin dator).

Henriks affärer går överraskande bra och han har nyligen öppnat en andra butik. Nu inser han att hans "temporära" lösning kanske inte är optimal för ett växande företag.

## Önskade Förbättringar

### Fas 1 - Akut Kodstädning

Henrik har hört att något som kallas "Repository Pattern" och "Facade Pattern" kan göra koden mer professionell. Han har redan hittat interfaces på Stack Overflow som han vill använda:

- IRepository<T> för datahantering
- IProductFacade för affärslogik

### Fas 2 - Persistent Lagring

Henrik är trött på att ha datorn igång dygnet runt och vill:

- Spara all data i en SQLite-databas med Entity Framework
- Kunna stänga av programmet utan att förlora data
- Behålla möjligheten att söka efter produkter

### Tekniska Krav

- Nuvarande funktionalitet måste behållas
- Koden ska vara "mer proffsig" (Henriks ord)
- Programmet ska fortfarande vara en konsolapplikation
- All existing data måste kunna migreras (Henrik har äntligen fått in alla 47 produkter i systemet och vägrar mata in dem igen)

## Budgetbegränsningar

Henrik kan tyvärr inte erbjuda någon ersättning då han nyligen investerat i ett stort parti radiostyrda helikoptrar, men han erbjuder 25% rabatt på alla produkter i butiken samt en signerad bild på honom bredvid sin första radiostyrda bil.

## Solidarisk Kod

Henrik har efter mycket googlande förstått att koden behöver bli mer "SOLID". Efter att ha läst på Stack Overflow i 15 minuter har han kommit fram till följande krav:

### Henriks tolkning av SOLID:

1. **S - Single Responsibility**

   > "Varje klass ska bara göra en sak, precis som mina anställda. Min senaste praktikant försökte både hantera kassan och fylla på lager samtidigt... Det gick inte bra."

2. **O - Open/Closed**

   > "Koden ska vara öppen för påbyggnad men stängd för ändringar. Ungefär som min butik - folk får gärna komma in men de får inte ändra på prislappar!"

3. **L - Liskov Substitution**

   > "Något med att klasser ska kunna bytas ut mot varandra? Som när jag tar semester och min bror tar över butiken. Fast han sålde alla helikoptrar till halva priset förra gången...:( "

4. **I - Interface Segregation**

   > "Interface ska vara små och fokuserade. Som våra kvitton - ingen vill ha en novell när de handlat en radiostyrd bil!"

5. **D - Dependency Inversion**
   > "Högre nivåer ska inte bero på lägre nivåer... Precis som att jag som VD inte behöver veta exakt hur Anders packar paketen, bara att de blir packade!"

### Tillägg i TODO-listan:

```csharp
/*
    ...
    * Göra koden mer solidarisk (SOLID)
    * Dubbel-kolla om det verkligen heter "solidarisk"
    * Fråga Anders om han fattar det där med beroenden
    * Kanske rita en fin plansch om SOLID och hänga i personalrummet?
    * Läsa på mer om objektorienterad programmering (OOP... eller var det OPS?)
*/
```

### Tekniska Implementationskrav

- Koden ska följa SOLID-principerna (på riktigt, inte bara Henriks tolkningar)
- Varje princip ska implementeras på minst ett tydligt ställe
- Dokumentera i README.md var och hur SOLID-principerna används
- Kommentera i koden var SOLID-principerna tillämpas (för Henriks skull)

### Henriks Framtidsvision

> "Jag har en dröm om att en dag ha ett system som är så solidariskt att det nästan driver sig självt. Tänk er - en kodbaserad personal som aldrig tar lunchrast eller säljer helikoptrar till halva priset!
>
> PS. Kan vi få systemet att automatiskt beställa nya Red Bull när lagret börjar ta slut? Bara en tanke..."

## Definition of Done

### En feature

1. Koden är testad och fungerar
2. Dokumentationen är uppdaterad
3. Koden följer C# kodstandard
4. En Pull Request till dev är skapad
5. Kod-review är genomförd

### Projektet

1. All kod fungerar och följer SOLID
2. Dokumentation är komplett
3. Individuell rapport är inlämnad
4. Pull Request till main är skapad
5. Kod-review är genomförd
6. Redovisning är genomförd
7. Chefen (Marcus) är nöjd!

## Framtida Visioner

Henrik drömmer om att en dag expandera till "molnet" (han är inte helt säker på vad det innebär men har hört att det är framtiden). Koden bör därför struktureras så att den är förberedd för framtida förändringar.
