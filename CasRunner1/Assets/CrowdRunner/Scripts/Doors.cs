using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors : MonoBehaviour
{

  enum BonusType { Addition, Difference, Product, Division }
  [Header("Elements")]
  [SerializeField] private SpriteRenderer rightDoorRenderer;
  [SerializeField] private SpriteRenderer leftDoorRenderer;
  [SerializeField] private TextMeshPro rightDoorText;
  [SerializeField] private TextMeshPro leftDoorText;

  [Header("Settings")]
  [SerializeField] private BonusType rightDoorBonusType;
  [SerializeField] private int rightDoorBonusAmount;

  [SerializeField] private BonusType leftDoorBonusType;
  [SerializeField] private int leftDoorBonusAmount;

  [SerializeField] private Color bonusColor;
  [SerializeField] private Color penaltyColor;

  private void Start()
  {
    ConfigureDoors();
  }

  private void ConfigureDoors()
  {

    switch (rightDoorBonusType)
    {
      case BonusType.Addition:
        rightDoorRenderer.color = bonusColor;
        rightDoorText.text = "+" + rightDoorBonusAmount;
        break;
      case BonusType.Difference:
        rightDoorRenderer.color = penaltyColor;
        rightDoorText.text = "-" + rightDoorBonusAmount;
        break;
      case BonusType.Product:
        rightDoorRenderer.color = bonusColor;
        rightDoorText.text = "x" + rightDoorBonusAmount;
        break;
      case BonusType.Division:
        rightDoorRenderer.color = penaltyColor;
        rightDoorText.text = "/" + rightDoorBonusAmount;
        break;
    }

    
    switch (leftDoorBonusType)
    {
      case BonusType.Addition:
        leftDoorRenderer.color = bonusColor;
        leftDoorText.text = "+" + leftDoorBonusAmount;
        break;
      case BonusType.Difference:
        leftDoorRenderer.color = penaltyColor;
        leftDoorText.text = "-" + leftDoorBonusAmount;
        break;
      case BonusType.Product:
        leftDoorRenderer.color = bonusColor;
        leftDoorText.text = "x" + leftDoorBonusAmount;
        break;
      case BonusType.Division:
        leftDoorRenderer.color = penaltyColor;
        leftDoorText.text = "/" + leftDoorBonusAmount;
        break;
    }
    
    
  }

}
