using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardsAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] 
    private string _androidAdUnitId = "Rewarded_Android";
    [SerializeField]
    private string _iOsAdUnitId= "Rewarded_iOs";
    private string _adUnitId;
    private bool isAdLoaded = false;
    [SerializeField]
    private Button _showAdButton;
    private void Awake()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _adUnitId = _iOsAdUnitId;

        }
        else
        {
            _adUnitId = _androidAdUnitId;
        }
        _showAdButton.interactable = false;
        _showAdButton.onClick.AddListener(ShowAd);
        StartCoroutine(WaitBeforeShowingNextAd());

    }





    public void OnUnityAdsAdLoaded(string placementId)
   {
     Debug.Log("Ad loading is completed");
   }
   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {
    Debug.Log("Ad is ");
    isAdLoaded = true;
   }
   public void OnUnityAdsShowClick(string placementId)
   {

   }
   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {
    if(placementId.Equals (_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
    
    {
        GameController.Instance.AddCoins(100);
    }
    LoadAd();
    StartCoroutine(WaitBeforeShowingNextAd());
   }
   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
    
   }
   public void OnUnityAdsShowStart(string placementId)
   {
    
   }
   private IEnumerator WaitBeforeShowingNextAd()
   {
    yield return new WaitForSeconds(5);
    yield return new WaitUntil(() => isAdLoaded);

    /*while (!isAdLoaded)
    {
        yield return new WaitForSeconds(0.1f);
    }*/
    _showAdButton.interactable = true;
   }
   public void  ShowAd()
   {
    _showAdButton.interactable = false;
    Advertisement.Show(_adUnitId, this);
   }
   public void LoadAd()
   {
    Advertisement.Load(_adUnitId, this);
   }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
