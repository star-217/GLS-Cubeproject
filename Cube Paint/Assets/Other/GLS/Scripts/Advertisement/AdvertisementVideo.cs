using UnityEngine;
using UnityEngine.Advertisements;

namespace GLS
{
    /// <summary>
    /// 動画リワード広告を管理するクラス
    /// </summary>
    public class AdvertisementVideo : IUnityAdsListener
    {
        private string placementID = string.Empty;

        private System.Action onFinished = null;
        private System.Action onSkipped = null;
        private System.Action onFailed = null;

        /// <summary>
        /// 動画リワード広告を表示
        /// </summary>
        /// <param name="placementId">動画リワード広告のPlacementID</param>
        /// <param name="onFinished">動画が最後まで視聴された時に呼ばれるコールバック</param>
        /// <param name="onSkipped">動画がスキップされた時に呼ばれるコールバック</param>
        /// <param name="onFailed">動画再生失敗時に呼ばれるコールバック</param>
        public void ShowRewardedVideo(string placementId, System.Action onFinished, System.Action onSkipped = null, System.Action onFailed = null)
        {
            placementID = placementId;

            if (Advertisement.IsReady(placementID))
            {
                this.onFinished = onFinished;
                this.onSkipped = onSkipped;
                this.onFailed = onFailed;

                Advertisement.AddListener(this);
                Advertisement.Show(placementID);
            }
        }

        /// <summary>
        /// 動画リワード広告を表示する準備ができた際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId">動画リワード広告のPlacementID</param>
        public void OnUnityAdsReady(string placementId)
        {
            if (placementID != placementId) return;

            Debug.Log($"<Ad> { placementID } : Video Ready");
            
        }

        /// <summary>
        /// エラーのために動画リワード広告の表示に失敗した際に呼ばれるメソッド
        /// </summary>
        /// <param name="errorMessage">エラー内容</param>
        public void OnUnityAdsDidError(string message)
        {
            Debug.Log($"<Ad> { placementID } : Video Error = { message }");
            RemoveListener();
        }

        /// <summary>
        /// 動画リワード広告の再生が開始した際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId"> 動画リワード広告のPlacementID</param>
        public void OnUnityAdsDidStart(string placementId)
        {
            if (placementID != placementId) return;

            Debug.Log($"<Ad> { placementID } : Video Start");
        }

        /// <summary>
        /// 動画リワード広告が終了した際に呼ばれるメソッド
        /// </summary>
        /// <param name="placementId">動画リワードのPlacementID</param>
        /// <param name="showResult">広告が再生終了した時にFailed, Skipped, Finishedのどれかを返す</param>
        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (placementID != placementId) return;

            switch (showResult)
            {
                case ShowResult.Finished:
                {
                    onFinished?.Invoke();
                    break;
                }
                case ShowResult.Skipped:
                {
                    onSkipped?.Invoke();
                    break;
                }
                case ShowResult.Failed:
                {
                    onFailed?.Invoke();
                    break;
                }
            }

            Debug.Log($"<Ad> { placementID } : Video { showResult }");
            RemoveListener();
        }

        private void RemoveListener()
        {
            Advertisement.RemoveListener(this);
        }
    }
}
