using UnityEngine;
using UnityEngine.UI;

namespace GLS
{
    public class AdvertisementSampleScript : MonoBehaviour
    {
        [SerializeField]
        private Button interstitialButton = null;
        [SerializeField]
        private Button rewardedVideoButton = null;

        [SerializeField]
        private Button showBannerButton = null;
        [SerializeField]
        private Button hideBannerButton = null;

        [SerializeField]
        private Button eventButton = null;

        public void Start()
        {
            // ◆Interstitialボタンが押された時の処理
            interstitialButton.onClick.AddListener(() =>
            {
                // ◆0番のインタースティシャル広告を表示
                GLS.Ad.ShowInterstitial(0);
            });

            // ◆ShowBannerボタンが押された時の処理
            showBannerButton.onClick.AddListener(() =>
            {
                // ◆バナー広告を表示
                GLS.Ad.ShowBanner();
            });

            // ◆HideBannerボタンが押された時の処理
            hideBannerButton.onClick.AddListener(() =>
            {
                // ◆バナー広告を非表示
                GLS.Ad.HideBanner();
            });

            // ◆ShowRewardedVideoの結果を受け取るコールバックを設定
            System.Action onFinished = () =>
            {
                // ◆動画リワード広告が最後まで視聴された際の処理
                Debug.Log("Finish");
            };

            System.Action onSkipped = () =>
            {
                // ◆動画リワード広告がスキップされた際の処理
                Debug.Log("Skip");
            };

            System.Action onFailed = () =>
            {
                // ◆動画リワード広告が再生失敗した際の処理
                Debug.Log("Failed");
            };

            // ◆RewardedVideoButtonボタンが押された時の処理
            rewardedVideoButton.onClick.AddListener(() =>
            {
                // ◆0番の動画リワード広告を表示
                GLS.Ad.ShowRewardedVideo(0, onFinished, onSkipped, onFailed);
            });

            // ◆EventButtonボタンが押された時の処理
            eventButton.onClick.AddListener(() =>
            {
                // ◆カスタムイベントを発行
                GLSAnalyticsUtility.TrackEvent("CustomEventName", "EvantName" , "Value");
            });
        }
    }
}
