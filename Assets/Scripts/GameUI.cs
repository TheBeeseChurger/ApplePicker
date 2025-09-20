using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameUI : MonoBehaviour
    {
        public Text roundText;
        public int roundItemIncrease = 15;
        
        private int round = 0;
        private int itemsUntilNextRound;

        private void Awake()
        {
            CheckIfCanDrop();
        }

        public bool CheckIfCanDrop()
        {
            if (itemsUntilNextRound <= 0)
            {
                round++;
                if (round > 4)
                {
                    // Win
                }
                else
                {
                    // First / Next Round
                    roundText.text = "Round " + round;
                    itemsUntilNextRound = round * roundItemIncrease;
                }
                return false;
            }

            itemsUntilNextRound--;
            return true;
        }

        public static void Restart()
        {
            SceneManager.LoadScene(1);
        }
    }
}