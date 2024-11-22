# Backlog eller tl;dr av kravspec

### Backlog för Uppgradering till **Henriks HobbyLager™ 2.0**

#### **Backlog-struktur:**

1. **Epics**: Huvudmål eller större uppgifter
2. **Features**: Specifika funktioner att implementera inom varje epic
3. **Tasks**: Mindre uppgifter för att genomföra features

---

### **Epic 1: Kodstädning och SOLID-implementering**

- **Feature 1.1**: Analysera och refaktorisera befintlig kod

  - **Task 1.1.1**: Identifiera nuvarande kodproblem
  - **Task 1.1.2**: Flytta ut logik från `Main()` till separata klasser
  - **Task 1.1.3**: Dokumentera nuvarande kodstruktur och problemområden

- **Feature 1.2**: Implementera Repository Pattern

  - **Task 1.2.1**: Implementera gränssnittet `IRepository<T>` med CRUD-metoder
  - **Task 1.2.2**: Implementera en konkret `ProductRepository`-klass
  - **Task 1.2.3**: Ersätt nuvarande List<Product> med repository-anrop

- **Feature 1.3**: Implementera Facade Pattern

  - **Task 1.3.1**: Skapa gränssnittet `IProductFacade` för affärslogik
  - **Task 1.3.2**: Implementera en konkret `ProductFacade`-klass
  - **Task 1.3.3**: Integrera facaden i konsolapplikationen

- **Feature 1.4**: Tillämpa SOLID-principerna
  - **Task 1.4.1**: Implementera Single Responsibility i alla klasser
  - **Task 1.4.2**: Kontrollera Open/Closed i metod- och klassdesign
  - **Task 1.4.3**: Se till att Liskov Substitution fungerar med gränssnitt
  - **Task 1.4.4**: Segregera stora interfaces till mindre, fokuserade
  - **Task 1.4.5**: Inför Dependency Injection där det är relevant

---

### **Epic 2: Persistent Lagring med SQLite**

- **Feature 2.1**: Sätt upp SQLite-databas

  - **Task 2.1.1**: Skapa en SQLite-databas för produkter
  - **Task 2.1.2**: Designa databasstrukturen (tabeller och relationer)
  - **Task 2.1.3**: Skapa migrationsfiler för initial databasstruktur

- **Feature 2.2**: Integrera Entity Framework

  - **Task 2.2.1**: Konfigurera Entity Framework för SQLite
  - **Task 2.2.2**: Koppla `ProductRepository` till databasen
  - **Task 2.2.3**: Implementera databasoperationer för CRUD-funktioner

- **Feature 2.3**: Lägg till sökfunktion
  - **Task 2.3.1**: Skapa metoder för att söka i databasen
  - **Task 2.3.2**: Optimera sökning med index om möjligt
  - **Task 2.3.3**: Testa sökfunktionen för att inkludera alla produkttyper

---

### **Epic 3: Konsolapplikationens struktur**

- **Feature 3.1**: Strukturera konsolgränssnittet

  - **Task 3.1.1**: Skapa en separat klass för menyhantering (`ConsoleMenuHandler`)
  - **Task 3.1.2**: Flytta input/output-operationer från `Main()` till `ConsoleMenuHandler`
  - **Task 3.1.3**: Dokumentera gränssnittets struktur och arbetsflöde

- **Feature 3.2**: Skapa robusta felmeddelanden
  - **Task 3.2.1**: Lägg till felhantering vid databasoperationer
  - **Task 3.2.2**: Implementera logik för att hantera felaktig användarinmatning
  - **Task 3.2.3**: Skriv tydliga felmeddelanden för slutanvändaren

---

### **Epic 4: Testning och Validering**

- **Feature 4.1**: Manuella tester
  - **Task 4.1.1**: Utför testscenariot "Strömavbrott-testet"
  - **Task 4.1.2**: Utför testscenariot "Anders-testet" (simulera två samtidiga användare)
  - **Task 4.1.3**: Utför testscenariot "Helikopter-testet" (15 sökbara helikoptrar)

---

### **Epic 5: Dokumentation**

- **Feature 5.1**: Uppdatera README.md

  - **Task 5.1.1**: Beskriv projektets syfte och funktioner
  - **Task 5.1.2**: Lägg till installations- och konfigurationsinstruktioner
  - **Task 5.1.3**: Dokumentera SOLID-principerna med kodexempel

- **Feature 5.2**: Individuella rapporter
  - **Task 5.2.1**: Varje gruppmedlem skriver sin tekniska rapport
  - **Task 5.2.2**: Samla in och validera rapporternas kvalitet

---

### **Epic 6: Presentation och Inlämning**

- **Feature 6.1**: Förbered presentation

  - **Task 6.1.1**: Skapa en PowerPoint eller liknande för att presentera systemets arkitektur
  - **Task 6.1.2**: Förbered en live-demonstration av programmet
  - **Task 6.1.3**: Repetera presentationen för att hålla tiden

- **Feature 6.2**: Genomför inlämning
  - **Task 6.2.1**: Skapa en Pull Request till `main`
  - **Task 6.2.2**: Se till att all kod är testad och korrekt dokumenterad
  - **Task 6.2.3**: Dela inlämningen med Henrik och Marcus för slutgodkännande

---

### Tidsuppskattning för Backlog:

- **Dag 1-2**: Epic 1 (Kodstädning & SOLID)
- **Dag 3-4**: Epic 2 (Persistent Lagring)
- **Dag 5-6**: Epic 3 (Konsolstruktur) och Epic 4 (Testning)
- **Dag 7**: Epic 5 (Dokumentation) och Epic 6 (Presentation)

Med denna backlog är projektet tydligt strukturerat, inkluderar alla kritiska funktioner och levererar ett professionellt system på en vecka. 🚀
