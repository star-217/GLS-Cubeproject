namespace GLS
{
    /// <summary>
    /// 広告全般を呼び出すクラス
    /// </summary>
    public static class Ad
    {
        /// <summary>
        /// インタースティシャル広告を表示
        /// </summary>
        /// <param name="index">読み込む広告の番号</param>
        public static void ShowInterstitial(int index)
        {
            if (!GLS.AdvertisementUtility.IsNullInstance)
            {
                GLS.AdvertisementUtility.Instance.ShowInterstitial(index);
            }
        }
        /// <summary>
        /// 動画リワード広告を表示
        /// </summary>
        /// <param name="index">読み込む広告の番号</param>
        /// <param name="onFinished">動画が最後まで視聴された時に呼ばれるコールバック</param>
        /// <param name="onSkipped">動画がスキップされた時に呼ばれるコールバック</param>
        /// <param name="onFailed">動画再生失敗時に呼ばれるコールバック</param>
        public static void ShowRewardedVideo(int index, System.Action onFinished, System.Action onSkipped = null, System.Action onFailed = null)
        {
            if (!GLS.AdvertisementUtility.IsNullInstance)
            {
                GLS.AdvertisementUtility.Instance.ShowRewardedVideo(index, onFinished, onSkipped, onFailed);
            }
        }

        public static bool RewardVideoIsReady(int index)
        {
            if(!GLS.AdvertisementUtility.IsNullInstance)
            {
                return GLS.AdvertisementUtility.Instance.RewardVideoIsReady(index);
            }
            return false;
        }
        /// <summary>
        /// バナー広告を表示
        /// </summary>
        public static void ShowBanner()
        {
            if (!GLS.AdvertisementUtility.IsNullInstance)
            {
                GLS.AdvertisementUtility.Instance.ShowBanner();
            }
        }

        /// <summary>
        /// バナー広告を非表示
        /// </summary>
        public static void HideBanner()
        {
            if (!GLS.AdvertisementUtility.IsNullInstance)
            {
                GLS.AdvertisementUtility.Instance.HideBanner();
            }
        }
    }
}
