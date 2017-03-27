Google Firebase Unity Admob Plugin
==============================

Google Firebase Unity Admob Plugin provides a way to integrate firebase admob ads in Unity3D Game and u3d app.
You can use it for Unity iOS and Android App with the same c# or js code.It support all native firebase admob features such as Native Express Ad

## Google Firebase Unity Admob Plugin Features
Platforms supported in one plugin :
- [x] Android, Based Admob SDK v10.2 (part of Google Firebase service)
- [x] iOS, via SDK v7.18.0
- [x] Support all native events
- [x] AdRequest targeting methods,such as children target,test mode
- [x] Not need change Android package name
- [x] Very simple API
- [x] Based on FireBase SDK Version

Ad Types:
- [x] Banner(All Banner Type and Custom banner sizes)
- [x] Interstitial (text, picture, video)
- [x] Rewarded Video 
- [x] Native Express Ad 
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

## Unity Plugin Wiki and Documentation
* [API](https://github.com/unity-plugins/Firebase-Admob-Unity/wiki/Admob-Unity-Plugin-API)
* [Tutorial](https://github.com/unity-plugins/Firebase-Admob-Unity/wiki)

## Quick Start
#### 1.Init Firebase Admob Unity Plugin 
Create A C# script ,drag the script to a object on scene , add the follow code in the script file
```
    using admob;
    Admob.Instance().initAdmob("admob banner id", "admob interstitial id");//admob id with format ca-app-pub-279xxxxxxxx/xxxxxxxx

```
#### 2.Add Admob Banner in Unity App 
Here is the minimal code needed to show admob banner.
```
    Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
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
    Admob.Instance().loadInterstitial(); 
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
    Admob.Instance().showBannerAbsolute(adSize,0,30);
```
#### 6.Admob test Ads and children app
If you want to test the ads or the your app with children target,you can set with admob unity plugin easy
```
    Admob.Instance().setTesting(true);
    Admob.Instance().setForChildren(true);
     string[] keywords = { "game","crash","male game"};
     Admob.Instance().setKeywords(keywords);
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

#### 9.Show Admob Native Express Ad in IOS and Android App 
Here is the minimal code needed to show admob banner.
```
    Admob.Instance().showNativeBannerRelative(new AdSize(360,100), AdPosition.BOTTOM_CENTER, 0,"ca-app-pub-3940256099942544/2562852117","defaultNativeBanner");

```

The AdPosition class specifies where to place the banner. AdSize specifies witch size banner to show

#### 10.Remove Admob Native Banner 
By default, banners are visible. To temporarily hide a banner, call:
```
    Admob.Instance().removeBanner("defaultNativeBanner");
```

## Important Tips
1. remove **GoogleMobileAds.framework** and then  Add **GoogleMobileAds.framework**. to Xcode Project manually
2. Add the following framework to Xcode project
```
    AdSupport.framework,EventKit.framework,EventKitUI.framework,CoreTelephony.framework,StoreKit.framework,MessageUI.framework
```
3. attach admobdemo.cs to the main camera or object object on stage all the time.    

## Screenshots
![ScreenShot](https://github.com/unity-plugins/Firebase-Admob-Unity/blob/master/doc/android_banner_full.jpg?raw=true) 

## License
[Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0.html)