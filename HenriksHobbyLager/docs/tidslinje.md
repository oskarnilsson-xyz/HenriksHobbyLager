## Projektets Tidslinje

_"Tid är pengar, och jag har redan spenderat alla pengar på helikoptrar!"_ - Henrik

### Veckoplanering

**Dag 1-2: Kodstädning & SOLID**

- Analysera befintlig kod
- Implementera SOLID-principer
- Skapa grundläggande klassstruktur
- Första commit till GitHub

**Dag 3-4: SQLite-implementering**

- Sätt upp databasstruktur
- Implementera repository-pattern
- Migrera data från List<> till SQLite
- Testa alla CRUD-operationer

**Dag 5-7: Finputsning & Dokumentation**

- Slutföra implementationer
- Skriva dokumentation
- Code review
- Inlämning och presentation

## Rapportering till Chefen

_"Världens grymmaste Marcus vill ha koll på läget!"_

### Individuell Rapport

Varje utvecklare ska skriva en personlig rapport som innehåller:

1. **Teknisk Implementation**

   - Vilka SOLID-principer du implementerat och hur
   - Beskrivning av din databasimplementation
   - Patterns du använt och varför
   - Särskilda tekniska utmaningar och lösningar

2. **Arbetsprocess**

   - Hur du planerade arbetet
   - Vilka val du gjorde och varför
   - Lärdomar under projektets gång
   - Vad du skulle göra annorlunda nästa gång

3. **Kod-exempel**
   - Tre exempel på där du är särskilt nöjd med din kod
   - Förklaring varför dessa exempel är bra
   - Eventuella alternativa lösningar du övervägde

## Vanliga Frågor från Henrik

_"Jag har några funderingar..."_

**Q: Måste vi verkligen ändra ALLT i koden?**
A: Nej, Henrik! Vi behåller den grundläggande funktionaliteten men gör den mer robust och underhållbar.

**Q: Vad betyder egentligen "dependency injection"?**
A: Tänk på det som att ge dina klasser det de behöver istället för att de ska ta det själva. Som när du ger Anders nyckeln till lagret istället för att han bryter sig in.

**Q: Kan vi inte bara kopiera koden från Stack Overflow?**
A: Nej, Henrik. Vi ska skriva egen kod som följer best practices och är anpassad för ditt företag.

**Q: Kommer datan överleva en systemuppdatering nu?**
A: Ja, med SQLite kommer all data sparas permanent på hårddisken.

## Henriks Tekniska Ordlista

_"Här är tekniska termer som jag lärt mig (tror jag)!"_

- **Repository**: En låda där man lägger data, fast i datorn
- **Interface**: Som ett kontrakt, fast ingen läser det
- **SOLID**: Något som gör kod mer solidarisk mot andra kodsnuttar
- **SQLite**: Som en Excel-fil fast för riktiga programmerare
- **Pull Request**: När man ber snällt om att få lägga till sin kod
- **Merge**: När två kodsnuttar blir kära och flyttar ihop
- **Branch**: Som ett parallellt universum för kod

## Testscenarier

_"Här är några situationer som systemet MÅSTE klara av!"_

1. **Strömavbrott-testet**

   - Spara en produkt
   - Stäng av programmet (😱)
   - Starta programmet
   - Produkten ska fortfarande finnas kvar!

2. **Anders-testet**

   - Två personer ska kunna använda systemet samtidigt
   - Utan att data försvinner
   - Utan att något kraschar

3. **Helikopter-testet**
   - Lägg till 15 olika helikoptrar
   - Sök efter "kopt"
   - Alla helikoptrar ska hittas

## Features Som INTE Ska Ändras

_"Dessa funktioner är perfekta som de är!"_

1. Sökfunktionen (Henriks stolthet)
2. Produktvisningen med streck mellan varje produkt
3. Menystrukturen
4. Felmeddelanden (Henrik skrev dem själv!)

## Redovisning

_"Visa mig magin!"_

1. **Grupp Demonstration (15 min)**

   - Visa systemet i drift
   - Demonstrera SOLID-implementationer
   - Visa databashantering
   - Förklara ett särskilt intressant problem och din lösning

2. **Kodgranskning**

   - Genomgång av Pull Request
   - Förklaring av arkitekturval
   - Svar på frågor från andra utvecklare

3. **Dokumentationsgenomgång**
   - README.md
   - Individuell rapport
   - Tekniska val och motiveringar

_"Lycka till! Och kom ihåg - ingen kod är perfekt, men vissa kodar är mer solidariska än andra!"_

- Henrik Hobbykodare, VD och självutnämnd kodexpert
