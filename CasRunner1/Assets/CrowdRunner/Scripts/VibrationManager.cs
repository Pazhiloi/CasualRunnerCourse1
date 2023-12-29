using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private void Start() {
      PlayerDetection.onDoorsHit += Vibrate;
      Enemy.onRunnerDied += Vibrate;
      GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy() {
    PlayerDetection.onDoorsHit -= Vibrate;
    Enemy.onRunnerDied -= Vibrate;
    GameManager.onGameStateChanged -= GameStateChangedCallback;
  }

  private void GameStateChangedCallback(GameManager.GameState gameState)
  {
    if (gameState == GameManager.GameState.LevelComplete)
    {
      Vibrate();
    }
    else if (gameState == GameManager.GameState.Gameover)
    {
      Vibrate();
    }
  }


  private void Vibrate(){
    Taptic.Light();
  }
}
