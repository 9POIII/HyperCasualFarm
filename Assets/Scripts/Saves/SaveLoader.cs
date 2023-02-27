using System.Collections;
using Gameplay;
using TMPro;
using UnityEngine;

namespace Saves
{
    public class SaveLoader : MonoBehaviour
    {
        private const string saveKey = "mainSave";
        [SerializeField] private ScoreChanger scoreChanger;
        private void Start()
        {
            Load();
        }
        
        public void Save()
        {
            SaveManager.Save(saveKey, GetSaveSnapshot());
        }

        private void Load()
        {
            var data = SaveManager.Load<PlayerProfile>(saveKey);
            scoreChanger.BestScore = data.bestScore;
        }

        private PlayerProfile GetSaveSnapshot()
        {
            var data = new PlayerProfile()
            {
                bestScore = scoreChanger.BestScore
            };
            return data;
        }
    }
}
