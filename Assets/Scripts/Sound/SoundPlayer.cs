using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Sound
{
    public class SoundPlayer : MonoBehaviour, IUseSound
    {
        [SerializeField][Range(0f, 1f)] private float volume;
        private bool canItPlay = true;
        public float Volume{
            get => volume;
            set => volume = value;
        }
    
        public void PlaySound(AudioClip clip)
        {
            if (canItPlay)
            {
                StartCoroutine(Play(clip));
                canItPlay = false;
            }
        }
    
        public IEnumerator Play(AudioClip clip)
        {
            AudioSource source = Camera.main.AddComponent<AudioSource>();

            source.clip = clip;
            source.volume = Volume;
            source.spatialBlend = 0f;
            source.Play();

            yield return new WaitForSeconds(source.clip.length);
            Destroy(source);
            canItPlay = true;
        }
    }
}
