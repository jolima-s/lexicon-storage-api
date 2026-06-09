<h1>Övning 1 del 5 - Efter scaffold frågor</h1>
<h2>Vilka metoder har genererats?</h2>
<p>LexiconStorageAPIContext.cs har skapats med DbSet för min entitet.</p>
<p>I appsettings.json har en connection string lagts till.</p>
<p>I Program.cs hämtas nu connection string från appsettings.json och databascontexten registreras (EF fattade automatiskt att jag tänkte använda SQLite).</p>
<p>ProductsController.cs har lagts till med färdig routing, databascontexten injiceras, HTTP-metoder har genererats som är fullt fungerande och returnerar rätt statuskoder etc och det har genererats en metod för att se om en specifik produkt finns.</p>

<h2>Hur används StorageContext?</h2>
<p>Den registreras i Program.cs som en service, för att sen kunna injectas i konstruktorn för controllers, så att den går att använda där. Jag vill dock ha detta i separata lager, så en controller, en service och en repository kommer det bli sen.</p>

<h2>Hur fungerar CreatedAtAction, Ok, NotFound osv?</h2>
<p>Det är olika metoder som skapar objekt eller resultat och sen returnerar ett svar i form av http status-koder. Tex 201 för att signalera att POST fungerade eller 404 för att signalera att en GET inte kunde hitta något.</p>
