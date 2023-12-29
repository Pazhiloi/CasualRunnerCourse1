using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
  public static DataManager instance;
  [Header("Coin Texts")]
  [SerializeField] private TextMeshProUGUI[] coinsTexts;
  private int coins;


  private void Start()
  {
    UpdateCoinsTexts();
  }
  private void Awake()
  {
    if (instance != null){
      Destroy(gameObject);
    }
    else{
      instance = this;
    }

    coins = PlayerPrefs.GetInt("coins", 0);

  }


  private void UpdateCoinsTexts()
  {
    foreach (TextMeshProUGUI coinText in coinsTexts)
    {
      coinText.text = coins.ToString();
    }
  }


  public void AddCoins(int amount)
  {
    coins += amount;

    UpdateCoinsTexts();

    PlayerPrefs.SetInt("coins", coins);
  }
}
