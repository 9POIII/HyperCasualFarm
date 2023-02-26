using UnityEngine;

namespace Gameplay
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private int pointsToAdd;
        [SerializeField] private GameObject scoreChanger;
        [SerializeField] private Color colorToPaint;
        [SerializeField] private float animDuration;
        public int PointsToAdd
        {
            get => pointsToAdd;
            set => pointsToAdd = value;
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var iscoreController = IScoreController();
            var icolorAnimation = IColorAnimation();

            if (collision.gameObject.CompareTag("Player"))
            {
                iscoreController.AddScore(PointsToAdd);
                icolorAnimation.ColorAnimation(colorToPaint, gameObject, animDuration);
            }
        }
    
        private IScoreController IScoreController()
        {
            return scoreChanger.GetComponent<IScoreController>();
        }

        private IColorAnimation IColorAnimation()
        {
            return gameObject.GetComponent<IColorAnimation>();
        }
    }
}
