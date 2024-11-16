
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener
{
    public static InterstitialAd Instance { get; private set;}
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;
    private bool isAdLoaded = false;
    private int buildTowersCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer )
        {
            _adUnitId = _iOsAdUnitId;
        }
        else
        {
            _adUnitId = _androidAdUnitId;
        }
        //AdsInitializer.Instance.OnInitializationComplete.AddListener(LoadAd);
    }
   public void OnUnityAdsAdLoaded(string placementId)
   {
    isAdLoaded = true;
    Debug.Log("Ad loading is completed");
   }
   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {
    Debug.Log($"Error loading ad unit: {_adUnitId} - {error.ToString()} - {message}");
   }
   public void OnUnityAdsShowClick(string placementId)
   {

   }
   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {
    Debug.Log("Ad over!");
    isAdLoaded = false;
    Time.timeScale = 1;
    LoadAd();
   }
   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
     Debug.Log($"Error loading ad unit: {_adUnitId} - {error.ToString()} - {message}");
   }
   public void OnUnityAdsShowStart(string placementId)
   {
    Debug.Log("Ad has started");
   }
   public void LoadAd()
   {
    Debug.Log("Advertisement has started loading...");
    Advertisement.Load(_adUnitId, this);
   }
   private void ShowAd()
   {
    Time.timeScale = 0;
    if(isAdLoaded)
    {
        Debug.Log("Ready");
        Advertisement.Show(_adUnitId, this);
    }

    else
    {
        Debug.Log("Add has not loaded yet");
    }
   }
   public void TowerWasBuilt()
   {
    buildTowersCount++;
    if(buildTowersCount >= 5)
    {
        buildTowersCount = 0;
        ShowAd();
    }
   }
}
