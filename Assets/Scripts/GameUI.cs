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
        public GameObject restartUI;
        
        private int round = 0;
        private int itemsUntilNextRound;
        
        private bool gameRunning = true;

        private void Awake()
        {
            restartUI.SetActive(false);
            CheckIfCanDrop();
        }

        public bool CheckIfCanDrop()
        {
            // First / Next Round
            if (itemsUntilNextRound <= 0)
            {
                round++;
                roundText.text = "Round " + round;
                itemsUntilNextRound = round * roundItemIncrease;
                return false;
            }

            itemsUntilNextRound--;
            return true;
        }
        
        public void GameOver() 
        {
            restartUI.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }
    }
}