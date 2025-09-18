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
        public int roundLength = 15;
        
        private int round = 0;
        private float timeUntilNextRound = 0;
        
        private void FixedUpdate()
        {
            timeUntilNextRound -= Time.fixedDeltaTime;
            if (timeUntilNextRound <= 0)
            {
                round++;
                if (round > 4)
                {
                    // Win
                }
                else
                {
                    // First / Next Round
                    roundText.text = "Round "+round;
                    timeUntilNextRound = roundLength;
                }
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }
    }
}