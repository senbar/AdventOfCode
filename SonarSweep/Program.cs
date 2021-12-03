using System.IO;


var result=0;


using (StreamReader dataStream= new StreamReader("./data")){
    int dataPoint;
    int? lastDataPoint=null;
    var line="";
    
    while((line=dataStream.ReadLine())!=null){
        dataPoint = int.Parse(line);
        if(lastDataPoint!=null && dataPoint>lastDataPoint)
            result++;
        lastDataPoint=dataPoint;
    }
}



Console.WriteLine(result);