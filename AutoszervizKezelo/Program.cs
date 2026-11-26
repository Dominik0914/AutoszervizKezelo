using AutoszervizKezelo;
List<Munkalap> munkalapok = new List<Munkalap>();
foreach (var sor in File.ReadAllLines("munkalapok.txt"))
{
    munkalapok.Add(new Munkalap(sor));
}