using UnityEngine;
using System.Collections;

public class RedTroopsSDK : MonoBehaviour {

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void getAd(int adType);
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public int checkAd(int adType);

    public void GetInterstitial()
    {
        Debug.Log ("Requested Interstitial");
        getAd(2);
    }

    public void GetTopBanner()
    {
        Debug.Log ("Requested Top Banner");
        getAd(0);
    }

    public void GetBottomBanner()
    {
        Debug.Log ("Requested Bottom Banner");
        getAd(1);
    }

    public void GetNative()
    {
        Debug.Log ("Requested Native");
        getAd(3);
    }

    public void GetAudio()
    {
        Debug.Log ("Requested Audio");
        getAd(4);
    }

    public void GetVideo()
    {
        Debug.Log ("Requested Video");
        getAd(5);
    }

    public bool CheckInterstitial()
    {
        Debug.Log ("Checking Interstitial");
        return checkAd(2) == 1;
    }

    public bool CheckTopBanner()
    {
        Debug.Log ("Checking Top Banner");
        return checkAd(0) == 1;
    }

    public bool CheckBottomBanner()
    {
        Debug.Log ("Checking Bottom Banner");
        return checkAd(1) == 1;
    }

    public bool CheckNative()
    {
        Debug.Log ("Checking Native");
        return checkAd(3) == 1;
    }

    public bool CheckAudio()
    {
        Debug.Log ("Checking Audio");
        return checkAd(4) == 1;
    }

    public bool CheckVideo()
    {
        Debug.Log ("Checking Video");
        return checkAd(5) == 1;
    }
}
