using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class BannerAds : MonoBehaviour
    {
        [SerializeField] BannerPosition bannerPosition;

        [SerializeField] private string androidID = "Banner_Android";
        [SerializeField] private string iOSID = "Banner_iOS";

        private string adId;

        private void Awake()
        {
            adId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iOSID
                : androidID;
        }

        private void Start()
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            //LoadBanner();
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };

            Advertisement.Banner.Load(adId, options);

            StartCoroutine(ShowBannerWhenInitialized());
        }

        IEnumerator ShowBannerWhenInitialized()
        {
            BannerOptions options = new BannerOptions
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
                showCallback = OnBannerShown
            };
            
            while (!Advertisement.isInitialized)
            {
                yield return new WaitForSeconds(.5f);
                Debug.Log("banner loh");
            }
            Advertisement.Banner.Show(adId, options);
            Debug.Log("banner rabotaet");
        }

        public void LoadBanner()
        {
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };

            Advertisement.Banner.Load(adId, options);
        }

        private void OnBannerLoaded()
        {
            Debug.Log("Banner loaded");
            ShowBannerAd();
        }

        private void OnBannerError(string message)
        {
            Debug.Log($"Banner Error: {message}");
        }
        public void ShowBannerAd()
        {
            BannerOptions options = new BannerOptions
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
                showCallback = OnBannerShown
            };
            Advertisement.Banner.Show(adId, options);
        }
        private void OnBannerClicked() { }
        private void OnBannerShown() { }
        private void OnBannerHidden() { }
    }
}