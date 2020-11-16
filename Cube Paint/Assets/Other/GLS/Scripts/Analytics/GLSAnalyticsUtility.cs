using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace GLS
{
    /// <summary>
    /// Unity Analyticsのカスタムイベントを扱うクラス
    /// </summary>
    public static class GLSAnalyticsUtility
    {
        /// <summary>
        /// イベントを発行
        /// </summary>
        /// <param name="customEventName">カスタムイベントの名前</param>
        /// <param name="eventName">イベントの名前</param>
        /// <param name="data">カスタムイベントがトリガーされるときに送られる追加のパラメーター</param>
        public static void TrackEvent(string customEventName, string eventName, object data)
        {
            var analyticsResult = Analytics.CustomEvent(customEventName, new Dictionary<string, object>()
            {
                { eventName, data },
            });

            Debug.Log($"<Analytics Event> { customEventName } / { eventName } : { data } / Result = { analyticsResult.ToString() }");
        }

        /// <summary>
        /// イベントを発行
        /// </summary>
        /// <param name="customEventName">カスタムイベントの名前</param>
        public static void TrackEvent(string customEventName)
        {
            var analyticsResult = Analytics.CustomEvent(customEventName);
            Debug.Log($"<Analytics Event> { customEventName } / Result = { analyticsResult.ToString() }");
        }

        /// <summary>
        /// イベントを発行
        /// </summary>
        /// <param name="customEventName">カスタムイベントの名前</param>
        /// <param name="position">Position</param>
        public static void TrackEvent(string customEventName, Vector3 position)
        {
            var analyticsResult = Analytics.CustomEvent(customEventName, position);
            Debug.Log($"<Analytics Event> { customEventName } / Result = { analyticsResult.ToString() }");
        }
    }
}
