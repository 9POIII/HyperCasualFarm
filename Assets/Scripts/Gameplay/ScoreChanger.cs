using System;
using Saves;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class ScoreChanger : MonoBehaviour, IScoreController
    {
        [SerializeField] private SaveLoader saveLoader;
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text bestScoreText;

        private int currentScore;
        private int bestScore;

        public int CurrentScore
        {
            get => currentScore;
            set => currentScore = value;
        }
        public int BestScore
        {
            get => bestScore;
            set => bestScore = value;
        }

        private void Start()
        {
            bestScoreText.text = BestScore.ToString();
        }

        public void AddScore(int numToAdd)
        {
            if (CurrentScore <= BestScore)
            {
                CurrentScore += numToAdd;
                currentScoreText.text = CurrentScore.ToString();
            }
            else
            {
                CurrentScore += numToAdd;
                BestScore = CurrentScore;
                currentScoreText.text = CurrentScore.ToString();
                bestScoreText.text = CurrentScore.ToString();
            }
        }

        public void SaveScore()
        {
            saveLoader.Save();
        }
    }
}
