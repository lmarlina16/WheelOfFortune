using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public class Wheel
    {
        //enum { HUNDRED_DOLLARS, TWOHUNDRED_DOLLARS, TOILET_PAPER}


        //List<int> moneyRewards = new List<int> { 100, 200, 300  };
        //const int MIN_MONEY_INDEX = 0;
        //const int MAX_MONEY_INDEX = 2;
        //List<string> rewards = new List<string> { "100", "200", "300","Toilet Paper", "Hand Sanatizer", "Bankruptcy" };
        public const string BANKRUPTCY = "Bankruptcy";
        public List<Reward> rewards;
  

        public Wheel ()
        {
            rewards = new List<Reward>
                {
                    new Reward(100),
                    new Reward(200),
                    new Reward(300),
                    new Reward("Toilet Paper"),
                    new Reward("Hand Sanitizer"),
                    new Reward(BANKRUPTCY)
                };
        }


        public Reward GetRandomReward()
        {
            Random rand = new Random();
            int next = rand.Next(0, rewards.Count - 1);
            return rewards[next];

        }



    }

    public class Reward
    {
        public int moneyReward { get; }  //default 0; 
        public string otherReward;

        public Reward(int moneyReward)
        {
            this.moneyReward = moneyReward;
            otherReward = null;
        }

        public Reward(string otherReward)
        {
            this.moneyReward = 0;
            this.otherReward = otherReward;
        }

        public override String ToString()
        {
            string output;
            if (otherReward == null)
            {
                output = moneyReward.ToString();
            }
            else
            {
                output = otherReward;
            }
            return output;
        }

        public bool IsMoneyReward()
        {
            bool output;
            if (otherReward == null)
            {
                output = true;
            }
            else
            {
                output = false;
            }
            return output;
        }

        public bool IsBankruptcy()
        {
            bool output;
            if (otherReward == null)
            {
                return false;
            }
            if (otherReward.Equals(Wheel.BANKRUPTCY))
            {
                output = true;
            }
            else
            {
                output = false;
            }
            return output;
        }
    }

    
}
