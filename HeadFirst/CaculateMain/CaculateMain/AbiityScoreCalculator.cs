using System;
using System.Collections.Generic;
using System.Text;

namespace CaculateMain
{
    internal class AbiityScoreCalculator
    {
        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            // 초기 AddAmount를 따로 백업
            int lastAddAmount = AddAmount;

            // 굴리기 값을 DividBy 필드 값으로 나눕니다.
            double divided = RollResult / DivideBy;

            // AddAmount를 나눗셈 결과에 더합니다.
            int added = AddAmount += (int)divided;     // int added = AddAmount + (int)divided;

            // 계산 종료 후 AddAMount 원복
            AddAmount = lastAddAmount;

            // 결괏값이 너무 작으면 Minimum 값을 사용합니다.
            if(added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
    }
}
