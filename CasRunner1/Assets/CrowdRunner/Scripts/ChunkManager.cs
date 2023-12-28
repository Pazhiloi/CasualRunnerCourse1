using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

  public static ChunkManager instance;
  [Header("Elements")]
  [SerializeField] private Chunk[] chunksPrefabs;
  [SerializeField] private Chunk[] levelChunks;
  private GameObject finishLine;


  private void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
    }
    else
    {
      instance = this;
    }
  }

  private void Start()
  {
    CreateOrderedLevel();

    finishLine = GameObject.FindWithTag("Finish");
  }


  private void CreateOrderedLevel()
  {
    Vector3 chunkPosition = Vector3.zero;

    for (int i = 0; i < levelChunks.Length; i++)
    {
      Chunk chunkToCreate = levelChunks[i];
      chunkPosition.y = -6;
      if (i > 0)
      {
        chunkPosition.z += chunkToCreate.GetLength() / 2;
      }

      Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
      chunkPosition.z += chunkInstance.GetLength() / 2;
    }
  }

  private void CreateRandomLevel()
  {
    Vector3 chunkPosition = Vector3.zero;

    for (int i = 0; i < 5; i++)
    {
      Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];
      chunkPosition.y = -6;
      if (i > 0)
      {
        chunkPosition.z += chunkToCreate.GetLength() / 2;
      }

      Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
      chunkPosition.z += chunkInstance.GetLength() / 2;
    }
  }

  public float GetFinishZ()
  {
    return finishLine.transform.position.z;
  }


  public int GetLevel()
  {
    return PlayerPrefs.GetInt("level" , 0);
  }
}
