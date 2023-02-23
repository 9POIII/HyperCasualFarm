using Sound;
using UnityEngine;

namespace Gameplay
{
    public class Diamond : MonoBehaviour
    {
        [SerializeField] private int pointsToAdd;
        [SerializeField] private GameObject scoreChanger;
        [SerializeField] private AudioClip pickUpSound;
        private CheckInactive checkInactive;
        public int PointsToAdd
        {
            get => pointsToAdd;
            set => pointsToAdd = value;
        }

        private void Awake()
        {
            checkInactive = gameObject.GetComponentInParent<CheckInactive>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var iscoreController = IScoreController();

            if (col.gameObject.CompareTag("Player"))
            {
                iscoreController.AddScore(PointsToAdd);
                SoundManager.Instance.Play(pickUpSound);
                gameObject.SetActive(false);
                checkInactive.Check();
            }
        }
    
        private IScoreController IScoreController()
        {
            return scoreChanger.GetComponent<IScoreController>();
        }
    }
}
