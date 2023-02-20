using System;
using Sound;
using UnityEngine;
using DG.Tweening;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private AudioClip ballTouchSound;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private GameState gameState;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            soundManager.Play(ballTouchSound);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("DeathZone"))
            {
                gameState.LoseGame();
            }
        }
    }
}
