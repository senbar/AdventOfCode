// See https://aka.ms/new-console-template for more information

var data = System.IO.File.ReadLines("data");
var numbers = data.Take(1).SelectMany(x => x.Split(",").Select(z=>int.Parse(z)));
data = data.Skip(2);

var takeBoard = (IEnumerable<string> board) => board.TakeWhile(x => x != "");
var record = numbers.Count();
var recordBoardIndex=-1;

//this is kidna inefficient but dont care
var recordScore=0;

for (int i = 0; true; i++)
{
    var board = takeBoard(data);
    data = data.Skip(6);
    if(board.Count()==0)
     break;

    var intBoard = board.Select(x => x.Split().Where(s=>s!="").Select(y => int.Parse(y)).ToList()).ToList();
    var foundComplete=false;
    for (int j = 0; j < record; j++)
    {
        for (int x = 0; x < intBoard[0].Count(); x++)
        {
            var rowCount = 0;
            var columnCount = 0;
            for (int y = 0; y < intBoard.Count(); y++)
            {
                if(numbers.Take(j).Contains(intBoard[x][y]))
                    columnCount++;
                if (numbers.Take(j).Contains(intBoard[y][x]))
                    rowCount++;
            }
            if(columnCount==5 || rowCount==5)
            {
                foundComplete=true;
                recordScore= intBoard.SelectMany(x=>x.Select(y=>y)).Except(numbers.Take(j)).Sum() * numbers.ElementAt(j-1);
                break;
            }
        }
        if(foundComplete)
        {
            record=j;
            recordBoardIndex=i;
            break;
        }
    }
}

Console.WriteLine("Winning score: " + recordScore);
