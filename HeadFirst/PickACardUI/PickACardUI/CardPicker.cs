using System;
using System.Collections.Generic;
using System.Text;

namespace PickACardUI
{
    internal class CardPicker
    {
        static Random random = new Random();

        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for(int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }
            return pickedCards;
        }

        /// <summary>
        /// 카드의 종류를 반환합니다.
        /// </summary>
        /// <returns>종류 이름이 포함된 랜덤형 매서드</returns>
        private static string RandomSuit()
        {
            // 1~4 사이의 임의의 숫자를 뽑습니다.
            int value = random.Next(1, 5);
            
            if (value == 1) return "Spades";    // 1이면 스페이드를 반환
            if (value == 2) return "Hearts";    // 2이면 하트를 반환
            if (value == 3) return "Clubs";     // 3이면 클로버를 반환
            return "Diamonds";                  // 모두 아니면 다이아
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString(); 
        }
    }
}
