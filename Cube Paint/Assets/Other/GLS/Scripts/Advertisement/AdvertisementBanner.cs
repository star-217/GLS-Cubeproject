using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace GLS
{
    /// <summary>
    /// バナー広告を管理するクラス
    /// </summary>
    public class AdvertisementBanner
    {
        private string placementID = string.Empty;

        /// <summary>
        /// バナー広告の初期化
        /// </summary>
        /// <param name="placementId">バナー広告のPlacementID</param>
        public void Initialize(string placementId)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            placementID = placementId;

            var bannerLoadOptions = new BannerLoadOptions();
            bannerLoadOptions.errorCallback += BannerLoadOptionErrorCallBack;
            bannerLoadOptions.loadCallback += BannerLoadOptionLoadCallBack;

            Advertisement.Banner.Load(placementID, bannerLoadOptions);
        }

        /// <summary>
        /// バナー広告を表示
        /// </summary>
        public IEnumerator ShowBannerWhenReady()
        {
            while (!Advertisement.IsReady(placementID))
            {
                yield return new WaitForSeconds(0.5f);
            }

            var bannerOptions = new BannerOptions();
            bannerOptions.showCallback += BannerOptionShowCallBack;
            bannerOptions.hideCallback += BannerOptionHideCallBack;
            bannerOptions.clickCallback += BannerOptionClickCallBack;

            Advertisement.Banner.Show(placementID, bannerOptions);
        }

        /// <summary>
        /// バナー広告を非表示
        /// </summary>
        public void HideBanner()
        {
            Advertisement.Banner.Hide();
        }

        /// バナーのオプション
        private void BannerOptionShowCallBack()
        {
            Debug.Log("<Ad> Banner Show");
        }

        private void BannerOptionHideCallBack()
        {
            Debug.Log("<Ad> Banner Hide");
        }

        private void BannerOptionClickCallBack()
        {
            Debug.Log("<Ad> Banner Click");
        }

        /// バナーロードのオプション
        private void BannerLoadOptionErrorCallBack(string errorMessage)
        {
            Debug.Log($"<Ad> Banner Load Error = {errorMessage}");
        }

        private void BannerLoadOptionLoadCallBack()
        {
            Debug.Log("<Ad> Banner Load");
        }
    }
}
