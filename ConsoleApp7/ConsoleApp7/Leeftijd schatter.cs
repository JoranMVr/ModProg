﻿using System;
class Hallo2
{
static void Main()
    {
        DateTime time = DateTime.Now;
        string format = "MMM ddd d HH:mm yyyy";
        Console.WriteLine(time.ToString(format));
        string naam;
        Console.WriteLine("Wat is je naam?");
        naam = Console.ReadLine();
        Console.WriteLine("Hallo, " + naam + "!");
        Console.WriteLine("Je naam heeft " + naam.Length + " letters.");
        Console.WriteLine("Wat is je geboortejaar?");
        string geboortejaar = Console.ReadLine();
        int jaar = int.Parse(geboortejaar);
        int leeftijd = 2018 - jaar; 
        Console.WriteLine("Ik schat in dat je " + leeftijd + " jaar oud bent!");
        Console.ReadLine();
    }
}