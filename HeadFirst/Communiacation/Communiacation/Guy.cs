using System;
using System.Collections.Generic;
using System.Text;

namespace Communiacation
{
    internal class Guy
    {
        // Field 
        public string Name;
        public int Cash;
        /// <summary>
        /// 이 사람의 이름과 가진 돈을 콘솔에 출력
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine($"{Name} has {Cash} bucks.");
        }

        /// <summary>
        /// 돈을 주기 위해 이 사람의 지갑에서 돈을 꺼냅니다.
        /// 돈이 부족하면 메시지를 출력합니다.
        /// </summary>
        /// <param name="amount">줄 돈의 금액</param>
        /// <returns>
        /// 줄어든 돈의 금액.
        /// 돈이 부족하거나 금액이 유효하지 않는 경우 0을 반환합니다.
        /// </returns>
        public int GiveCash(int amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine($"{Name} says: {amount} isn't a valid amount");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine($"{Name} says: I don't have enough cash to give you {amount}");
                return 0;
            }
            Cash -= amount;
            return amount;
        }
        public void ReceiveCash(int amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine($"{Name} says: {amount} isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}
