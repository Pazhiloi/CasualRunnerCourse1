using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
  [Header("Elements")]
  [SerializeField] private SoundsManager soundsManager;
  [SerializeField] private VibrationManager vibrationManager;
  [SerializeField] private Sprite optionsOnSprite;
  [SerializeField] private Sprite optionsOffSprite;
  [SerializeField] private Image soundsButtonImage;
  [SerializeField] private Image hapticsButtonImage;


  [Header("Settings")]
  private bool soundsState = true;
  private bool hapticsState = true;



  private void Awake()
  {
    soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
    hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;
  }
  private void Start()
  {
    Setup();
  }

  private void Setup()
  {
    if (soundsState)
    {
      DisableSounds();
    }
    else
    {
      EnableSounds();
    }
    if (hapticsState)
    {
      DisableHaptics();
    }
    else
    {
      EnableHaptics();
    }
  }

  public void ChangeSoundsState()
  {
    if (soundsState)
    {
      DisableSounds();
    }
    else
    {
      EnableSounds();
    }
    soundsState = !soundsState;
    
    PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);
  }

  private void DisableSounds()
  {
    soundsManager.DisableSounds();
    soundsButtonImage.sprite = optionsOffSprite;
  }
  private void EnableSounds()
  {
    soundsManager.EnableSounds();
    soundsButtonImage.sprite = optionsOnSprite;
  }

  public void ChangeHapticsState()
  {
    if (hapticsState)
    {
      DisableHaptics();
    }
    else
    {
      EnableHaptics();
    }
    hapticsState = !hapticsState;
    PlayerPrefs.SetInt("haptics", hapticsState ? 1 : 0);
  }

  private void DisableHaptics()
  {
    vibrationManager.DisableVibrations();
    hapticsButtonImage.sprite = optionsOffSprite;
  }
  private void EnableHaptics()
  {
    vibrationManager.EnableVibrations();
    hapticsButtonImage.sprite = optionsOnSprite;
  }

}