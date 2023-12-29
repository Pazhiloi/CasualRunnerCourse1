using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerDetection : MonoBehaviour
{


  [Header("Elements")]
  [SerializeField] private CrowdSystem crowdSystem;

  [Header("Events")]
  public static Action onDoorsHit;
  Collider[] detectedColliders;

  private void Update()
  {

    if (GameManager.instance.IsGameState())
    {
      DetectColliders();
    }
  }
  private void DetectColliders()
  {
    detectedColliders = Physics.OverlapSphere(transform.position, crowdSystem.GetCrowdRadius());

    for (int i = 0; i < detectedColliders.Length; i++)
    {
      if (detectedColliders[i].TryGetComponent(out Doors doors))
      {
        Debug.Log("Hit some doors");

        int bonusAmount = doors.GetBonusAmount(transform.position.x);
        BonusType bonusType = doors.GetBonusType(transform.position.x);

        doors.Disable();

        onDoorsHit?.Invoke();

        crowdSystem.ApplyBonus(bonusType, bonusAmount);
      }else if (detectedColliders[i].tag == "Finish")
      {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

        GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
        // SceneManager.LoadScene(0);
      }
      else if (detectedColliders[i].tag == "Coin")
      {
        Destroy(detectedColliders[i].gameObject);
        DataManager.instance.AddCoins(1);
        // SceneManager.LoadScene(0);
      }

    }
  }
}
