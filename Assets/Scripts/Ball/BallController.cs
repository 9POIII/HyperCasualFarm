using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip ballTouchSound;
    [SerializeField] private SoundManager soundManager;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundManager.Play(ballTouchSound);
    }
}
