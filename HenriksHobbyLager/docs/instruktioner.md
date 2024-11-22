# Kravspecifikation: Uppgradering av Henriks HobbyLager™ 1.0

## Bakgrund

Henrik Hobbykodare startade för två år sedan sitt företag "Henriks Hobbyprylar AB" från sitt garage. Med stora drömmar och begränsade kodkunskaper skrev han ett lagerhanteringsprogram en sen kväll efter några Red Bull. Programmet, döpt till "Henriks HobbyLager™ 1.0", har förvånansvärt nog fungerat helt okej för att hålla koll på hans växande sortiment av modellflygplan, radiostyrda bilar och andra hobbyprylar.

## Nuvarande Situation

Programmet är skrivet i C# (.NET) och består av en enda fil med cirka 300 rader kod. All data lagras i en List<Product> som nollställs varje gång programmet startas om (vilket Henrik löst genom att aldrig stänga av sin dator).

Henriks affärer går överraskande bra och han har nyligen öppnat en andra butik. Nu inser han att hans "temporära" lösning kanske inte är optimal för ett växande företag.

Henrik litar inte på sin bror som tenderar att rea ut helikoptrar till halva priset. Han behöver därför en bättre lösning för att hålla koll på sitt lager.

## Önskade Förbättringar

### Fas 1 - Akut Kodstädning

Henrik har hört att något som kallas "Repository Pattern" och "Facade Pattern" kan göra koden mer professionell. Han har redan hittat interfaces på Stack Overflow som han vill använda:

- IRepository<T> för datahantering
- IProductFacade för affärslogik

Han klistrade in det i koden, men det tycks inte göra någon förändring. Han behöver din hjälp att implementera det på rätt sätt.

Allt kod finns i main, den behöver delas upp enligt programmeringsmönster och SOLID-principer.

### Önskad Arkitektur

- Implementera Repository Pattern
- Implementera Facade Pattern
- Följa SOLID-principer
- Behålla konsolapplikationsgränssnittet

### _Marcus not:_

- Jag har lagt till en ny punkt här, då jag tycker att det är viktigt att det framgår att konsolapplikationen ska behållas. Dock ska fasad och annat inte hantera GUI, huvudprogrammet ska visa information och meddelanden, ta emot input, inget annat.\_
- Main ska hållas minimalt, skapa en ny klass som hanterar allt som har med konsolgränssnittet att göra.

### Fas 2 - Persistent Lagring

Henrik är trött på att ha datorn igång dygnet runt och vill:

- Spara all data i en SQLite-databas
- Kunna stänga av programmet utan att förlora data
- Behålla möjligheten att söka efter produkter
- Kunna uppdatera Windows utan att förlora data

### Tekniska Krav

- Nuvarande funktionalitet måste behållas
- Koden ska vara "mer proffsig" (Henriks ord)
- Programmet ska fortfarande vara en konsolapplikation
- All existing data måste kunna migreras (Henrik har äntligen fått in alla 47 produkter i systemet och vägrar mata in dem igen)

## Budgetbegränsningar

Henrik kan tyvärr inte erbjuda någon ersättning då han nyligen investerat i ett stort parti radiostyrda helikoptrar, men han erbjuder 25% rabatt på alla produkter i butiken samt en signerad bild på honom bredvid sin första radiostyrda bil.

# GitHub-instruktioner för Henriks HobbyLager™ Uppgradering

## Förberedelser

1. Projektet ska forkas härifrån
2. Skapa en ny branch för ditt arbete: `feature/modernisering` eller liknande

## Git-konventioner

- Commit-meddelanden ska vara beskrivande och följa formatet:
  - `feat:` för nya funktioner
  - `refactor:` för omkodning/omstrukturering
  - `fix:` för bugfixar
  - `docs:` för dokumentation

Exempel:

```
feat: Lagt till SQLite-repository
refactor: Flyttat databaslogik till egen klass
fix: Åtgärdat bug där datum försvann vid uppdatering
docs: Uppdaterat README med installationsinstruktioner
```

## Branch-strategi

1. Huvudutveckling sker i din feature-branch
2. När en större del är klar, skapa en Pull Request till dev
3. Kommentera i PR:en vad du har gjort och varför
4. I din dator, kör `git pull origin dev` för att hämta eventuella ändringar
5. Testa koden och se till att allt fungerar

## Dokumentation

- README.md ska innehålla:
  - Kort beskrivning av projektet
  - Installationsinstruktioner
  - Hur man kör programmet
  - Eventuella konfigurationsinställningar
  - Lista över implementerade patterns
  - Kort beskrivning av databasstrukturen

## Code Review

- Kod kommer att granskas av andra studenter vid pull request
- Var beredd på att:
  - Förklara dina val av patterns
  - Motivera din kodstruktur
  - Ta emot och ge konstruktiv feedback

## Bonuspoäng från Henrik

"Jag har hört att man kan göra någon sorts 'Wiki' på GitHub. Det låter fancy! Kanske kan ni fixa det också? Jag skulle gärna ha bilder på hur man använder programmet där... och kanske en GIF-animation? Jag älskar GIF-ar!"

---

### Tillägg i ursprungliga TODO-listan:

```csharp
/*
    ...
    * Lära mig vad det där GitHub egentligen är
    * Förstå varför alla pratar om "branches" hela tiden
    * Kolla om man kan göra backup till GitHub???
    * Fråga någon vad "merge conflict" betyder (låter läskigt)
*/
```

## Framtida Visioner

Henrik drömmer om att en dag expandera till "molnet" (han är inte helt säker på vad det innebär men har hört att det är framtiden). Koden bör därför struktureras så att den är förberedd för framtida förändringar.
