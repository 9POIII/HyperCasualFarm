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

        public void ColorAnimation(Color color, GameObject objToPaint)
        {
            objToPaint.GetComponent<SpriteRenderer>().DOColor(color, .5f).From(oldColor);
            StartCoroutine(ColorChange(objToPaint));
        }

        private IEnumerator ColorChange(GameObject objToPaint)
        {
            yield return new WaitForSeconds(0.1f);
            objToPaint.GetComponent<SpriteRenderer>().DOColor(oldColor, .5f).From(objToPaint.GetComponent<SpriteRenderer>().color);
        }
    }
}
