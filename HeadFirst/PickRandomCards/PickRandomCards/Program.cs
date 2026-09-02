using PickRandomCards;

Console.WriteLine("Enter the number of cards to pick : ");

string line = Console.ReadLine();

if(int.TryParse(line, out int numberOfCards))       //  string 타입의 line 변수를 int 타입의 numberOfCards에 저장
{
    foreach(string card in CardPicker.PickSomeCards(numberOfCards))
    {
        Console.WriteLine(card);
    }
}
else
{
    Console.WriteLine($"Please input the Card Data.");
}
