using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int coinCount = 60;
    [SerializeField] 
    private Text coinText;
    // Start is called before the first frame update
    private void Awake()
    {
        coinText.text = coinCount.ToString();
        Instance = this;
    }

    // Update is called once per frame
    public void AddCoins(int amount)
    {
        coinCount += amount;
    }
    private void Update()
    {
        coinText.text = $"CoinCount: {coinCount}";
    }
}
