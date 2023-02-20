using DG.Tweening;
using Sound;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private bool canPlay;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private SoundManager soundManager;

    public bool CanPlay
    {
        get => canPlay;
        set => canPlay = value;
    }

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate < 120 ? 60 : 120;
        CanPlay = true;
    }

    public void LoseGame()
    {
        if (Camera.main != null) Camera.main.gameObject.transform.DOShakePosition(0.5f, 0.5f);
        CanPlay = false;
        soundManager.Play(gameOverSound);
    }
}
