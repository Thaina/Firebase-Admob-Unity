Google Firebase Unity Admob Plugin
==============================

Google Firebase Unity Admob Plugin provides a way to integrate firebase analyze and admob ads in Unity3D Game and u3d app.
You can use it for Unity iOS and Android App with the same c# or js code.It support all native firebase admob features and firebase core

## Google Firebase Unity Admob Plugin Features
Platforms supported in one plugin :
- [x] Android, Based Admob SDK v17.0.0 (part of Google Firebase service)
- [x] iOS, via SDK v7.35.1
- [x] Support all native events
- [x] AdRequest targeting methods,such as children target,test mode
- [x] Not need change Android package name
- [x] Very simple API
- [x] Based on FireBase SDK Version
- [x] Firebase Analyze

Ad Types:
- [x] Banner(All Banner Type and Custom banner sizes)
- [x] Interstitial (text, picture, video)
- [x] Native Advance Ad 
- [x] Rewarded Video


## Downloads Firebase Admob Unity Plugin
Assets/Plugins  is reqired     
admob_unity_plugin.unitypackage contain all required files and demo files     
Download those files from Admob Unity3d Plugin Project Home https://github.com/unity-plugins/Firebase-Admob-Unity     
or Download all the Unity admob plugin project https://github.com/unity-plugins/Firebase-Admob-Unity/archive/master.zip    

## Installation Firebase Admob Unity
1. Open your project in the Unity editor.
2. Navigate to **Assets -> Import Package -> Custom Package**.
3. Select the admob_unity_plugin.unitypackage file.
4. Import all of the files for the plugins by selecting **Import**. Make sure
   to check for any conflicts with files.
5. Edit AndroidManifest.xml change the appid to your
6. Edit /res/values/strings.xml change google_app_id to your
7. Unzip GoogleMobileAds.framework.zip to GoogleMobileAds.framework
8. Replace GoogleService-Info.plist with your file ,and add this this to your xcode project
9. Add other link flag -ObjC in xcode project


## Unity Plugin Wiki and Documentation
* [API](https://github.com/unity-plugins/Firebase-Admob-Unity/wiki/Admob-Unity-Plugin-API)
* [Tutorial](https://github.com/unity-plugins/Firebase-Admob-Unity/wiki)

## Quick Start
### Google Firebase Analyze

        FirebaseAnalytic firebase=FirebaseAnalytic.Instance();//init and start basic analysis
        //you can set more info as follow ,but this is optional
        firebase.logEvent("startevent", "{\"player\":\"yingke\"}");
        firebase.setUserId("232324432");
        firebase.setUserProperty("age", "20");
       // firebase.setAnalyticsCollectionEnabled(true);

#### 1.Init Firebase Admob Unity Plugin 
Create A C# script ,drag the script to a object on scene , add the follow code in the script file
```
    using admob;
    Admob.Instance().initSDK("admob id", new AdProperties());//admob id with format ca-app-pub-279xxxxxxxx~xxxxxxxx

```
#### 2.Add Admob Banner in Unity App 
Here is the minimal code needed to show admob banner.
```
    Admob.Instance().showBannerRelative("your banner id",AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
```

The AdPosition class specifies where to place the banner. AdSize specifies witch size banner to show

#### 3.Remove Banner 
By default, banners are visible. To temporarily hide a banner, call:
```
    Admob.Instance().removeBanner();
```

#### 4.How to integrate Interstitial into Unity 3d app?

Here is the minimal  code to create an interstitial.
```
    Admob.Instance().loadInterstitial("your interstitial id"); 
```
Unlike banners, interstitials need to be explicitly shown. At an appropriate
stopping point in your app, check that the interstitail is ready before
showing it:
```
    if (Admob.Instance().isInterstitialReady()) {
      Admob.Instance().showInterstitial();
    }
```
#### 5.Custom Admob Banner Ad Sizes
In addition to constants on _AdSize_, you can also create a custom size:
```
    //Create a 250x250 banner.
    AdSize adSize = new AdSize(250, 250);
    Admob.Instance().showBannerAbsolute("your banner id",adSize,0,30);
```
#### 6.Admob settings
If you want to test the ads ,non personalize ads,set tag for family or set tag for  children market,you can set with admob unity plugin easy
```
        AdProperties adProperties = new AdProperties();
        adProperties.isTesting = true;
        adProperties.isForChildDirectedTreatment=true;
        //adProperties.isUnderAgeOfConsent=true;
        adProperties.isAppMuted=true;
        adProperties.nonPersonalizedAdsOnly=true;
```
#### 7.Ad Events
Both _Banner_ and _Interstitial_ contain the same ad events that you can
register for. 
Here we'll demonstrate setting ad events on a interstitial,and show interstitial when load success:
```
    Admob.Instance().interstitialEventHandler += onInterstitialEvent;
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
```
You only need to register for the events you care about.

#### 8.How to integrate Admob Rewarded Video to Unity3d app?

Here is the minimal  code to create an admob video.
```
    Admob.Instance().loadRewardedVideo("ca-app-pub-312xxxxxxxxxxxx/xxxxxxxx"); 
```
Simular with interstitial,video need to be explicitly shown at an appropriate
stopping point in your app, check that the video is ready before
showing it:
```
    if (Admob.Instance().isRewardedVideoReady()) {
      Admob.Instance().showRewardedVideo();
    }
```

#### 9.Show Admob Advance Native Ad in IOS and Android App 
Here is the minimal code needed to show admob banner.
This is implemented with Admob Native Advanced as AdMob announced stop the express format ads 
```
    Admob.Instance().showNativeBannerRelative("native ad id",new AdSize(360,100), AdPosition.BOTTOM_CENTER, 0,"defaultNativeBanner");

```

The AdPosition class specifies where to place the banner. AdSize specifies witch size banner to show

#### 10.Remove Admob Native Banner 
By default, banners are visible. To temporarily hide a banner, call:
```
    Admob.Instance().removeBanner("defaultNativeBanner");
```

## Important Tips
1. If you not config AndroidManifest.xml,APP will crash
2. Attach admob to Object on scene,init admob before call admob fun
3. Add GoogleService-Info.plist to your xcode project,otherwise,APP will crash
4. Add Link Flag -ObjC to your xcode project,otherwise,APP will crash
5. Unzip GoogleMobileAds.framework.zip to GoogleMobileAds.framework
6. Edit res/values/string.xml and set the appid to your    

## Screenshots
![ScreenShot](https://github.com/unity-plugins/Firebase-Admob-Unity/blob/master/doc/android_banner_full.jpg?raw=true) 

## License
[Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0.html)
