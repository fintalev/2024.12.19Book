using afaffasfa;

List<Book> books = new();

List<string> HuAuthors = new() 
{
"Madách Imre",
"Jókai Mór",
"Móricz Zsigmond",
"Ady Endre",
"Szabó Magda",
"Karinthy Frigyes",
"Kosztolányi Dezső",
"Rejtő Jenő",
"Petőfi Sándor",
"Krúdy Gyula"
};
List<string> HuBooks = new()
{
"Az ember tragédiája",
"Az arany ember",
"Légy jó mindhalálig",
"Új versek",
"Abigél",
"Tanár úr kérem",
"Édes Anna",
"A tizennégy karátos autó",
"János vitéz",
"Szindbád",
};
List<string> EngAuthors = new()
{
"William Shakespeare",
"Jane Austen",
"Charles Dickens",
"Mark Twain",
"George Orwell",
"J.R.R. Tolkien",
"Virginia Woolf",
"F.Scott Fitzgerald",
"Ernest Hemingway",
"Agatha Christie",
};
List<string> EngBooks = new()
{
"Hamlet",
"Pride and Prejudice",
"Great Expectations",
"The Adventures of Tom Sawyer",
"1984",
"The Lord of the Rings",
"To the Lighthouse",
"The Great Gatsby",
"The Old Man and the Sea",
"Murder on the Orient Express",
};



List<Book> konyvek = new();

for (int i = 0; i < 15; i++)
{
    string isbn = Random.Shared.NextInt64(1000000000, 10000000000).ToString();
    while (konyvek.Any(k => k.ISBN.Equals(isbn))) isbn = Random.Shared.NextInt64(1000000000, 10000000000).ToString();

    int keszleten = Random.Shared.Next(5, 11);
    if (Random.Shared.Next(0, 10) < 3) keszleten = 0;

    int ev = Random.Shared.Next(2007, DateTime.Now.Year + 1);

    int ar = Random.Shared.Next(1000, 10001);
    while (ar % 100 != 0) ar = Random.Shared.Next(1000, 10001);

    string nyelv = "magyar";
    if (Random.Shared.Next(0, 10) < 2) nyelv = "angol";

    List<string> szerzok = new();
    string cim = string.Empty;
    if (nyelv.Equals("magyar"))
    {
        if (Random.Shared.Next(0, 10) < 7)
        {
            szerzok.Add(HuAuthors[Random.Shared.Next(0, HuAuthors.Count)]);
        }
        else
        {
            for (int x = 0; x < Random.Shared.Next(2, 4); x++)
                szerzok.Add(HuAuthors[Random.Shared.Next(0, HuAuthors.Count)]);
        }

        cim = HuBooks[Random.Shared.Next(0, HuBooks.Count)];
    }
    else
    {
        if (Random.Shared.Next(0, 10) < 7)
        {
            szerzok.Add(EngAuthors[Random.Shared.Next(0, EngAuthors.Count)]);
        }
        else
        {
            for (int x = 0; x < Random.Shared.Next(2, 4); x++)
                szerzok.Add(EngAuthors[Random.Shared.Next(0, EngAuthors.Count)]);
        }

        cim = EngBooks[Random.Shared.Next(0, EngBooks.Count)];
    }

    konyvek.Add(new Book(isbn, cim, ev, nyelv, keszleten, ar, szerzok));
}

int kezdetiKeszlet = konyvek.Sum(k => k.Stock);
int bevetel = 0;
int kifogyott = 0;

for (int i = 0; i < 100; i++)
{
    var konyv = konyvek[Random.Shared.Next(0, konyvek.Count)];
    if (konyv.Stock > 0)
    {
        konyv.Stock--;
        bevetel += konyv.Price;
    }
    else
    {
        if (Random.Shared.Next(0, 2) == 0)
        {
            konyv.Stock += Random.Shared.Next(1, 10);
        }
        else
        {
            konyvek.Remove(konyv);
            kifogyott++;
        }
    }
}

int vegsoKeszlet = konyvek.Sum(k => k.Stock);
int kulonbseg = vegsoKeszlet - kezdetiKeszlet;

Console.WriteLine($"Az eladásokból származó bevétel: {bevetel} Ft");
Console.WriteLine($"A nagykerből elfogyott címek száma: {kifogyott} db");
Console.WriteLine($"Kezdeti készlet: {kezdetiKeszlet} db, végső készlet: {vegsoKeszlet} db, különbség: {kulonbseg} db");
