namespace CaculateMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbiityScoreCalculator calculator = new AbiityScoreCalculator();
            while(true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine($"Calculated ability score: {calculator.Score}");
                Console.WriteLine($"Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        /// <summary>
        /// 메시지를 출력하고 콘솔에서 double 값을 읽어 들임.
        /// </summary>
        /// <param name="lastUsedValue">기본값</param>
        /// <param name="prompt">콘솔에 출력할 메시지</param>
        /// <returns>읽어 들인 double 값 또는 변환이 불가능 할 때는 기본값</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static double ReadDouble(double lastUsedValue, string prompt)
        {
            // 메시지와 함께 [기본값]을 출력한다.
            Console.Write($"{prompt}[{lastUsedValue}] : ");

            string line = Console.ReadLine();

            // 입력을 받은 다음 double.TryParse를 사용해 변환을 시도한다.
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine($"\tusing value {value}");
                return value;
            }
            else
            {
                Console.WriteLine($"\tusing default value\t{lastUsedValue}");
                return lastUsedValue;
            }
        }

        /// <summary>
        /// 메세지를 출력하고 콘솔에서 int 값을 읽어 들입니다.
        /// </summary>
        /// <param name="lastUsedValue"> 기본 값 </param>
        /// <param name="prompt"> 콘솔에 출력할 메시지 </param>
        /// <returns>읽어 들인 int값 또는 변환이 불가능할 때는 기본값</returns>
        static int ReadInt(int lastUsedValue, string prompt)
        {
            // 메시지와 함께 [기본값]을 출력한다.
            Console.Write($"{prompt}[{lastUsedValue}] : ");

            string line = Console.ReadLine();

            // 입력을 받은 다음 int.TryParse를 사용해 변환을 시도한다.
            if(int.TryParse(line, out int value))
            {
                Console.WriteLine($"\tusing value {value}");
                return value;
            }
            else
            {
                Console.WriteLine($"\tusing default value\t{lastUsedValue}");
                return lastUsedValue;
            }
        }
    }
}
