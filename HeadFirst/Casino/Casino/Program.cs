using Casino;

People player = new People() { Name = "The Player", Cash = 100 };
double odds = 0.75;
Random random = new Random();

Console.WriteLine($"Welcome to the casino. The odds are {odds}");

while (player.Cash > 0)
{
    // 플레이어 객체가 가진 금액을 출력
    Console.WriteLine($"{player.Name} has {player.Cash}");

    // 사용자에게 얼마를 내기에 걸지 질문
    Console.Write($"How much do you want to bet: ");

    // 입력받은 값을 string 타입의 howMuchh 변수에 저장
    string howMuch = Console.ReadLine();

    // howMuch 변수를 int 타입으로 변환해보고, amount라는 int 타입 변수에 저장
    if (int.TryParse(howMuch, out int amount))
    {
        // int 타입으로 변환됐으면, 플레이어가 건 금액을 pot이라는 int 타입의 변수에 저장, 저장할 때 금액에 2를 곱하는데 이 금액이 플레이어가 이겼을 때 받을 금액이기 때문
        int pot = amount * 2;
        player.GiveCash(amount);

        // 0과 1사이 임의의 숫자를 고름
        // 임의의 숫자가 odds보다 크면
        double nRand = random.NextDouble();
        if (nRand > odds)
        {
            Console.WriteLine($"Good luck, you win! wins pot: {pot}, nRand: {nRand}");
            player.ReceiveCash(pot);
        }
        else
        {
            // 임의의 숫자가 odds 보다 같거나 작으면, 플레이어는 돈을 잃는다.
            Console.WriteLine($"Bad luck, you lose. nRand: {nRand}");
        }
    }
    else
    {
        Console.WriteLine("Please correct input amount");
    }
}

Console.WriteLine("The house always wins.");