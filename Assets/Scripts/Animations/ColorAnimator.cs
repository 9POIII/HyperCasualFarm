using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class ColorAnimator : MonoBehaviour, IColorAnimation
    {
        private Color oldColor;

        private void Start()
        {
            oldColor = gameObject.GetComponent<SpriteRenderer>().color;
        }

        public void ColorAnimation(Color color, GameObject objToPaint, float duration)
        {
            objToPaint.GetComponent<SpriteRenderer>().DOColor(color, duration);
            StartCoroutine(ColorChange(objToPaint, duration));
        }

        private IEnumerator ColorChange(GameObject objToPaint, float duration)
        {
            yield return new WaitForSeconds(0.1f);
            objToPaint.GetComponent<SpriteRenderer>().DOColor(oldColor, duration);
        }
    }
}
