using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
