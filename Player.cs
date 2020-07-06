using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public class Player
    {
        public string Name { get; set; }
        //Todo: Convert to currency?
        public int currentRoundMoney;  // Accumulated in current round only
        public int totalMoney; // Includes previous rounds + current
        List<string> otherRewards;


        public Player(string name)
        {
            Name = name;
            otherRewards = new List<string>();
        }



        // Reset current round scores at start of new round.
        public void HandleNewRoundOnCurrentRoundScore()
        {
            currentRoundMoney = 0;
        }

        // Resets player's total and current round scores in event of spinning to Bankrupt.
        public void HandleBankruptOnScores()
        {
            //totalMoney -= currentRoundMoney; //TODO - does totalMoney get reduced upon bankrupcy?
            //if (totalMoney < 0)
           // {
             //   totalMoney = 0;
            //}
            currentRoundMoney = 0;
        }

        // Updates both scores concurrently to provide real-time update on scores.
        public void UpdateMoney(int amountToUpdate)
        {
            currentRoundMoney += amountToUpdate;
            totalMoney += amountToUpdate;
        }

        public void UpdateRewards(Reward reward)
        {
            if (reward.IsMoneyReward())
            {
                UpdateMoney(reward.moneyReward);
            }
            else
            {
                otherRewards.Add(reward.otherReward);
            }
        }

        public void showScoreboard()
        {
            string msg = getScoreBoard();

            Console.WriteLine(msg);
        }

        public string getScoreBoard()
        {
            string msg = Environment.NewLine + 
                "CURRENT ROUND MONEY = " + currentRoundMoney + "\n" +
                "TOTAL MONEY = " + totalMoney + "\n" +
                "OTHER REWARDS = " + OtherRewardsToString() + Environment.NewLine;

            return msg;
        }

        public string OtherRewardsToString()
        {
            StringBuilder output =  new StringBuilder();
            if (otherRewards.Count == 0)
            {
                output.Append("NONE");
            }
            else
            {
                for (int i = 0; i < otherRewards.Count; i++)
                {
                    output.Append(otherRewards[i]);
                    output.Append(" * ");
                       
                }
            }
            
            return output.ToString();
        }

        

    }


}
