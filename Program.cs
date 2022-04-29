// See https://aka.ms/new-console-template for more information

Console.WriteLine("Vul je namen in");
var namen = Console.ReadLine();
Console.WriteLine("Vul de plek in die je wilt zien");
var positie = Console.ReadLine();
var rng = new Random();
var namenSeparated = namen!.Split(',');
var gewichten = new int[]{1,4,4,5,2,1};
var naamMetGetal = new Dictionary<string, int>();

var count = 0;

foreach (var naam in namenSeparated)
{
    var weight = gewichten[count++];
    naamMetGetal[naam] = GetSom(naam) * weight;
}

var orderedNamenMetGetal = naamMetGetal
    .OrderByDescending(kv => kv.Value)
    .ThenBy(kv => kv.Key)
    .ToDictionary(pair => pair.Key, pair => pair.Value );

Console.WriteLine(orderedNamenMetGetal.ElementAt(int.Parse(positie!)-1).Key);

foreach(var kv in orderedNamenMetGetal)
{
    Console.WriteLine($"{kv.Key} : {kv.Value}");
}


int GetSom(string naam)
{
    var sum = naam.Length;
    foreach (var c in naam) sum += GetAlfabetPositie(c);
    return sum;
}

int GetAlfabetPositie(char karakter)
{
    return karakter.ToString().ToLower()[0] - 'a' + 1;
}