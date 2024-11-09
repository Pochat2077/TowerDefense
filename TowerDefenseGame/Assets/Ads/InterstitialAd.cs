
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;
    private bool isAdLoaded = false;
    private int buildTowersCount = 0;
    // Start is called before the first frame update
   public void OnUnityAdsAdLoaded(string placementId)
   {

   }
   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {

   }
   public void OnUnityAdsShowClick(string placementId)
   {

   }
   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {

   }
   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {

   }
   public void OnUnityAdsShowStart(string placementId)
   {

   }
   private void LoadAd()
   {
    Debug.Log("Advertisement has started loading...");
    Advertisement.Load(_adUnitId, this);
   }
   private void ShowAd()
   {
    
   }
}
