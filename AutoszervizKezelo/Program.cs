using AutoszervizKezelo;
List<Munkalap> munkalapok = new List<Munkalap>();
foreach (var sor in File.ReadAllLines("munkalapok.txt").Skip(1))
{
    munkalapok.Add(new Munkalap(sor));
}
Console.WriteLine("Rögzített munkalapok:");
foreach (var munkalap in munkalapok)
{
    Console.WriteLine(munkalap);
}
Console.WriteLine("\nAlapvető statisztikák:");
Console.WriteLine($"Szerviz teljes bevétele: {munkalapok.Sum(m => m.FizetendoOsszeg())} Ft");
Console.WriteLine($"Legrövidebb javítás: {munkalapok.Min(m => m.Munkaora)} óra, leghosszabb javítás: {munkalapok.Max(m => m.Munkaora)} óra");
Console.WriteLine($"Átlagos munkaidő: {munkalapok.Average(m => m.Munkaora):F1} óra");
var leg = munkalapok.MaxBy(m => m.FizetendoOsszeg());
Console.WriteLine($"Legtöbbet fizető ügyfél: {leg.UgyfelNev}({leg.FizetendoOsszeg()} Ft)");
Console.WriteLine($"Fizetős munkalapok száma: {munkalapok.Count(m => m.FizetendoOsszeg() > 0)} db");
Console.WriteLine("\nMOTOR kategóriájú munkalapok:");
foreach (var sor in munkalapok)
{
    if (sor.Kategoria == "MOTOR")
    {
        Console.WriteLine($"{sor.UgyfelNev} ({sor.Munkaora} óra)");
    }
}
Console.WriteLine("\nDöntések:");
Console.WriteLine($"Volt 150 000 Ft feletti javítás: {(munkalapok.Any(m => m.FizetendoOsszeg() > 150000) ? "Igen" : "Nem")} ");
Console.WriteLine($"Minden munkalapon legalább 10 000 Ft az alkatrészár: {(munkalapok.All(m => m.AlkatreszAr >= 10000) ? "Igen" : "Nem")} ");
Console.WriteLine("\nTop 3 legmagasabb végösszegű munkalap:");
var top3 = munkalapok.OrderByDescending(x => x.FizetendoOsszeg()).Take(3).ToList();
int i = 1;
foreach (var munkalap in top3)
{
    Console.WriteLine($" {i}. {munkalap.UgyfelNev} ({munkalap.FizetendoOsszeg()} Ft)");
    i += 1;
}