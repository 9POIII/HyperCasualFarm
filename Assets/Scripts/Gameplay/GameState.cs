using Ads;
using DG.Tweening;
using Gameplay;
using Saves;
using Sound;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private bool canPlay;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private InterstitialAds interstitialAds;
    [SerializeField] private ScoreChanger scoreChanger;

    public bool CanPlay
    {
        get => canPlay;
        set => canPlay = value;
    }

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate < 120 ? 60 : 120;
        CanPlay = true;
        losePanel.SetActive(false);
    }

    public void LoseGame()
    {
        if (Camera.main != null) Camera.main.gameObject.transform.DOShakePosition(0.5f, 0.5f);
        CanPlay = false;
        soundManager.Play(gameOverSound);
        losePanel.SetActive(true);
        interstitialAds.ShowAd();
        scoreChanger.SaveScore();
    }
}
