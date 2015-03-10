<p align="center">
<img src="http://redtroops.com/images/logo_large.png" alt="RedTroops" width="150px">
</p>


#RedTroops SDK 2.0 for Unity
##Unity Documentation
Requirements: **IOS 6.0 + / Android 2.3.3+ (API 10)**

###Getting Started

RedTroops SDK 2.0 currently features:

**Push notifications.**

**User analytics.**

**Interstitial, Banner and Native HTML5 ads.**

###Considerations

RedTroops does not provide a native Unity SDK currently. An integration on the Android/iOS build projects is available to enable RedTroops functions.

###Unity Integration on iOS

In order to enable RedTroops SDK, follow the steps below according to your scripting language and targeted platforms:

Link|Unity Script  | Target Platforms
---|------------- | -------------
[Link](#iaj)|JavaScript | iOS and Android
[Link](#iac)|C#  | iOS and Android
Link|JavaScript | iOS
Link|JavaScript  | Android
Link|C# | iOS
Link|C#  | Android

####<a name="iaj"></a>iOS and Android Platforms for Unity JavaScript scripting

1) Create a new *C#* script in your *Plugins* folder (Not in your scripts folder) named *RedTroopsSDK* containing the following:

> Required: Create Plugins folder if it did not exist.

```csharp
using UnityEngine;
using System.Collections;

public class RedTroopsSDK : MonoBehaviour {

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void GetUnityInterstitial();
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void GetUnityBanner();

    void GetInterstitial()
    {
        Debug.Log ("Requested Interstitial");
        GetUnityInterstitial();
    }

    void GetBanner()
    {
        Debug.Log ("Requested Banner");
        GetUnityBanner();
    }
}
```

2) Add RedTroopsSDK C# script which we have created in step 1 to a GameObject which will trigger the advertisements (e.g. your GameController). This is done by selecting the GameObject, and selecting "Add a new component" -> RedTroops SDK.

> You may add it on multiple GameObjects.

3) Add the following lines to trigger an interstitial ad:

```js

#if UNITY_IPHONE
if (Application.platform == RuntimePlatform.IPhonePlayer) {
    try{
        this.GetComponent("RedTroopsSDK").GetComponent("RedTroopsSDK").SendMessage("GetInterstitial");
    } catch (err){
        Debug.Log("SDK does not exist");
    }
}
#endif

#if UNITY_ANDROID
    try{
        var cls_UnityPlayer =  new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var obj_Activity = cls_UnityPlayer.GetStatic.<AndroidJavaObject>("currentActivity");
        obj_Activity.CallStatic("showInterstitialAd");
    } catch (err){
        Debug.Log("SDK does not exist");
    }
#endif

```

4) Add the following lines to trigger a banner ad:

```js

#if UNITY_IPHONE
if (Application.platform == RuntimePlatform.IPhonePlayer) {
    try{
        this.GetComponent("RedTroopsSDK").GetComponent("RedTroopsSDK").SendMessage("GetBanner");
    } catch (err){
        Debug.Log("SDK does not exist");
    }
}
#endif

#if UNITY_ANDROID
    try{
        var cls_UnityPlayer =  new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var obj_Activity = cls_UnityPlayer.GetStatic.<AndroidJavaObject>("currentActivity");
        obj_Activity.CallStatic("showBannerAd");
    } catch (err){
        Debug.Log("SDK does not exist");
    }
#endif

```

5) Export your project to Android and to iOS projects.

6) Follow [Unity Android SDK](http://github.com/redtroops/android-sdk) and [Unity iOS SDK](http://github.com/redtroops/ios-sdk) documentations for implementations in your exported projects.

####<a name="iac"></a>iOS and Android Platforms for Unity C# scripting

1) Create a new *C#* script in your scripts folder named *RedTroopsSDK* containing the following:

```csharp
using UnityEngine;
using System.Collections;

public class RedTroopsSDK : MonoBehaviour {

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void GetUnityInterstitial();
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void GetUnityBanner();

    void GetInterstitial()
    {
        Debug.Log ("Requested Interstitial");
        GetUnityInterstitial();
    }

    void GetBanner()
    {
        Debug.Log ("Requested Banner");
        GetUnityBanner();
    }
}
```

2) Add RedTroopsSDK C# script which we have created in step 1 to a GameObject which will trigger the advertisements (e.g. your GameController). This is done by selecting the GameObject, and selecting "Add a new component" -> RedTroops SDK.

> You may add it on multiple GameObjects.

3) Add the following lines to trigger an interstitial ad:

> You need to import System to enable error catching. Add `using System;` to the top of your script.

```csharp

#if UNITY_IPHONE
    if (Application.platform == RuntimePlatform.IPhonePlayer) {
        try{
            this.GetComponent ("RedTroopsSDK").GetComponent ("RedTroopsSDK").SendMessage ("GetInterstitial");
        } catch (Exception err){
            Debug.Log("SDK does not exist");
        }
    }
#endif

#if UNITY_ANDROID
    try{
        using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
            using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
                obj_Activity.CallStatic("showInterstitialAd");
            }
        }
    } catch (Exception err){
        Debug.Log("SDK does not exist");
    }
#endif

```

4) Add the following lines to trigger a banner ad:

```csharp

#if UNITY_IPHONE
    if (Application.platform == RuntimePlatform.IPhonePlayer) {
        try{
            this.GetComponent ("RedTroopsSDK").GetComponent ("RedTroopsSDK").SendMessage ("GetBanner");
        } catch (Exception err){
            Debug.Log("SDK does not exist");
        }
    }
#endif

#if UNITY_ANDROID
    try{
        using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
            using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
                obj_Activity.CallStatic("showBannerAd");
            }
        }
    } catch (Exception err){
        Debug.Log("SDK does not exist");
    }
#endif

```

5) Export your project to Android and to iOS projects.

6) Follow [Unity Android SDK](http://github.com/redtroops/android-sdk) and [Unity iOS SDK](http://github.com/redtroops/ios-sdk) documentations for implementations in your exported projects.

**If you need any help or for more information, please visit:**  <a href="http://docs.redtroops.com" class="btn">RedTroops Docs</a>
