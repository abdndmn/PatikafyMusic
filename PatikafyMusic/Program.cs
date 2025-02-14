
List<string> Musician = new List<string> {
    "Ajda Pekkan", "Sezen Aksu", "Funda Arar", "Sertab Erener", "Sıla", "Serdar Ortaç", "Tarkan", "Hande Yener", "Hadise", "Gülben Ergen", "Neşet Ertaş" };


List<string> Genre = new List<string> {
    "Pop", "Türk Halk Müziği/Pop", "Pop", "Pop", "Pop", "Pop", "Pop", "Pop","Pop","Türk Halk Müziği/Pop", "Türk Halk Müziği/Türk Sanat Müziği" };

List<int> Year = new List<int> {
    1968, 1971, 1999, 1994, 2009, 1994, 1992, 1999, 2005, 1997, 1960 };

List<int> Sales = new List<int> {
    20, 10, 3, 5, 3, 10, 40, 7, 5, 10, 2 };


var S = Musician.Where(m => m.StartsWith("S")).ToList();
Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
foreach (var item in S)
{
    Console.WriteLine(item);
}

var Sales10 = Musician.Where((m,i) => Sales[i] > 10).ToList();

Console.WriteLine("Albüm satışları 10 milyon'un üzerinde olan şarkıcılar:");

foreach (var item in Sales10)
{
    Console.WriteLine(item);
}

var Pop2000 = Musician
    .Select((m, i) => new { Name = m, Year = Year[i], Genre = Genre[i] })
    .Where(m => m.Year < 2000 && m.Genre == "Pop")
    .GroupBy(m => m.Year) 
    .OrderBy(g => g.Key) 
    .Select(g => new { Year = g.Key, Musicians = g.OrderBy(m => m.Name) }) 
    .ToList();


Console.WriteLine("2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:\n");
foreach (var group in Pop2000)
{
    Console.WriteLine($"Çıkış Yılı: {group.Year}");
    foreach (var musician in group.Musicians)
    {
        Console.WriteLine($"  - {musician.Name}");
    }
}



var MaxSales = Musician[Sales.IndexOf(Sales.Max())];
Console.WriteLine("En çok albüm satan şarkıcı:");
Console.WriteLine(MaxSales);

var Newest = Musician[Year.IndexOf(Year.Max())];
var Oldest = Musician[Year.IndexOf(Year.Min())];
Console.WriteLine("En yeni çıkış yapan şarkıcı:");
Console.WriteLine(Newest);
Console.WriteLine("En eski çıkış yapan şarkıcı:");
Console.WriteLine(Oldest);
