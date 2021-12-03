using System.Linq;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var agg=System.IO.File.ReadLines(@"data")
    .Select(line=> {
        var split=line.Split();
        return (split[0], Int32.Parse(split[1]));
        })
    .Select<(string,int), (int?,int?)>( split=>{
        var (command,value)= split;
        switch(command){
            case "forward":
                return (value,null);
            case "down":
                return(null, value);
            case "up":
                return(null, -value);
    }
    return(null,null);})
    .Aggregate((0,0),(prev, next)=> {
        return (prev.Item1+ (next.Item1??0), prev.Item2+ (next.Item2??0));
        });
Console.WriteLine(agg.Item1*agg.Item2);