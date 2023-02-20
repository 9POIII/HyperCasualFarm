using Sound;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        public float MaxSpeed{
            get => maxSpeed;
            set => maxSpeed = value;
        }
        
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private AudioClip ballTouchSound;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private GameState gameState;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            gameObject.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(4f, 4.5f), 0);
        }

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

        private void FixedUpdate()
        {
            if (rigidbody2D.velocity.magnitude > MaxSpeed)
            {
                rigidbody2D.velocity = rigidbody2D.velocity.normalized * MaxSpeed;
            }
        }
    }
}
