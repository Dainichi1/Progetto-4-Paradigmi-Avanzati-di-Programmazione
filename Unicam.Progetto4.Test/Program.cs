using Unica.Progetto4.Abstractions;
using Unicam.Progetto4.Test.Orm;



List<IExample> examples = new List<IExample>();


examples.Add(new Repository());

examples.Add(new EntityFramework());

examples.Add(new Linq()); 


foreach (var example in examples)
{
    example.RunExampleAsync();
}



Console.ReadLine();