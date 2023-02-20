using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        public void Play(AudioClip clip)
        {
            var setSound = SetSound();
            if (setSound != null)
            {
                setSound.PlaySound(clip);
            }
        }

        private IUseSound SetSound()
        {
            return gameObject.GetComponent<IUseSound>();
        }
    }
}
