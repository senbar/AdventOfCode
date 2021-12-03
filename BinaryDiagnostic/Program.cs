using System.Linq;

var data=System.IO.File.ReadLines(@"data");
var agg=data.Select(line=>
    line.Select(chara=> chara=='0'? 0: chara=='1'? 1:throw new Exception() ))
    .Aggregate((prev,next)=>prev.Zip(next, (prev,next)=>prev+next ))
    .Select(n=> n > data.Count()/2 ? 1: 0).ToList();
agg.Reverse();
var gamma=0;
for(int i=0; i<agg.Count(); i++)
    gamma+= agg[i]* (int)Math.Pow(2,i) ;

var epsilon=0;
var invAgg=agg.Select(x=>x==1?0:1).ToList();
for(int i=0; i<invAgg.Count(); i++)
    epsilon+= invAgg[i]* (int)Math.Pow(2,i) ;
Console.Write(" "+gamma*epsilon+" ");