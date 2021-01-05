using UnityEngine;
using UnityEngine.Advertisements;

namespace GLS
{
    /// <summary>
    /// 広告全般を管理するクラス
    /// </summary>
    public class AdvertisementUtility : SingletonMonoBehaviour<GLS.AdvertisementUtility>
    {
        [SerializeField]
        private GLSAppSettingData appSettingData = null;
        [SerializeField]
        private GLSPlacementIDData placementIDData = null;

        private GLS.AdvertisementBanner glsBanner = null;

        /// <summary>
        /// インタースティシャル広告を表示
        /// </summary>
        /// <param name="index">読み込む広告の番号</param>
        public void ShowInterstitial(int index)
        {
            var glsInterstitial = new GLS.AdvertisementInterstitial();
            glsInterstitial.ShowInterstitial(placementIDData.InterstitialPlacementIDArray[index]);
        }

        /// <summary>
        /// 動画リワード広告を表示
        /// </summary>
        /// <param name="index">読み込む広告の番号</param>
        /// <param name="onFinished">動画が最後まで視聴された時に呼ばれるコールバック</param>
        /// <param name="onSkipped">動画がスキップされた時に呼ばれるコールバック</param>
        /// <param name="onFailed">動画再生失敗時に呼ばれるコールバック</param>
        public void ShowRewardedVideo(int index, System.Action onFinished, System.Action onSkipped = null, System.Action onFailed = null)
        {
            var glsRewardedVideo = new GLS.AdvertisementVideo();
            var placementID = placementIDData.RewardedVideoPlacementIDArray[index];
            glsRewardedVideo.ShowRewardedVideo(placementID, onFinished, onSkipped, onFailed);
        }

       public bool RewardVideoIsReady(int index)
        {
            var placementID = placementIDData.RewardedVideoPlacementIDArray[index];
            return Advertisement.IsReady(placementID);
        }

        /// <summary>
        /// バナー広告を表示
        /// </summary>
        public void ShowBanner()
        {
            if (glsBanner == null) return;

            StartCoroutine(glsBanner.ShowBannerWhenReady());
        }

        /// <summary>
        /// バナー広告を非表示
        /// </summary>
        public void HideBanner()
        {
            if (glsBanner == null) return;

            glsBanner.HideBanner();
        }

        protected override void Awake()
        {
            base.Awake();
            Advertisement.Initialize(appSettingData.GetGameID(), appSettingData.TestMode);
        }

        private void Start()
        {
            glsBanner = new GLS.AdvertisementBanner();
            glsBanner.Initialize(placementIDData.BannerPlacementID);
            ShowBanner();
        }
    }
}
