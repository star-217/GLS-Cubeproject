using UnityEngine;
using UnityEngine.Advertisements;

namespace GLS
{
    /// <summary>
    /// インタースティシャル広告を管理するクラス
    /// </summary>
    public class AdvertisementInterstitial : IUnityAdsListener
    {
        private string placementID = string.Empty;

        /// <summary>
        /// インタースティシャル広告を表示
        /// </summary>
        /// <param name="placementId">インタースティシャル広告のPlacementID</param>
        public void ShowInterstitial(string placementId)
        {
            placementID = placementId;

            if (Advertisement.IsReady(placementID))
            {
                Advertisement.AddListener(this);
                Advertisement.Show(placementID);
            }
        }

        /// <summary>
        /// インタースティシャル広告を表示する準備ができた際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId">インタースティシャル広告のPlacementID</param>
        public void OnUnityAdsReady(string placementId)
        {
            if (placementID != placementId) return;

            Debug.Log($"<Ad> { placementID } : Interstitial Ready");
        }

        /// <summary>
        /// エラーのためにインタースティシャル広告の表示に失敗した際に呼ばれるメソッド
        /// </summary>
        /// <param name="errorMessage">エラー内容</param>
        public void OnUnityAdsDidError(string errorMessage)
        {
            Debug.Log($"<Ad> { placementID } : Interstitial Error = { errorMessage }");
            RemoveListener();
        }

        /// <summary>
        /// インタースティシャル広告の再生が開始した際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId">インタースティシャル広告のPlacementID</param>
        public void OnUnityAdsDidStart(string placementId)
        {
            if (placementID != placementId) return;

            Debug.Log($"<Ad> { placementID } : Interstitial Start");
        }

        /// <summary>
        /// インタースティシャル広告が終了した際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId">インタースティシャル広告のPlacementID</param>
        /// <param name="showResult">広告が再生終了した時にFailed, Skipped, Finishedのどれかを返す</param>
        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (placementID != placementId) return;

            Debug.Log($"<Ad> { placementID } : Interstitial { showResult }");
            RemoveListener();
        }

        private void RemoveListener()
        {
            Advertisement.RemoveListener(this);
        }
    }
}
