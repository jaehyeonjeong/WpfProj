// Guy 객체를 만들어 Joe라는 변수에 할당합니다.
// Name 필드의 값을 Joe로 설정
// Cash 필드의 값을 50으로 설정

using Communiacation;

internal class Program
{
    private static void Main(string[] args)
    {
        //Guy joe = new Guy();
        //joe.Name = "Joe";
        //joe.Cash = 50;
        Guy joe = new Guy() { Name = "Joe", Cash = 50 };

        // Guy 객체를 만들어 bob이라는 변수를 할당
        // Name 필드의 값을 "Bob"으로 설정합니다.
        // Cash 필드의 값을 100으로 설정합니다.
        Guy bob = new Guy() { Name = "Bob", Cash = 100 };

        while (true)
        {
            // 각 Guy 객체의 WriteMyInfo() 매서드를 호출합니다.
            Console.Write($"Enter an amount: ");
            string howMuch = Console.ReadLine();
            if (howMuch == "") return;
            // int.TryParse를 사용해 howMuch 문자열을 int로 변환해 봅니다.
            if (int.TryParse(howMuch, out int amount))
            {
                // 변환이 성공했는지 확인합니다.
                Console.WriteLine($"amount: {amount}");

                Console.Write("Who should give the cash: ");
                string whichGuy = Console.ReadLine();
                if (whichGuy == joe.Name)
                {
                    // joe 객체의 GiveCash() 매서드를 호출하고 결과를 저장합니다.
                    joe.GiveCash(amount);
                    // bob 객체의 ReceiveCash() 매서드에 저장된 결과를 매개 변수로 넘겨주며 호출합니다.
                    bob.ReceiveCash(amount);
                }
                else if (whichGuy == bob.Name)
                {
                    // bob의 객체의 GiveCash() 매서드를 호출하고 결과를 저장합니다.
                    bob.GiveCash(amount);
                    // joe 객체의 ReceiveCash() 매서드에 저장된 결과를 매개 변수로 넘겨주며 호출합니다.
                    joe.ReceiveCash(amount);
                }
                else
                {
                    Console.WriteLine($"Please enter 'Joe' or 'Bob'");
                }
                Console.WriteLine($"Joe Cash: {joe.Cash}, Bob Cash: {bob.Cash}");
            }
            else
            {
                Console.WriteLine("Please enter an amount (or a blank line to exit).");
            }
        }
    }
}