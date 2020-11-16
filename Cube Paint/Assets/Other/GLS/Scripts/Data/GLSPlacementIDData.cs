using UnityEngine;

namespace GLS
{
    /// <summary>
    /// 広告のPlacementIDを設定するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Data/GLSPlacementIDData")]
    public class GLSPlacementIDData : ScriptableObject
    {
        [Header("◆バナー広告に使用するPlacementIDを設定")]
        [SerializeField]
        private string bannerPlacementID = "banner";

        [Header("◆インタースティシャル広告に使用するPlacementIDを設定")]
        [SerializeField]
        private string[] interstitialPlacementIDArray = { "video" };

        [Header("◆動画リワード広告に使用するPlacementIDを設定")]
        [SerializeField]
        private string[] rewardedVideoPlacementIDArray = { "rewardedVideo" };

        public string BannerPlacementID => bannerPlacementID;
        public string[] InterstitialPlacementIDArray => interstitialPlacementIDArray;
        public string[] RewardedVideoPlacementIDArray => rewardedVideoPlacementIDArray;
    }
}
