using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreChanger : MonoBehaviour, IScoreController
    {
        [SerializeField] private TMP_Text text;
        private int score;
        public int Score
        {
            get => score;
            set => score = value;
        }


        public void AddScore(int numToAdd)
        {
            score = Score + numToAdd;
            text.text = score.ToString();
        }
    }
}
