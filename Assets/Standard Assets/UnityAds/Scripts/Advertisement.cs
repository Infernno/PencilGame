namespace UnityEngine.Advertisements
{
    using System;

    public static class Advertisement
    {

        public static readonly string version = "1.2.0";

        public enum DebugLevel
        {
            None = 0,
            Error = 1,
            Warning = 2,
            Info = 4,
            Debug = 8,
            [System.ObsoleteAttribute("Use Advertisement.DebugLevel.None instead")] NONE = 0,
            [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Error instead")] ERROR = 1,
            [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Warning instead")] WARNING = 2,
            [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Info instead")] INFO = 4,
            [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Debug instead")] DEBUG = 8
        }

        private static DebugLevel _debugLevel = Debug.isDebugBuild
            ? DebugLevel.Error | DebugLevel.Warning | DebugLevel.Info | DebugLevel.Debug
            : DebugLevel.Error | DebugLevel.Warning | DebugLevel.Info;

        public static DebugLevel debugLevel
        {
            get { return _debugLevel; }

            set
            {
                _debugLevel = value;
#if UNITY_ANDROID || UNITY_IOS
                UnityEngine.Advertisements.UnityAds.setLogLevel(_debugLevel);
#endif
            }
        }

        public static bool isSupported
        {
            get
            {
                return
                    Application.isEditor ||
                    Application.platform == RuntimePlatform.IPhonePlayer ||
                    Application.platform == RuntimePlatform.Android;
            }
        }

        public static bool isInitialized
        {
            get
            {
#if UNITY_ANDROID || UNITY_IOS
                return UnityAds.isInitialized;
#else
        return false;
#endif
            }
        }

        public static void Initialize(string appId, bool testMode = false)
        {
#if UNITY_ANDROID || UNITY_IOS
            UnityAds.SharedInstance.Init(appId, testMode);
#endif
        }

        public static void Show(string zoneId = null, ShowOptions options = null)
        {
#if UNITY_ANDROID || UNITY_IOS
            UnityAds.SharedInstance.Show(zoneId, options);
#else
      if(options != null && options.resultCallback != null) {
        options.resultCallback(ShowResult.Failed);
      }
#endif
        }

        [System.Obsolete("Advertisement.allowPrecache is no longer supported and does nothing")]
        public static bool allowPrecache
        {
            get
            {
#if UNITY_ANDROID || UNITY_IOS
                return UnityAds.allowPrecache;
#else
        return false;
#endif
            }
            set
            {
#if UNITY_ANDROID || UNITY_IOS
                UnityAds.allowPrecache = value;
#endif
            }
        }

        public static bool IsReady(string zoneId = null)
        {
#if UNITY_ANDROID || UNITY_IOS
            return UnityAds.canShowZone(zoneId);
#else
      return false;
#endif
        }

        [System.Obsolete("Use Advertisement.IsReady method instead")]
        public static bool isReady(string zoneId = null)
        {
            return IsReady(zoneId);
        }

        public static bool isShowing
        {
            get
            {
#if UNITY_ANDROID || UNITY_IOS
                return UnityAds.isShowing;
#else
        return false;
#endif
            }
        }

        public static bool UnityDeveloperInternalTestMode { get; set; }

    }
}