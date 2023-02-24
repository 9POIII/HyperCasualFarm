using UnityEngine;

namespace Gameplay
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private int pointsToAdd;
        [SerializeField] private GameObject scoreChanger;
        [SerializeField] private Color colorToPaint;
        public int PointsToAdd
        {
            get => pointsToAdd;
            set => pointsToAdd = value;
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var iscoreController = IScoreController();
            var icolorAnimation = IcolorAnimation();

            if (collision.gameObject.CompareTag("Player"))
            {
                iscoreController.AddScore(PointsToAdd);
                icolorAnimation.ColorAnimation(colorToPaint, gameObject);
            }
        }
    
        private IScoreController IScoreController()
        {
            return scoreChanger.GetComponent<IScoreController>();
        }

        private IColorAnimation IcolorAnimation()
        {
            return gameObject.GetComponent<IColorAnimation>();
        }
    }
}
