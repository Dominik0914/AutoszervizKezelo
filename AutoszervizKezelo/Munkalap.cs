using System;
using System.Collections.Generic;
using System.Text;

namespace AutoszervizKezelo
{
    public class Munkalap
    {
        public string UgyfelNev { get; set; }
        public string Kategoria { get; set; }
        public int Munkaora { get; set; }
        public int AlkatreszAr { get; set; }
        public bool Garancialis { get; set; }
    public Munkalap(string sor)
    {
        var adatok = sor.Split(';');
        UgyfelNev = adatok[0];
        Kategoria = adatok[1];
        Munkaora = int.Parse(adatok[2]);
        AlkatreszAr = int.Parse(adatok[3]);
        Garancialis = bool.Parse(adatok[4]);
    }
        public int FizetendoOsszeg()
        {
            int oss = 0;
            if (Garancialis)
            {
                return 0;
            }
            else
            {
                if(Kategoria== "MOTOR")
                {
                    oss += Munkaora * 15000;
                }
                else
                {
                    oss += Munkaora * 12000;
                }
            }
            return oss+AlkatreszAr;
        }
        public override string ToString()
        {
            return $"{UgyfelNev} ({Kategoria}): {Munkaora} óra, alkatrész: {AlkatreszAr} Ft [Fizetős] - Fizetendő:\r\n{FizetendoOsszeg()} Ft";
        }
    }
}
