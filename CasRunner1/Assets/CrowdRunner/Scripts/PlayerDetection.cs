using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{


  [Header("Elements")]
  [SerializeField] private CrowdSystem crowdSystem;
  Collider[] detectedColliders;

  private void Update()
  {
    DetectDoors();
  }
  private void DetectDoors()
  {
    detectedColliders = Physics.OverlapSphere(transform.position, 1);

    for (int i = 0; i < detectedColliders.Length; i++)
    {
      if (detectedColliders[i].TryGetComponent(out Doors doors))
      {
        Debug.Log("Hit some doors");

        int bonusAmount = doors.GetBonusAmount(transform.position.x);
        BonusType bonusType = doors.GetBonusType(transform.position.x);

        doors.Disable();

        crowdSystem.ApplyBonus(bonusType, bonusAmount);
      }else if (detectedColliders[i].tag == "Finish")
      {
        SceneManager.LoadScene(0);
      }


    }
  }
}
