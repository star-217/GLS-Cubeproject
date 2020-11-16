using UnityEngine;

namespace GLS
{
    /// <summary>
    /// 広告の情報を設定するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Data/GLSAppSettingData")]
    public class GLSAppSettingData : ScriptableObject
    {
        [Header("◆アプリ個別のID")]
        [SerializeField]
        private string androidGameID = "";
        [SerializeField]
        private string iOSGameID = "";

        [Header("◆チェックをつけるとテスト用モード")]
        [SerializeField]
        private bool testMode = false;

        public bool TestMode => testMode;

        public string GetGameID()
        {
            var gameID = string.Empty;

#if UNITY_EDITOR || UNITY_ANDROID
                gameID = androidGameID;
#elif UNITY_IOS
                gameID = iOSGameID;
#endif
            return gameID;
        }
    }
}
