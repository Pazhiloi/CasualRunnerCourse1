using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public enum GameState { Menu, Game, LevelComplete, Gameover }
  private GameState gameState;

  public static Action<GameState> onGameStateChanged;
  private void Awake()
  {
    if (instance != null)
      Destroy(gameObject);
    else
      instance = this;
  }

  public void SetGameState(GameState gameState)
  {
    this.gameState = gameState;
    onGameStateChanged?.Invoke(gameState);

    Debug.Log("Game state : " + gameState);
  }
  public bool IsGameState(){
    return gameState == GameState.Game;
  }
}
