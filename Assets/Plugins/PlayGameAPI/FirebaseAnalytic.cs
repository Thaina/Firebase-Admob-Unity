using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;
namespace com.google.game
{
    public class FirebaseAnalytic
    {
        private static FirebaseAnalytic _instance;

        public static FirebaseAnalytic Instance()
        {
            if (_instance == null)
            {
                _instance = new FirebaseAnalytic();
                _instance.preInit();
            }
            return _instance;
        }

#if UNITY_IOS


        [DllImport("__Internal")]
        private static extern void _kmconfigFirebase();
        private void preInit()
        {
            _kmconfigFirebase();
        }
        [DllImport("__Internal")]
        private static extern void _kmlogEvent(string name, string json);
        public void logEvent(string name, string jsonObjectString)
        {
            _kmlogEvent(name, jsonObjectString);
        }
        [DllImport("__Internal")]
        private static extern void _kmsetUserProperty(string key, string value);
        public void setUserProperty(string name, string value)
        {
            _kmsetUserProperty(name, value);
        }
        [DllImport("__Internal")]
        private static extern void _kmsetUserID(string id);
        public void setUserId(string userID)
        {
            _kmsetUserID(userID);
        }

        public void setSessionTimeoutDuration(long milliseconds)
        {

        }

        public void setMinimumSessionDuration(long milliseconds)
        {

        }
        [DllImport("__Internal")]
        private static extern void _kmsetAnalyticsCollectionEnabled(bool id);
        public void setAnalyticsCollectionEnabled(bool enable)
        {
            _kmsetAnalyticsCollectionEnabled(enable);
        }

#elif UNITY_ANDROID
        private AndroidJavaObject jobject;
        private void preInit()
        {
            if (jobject == null)
            {
                AndroidJavaClass gameUnityPluginClass = new AndroidJavaClass("com.google.service.AnalyticAPI");
                jobject = gameUnityPluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
        }

        public void logEvent(string name, string jsonObjectString)
        {
            jobject.Call("logEvent", new object[] { name,jsonObjectString });
        }
        public void setUserProperty(string name,string value)
        {
            jobject.Call("setUserProperty",new object[]{name,value});
        }
        public void setUserId(string userID)
        {
            jobject.Call("setUserId",userID);
        }

        public void setSessionTimeoutDuration(long milliseconds)
        {
            jobject.Call("setSessionTimeoutDuration",milliseconds);
        }

        public void setMinimumSessionDuration(long milliseconds)
        {
            jobject.Call("setMinimumSessionDuration", milliseconds);
        }

        public void setAnalyticsCollectionEnabled(bool enable)
        {
            jobject.Call("setAnalyticsCollectionEnabled",enable);
        }
       
#elif UNITY_EDITOR
        private void preInit()
		{
		}

		  public void logEvent(string name, string jsonObjectString)
        {
            
        }
        public void setUserProperty(string name,string value)
        {
            
        }
        public void setUserId(string userID)
        {
            
        }

        public void setSessionTimeoutDuration(long milliseconds)
        {
            
        }

        public void setMinimumSessionDuration(long milliseconds)
        {
            
        }

        public void setAnalyticsCollectionEnabled(bool enable)
        {
            
        }  
       
#endif

    }
}
