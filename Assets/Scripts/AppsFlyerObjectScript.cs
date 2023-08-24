using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
using TMPro;

public class AppsFlyerObjectScript : MonoBehaviour , IAppsFlyerConversionData
{
    public static AppsFlyerObjectScript Instance;
    [SerializeField] private TMP_Text conversionDataText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            FindObjectOfType<FlyBehaviour>().enabled = true;
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        AppsFlyer.initSDK("ZLigGqGzDdxGMT7QBPjsMG", null, this);
        AppsFlyer.startSDK();
    }

    public void onConversionDataSuccess(string conversionData)
    {
        Debug.Log("Success");
        AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        // add deferred deeplink logic here
        conversionDataText.text = conversionData;
        Destroy(conversionDataText.gameObject, 3f);
        FindObjectOfType<FlyBehaviour>().enabled = true;
    }

    public void onConversionDataFail(string error)
    {
        Debug.Log("Fail");
        AppsFlyer.AFLog("onConversionDataFail", error);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        Debug.Log("onAppOpenAttribution");
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        Debug.Log("onAppOpenAttributionFailure");
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }
}