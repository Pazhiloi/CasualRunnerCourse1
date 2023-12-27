using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
  [Header("Elements")]
  [SerializeField] private Chunk[] chunksPrefabs;
  [SerializeField] private Chunk[] levelChunks;


  private void Start()
  {
    CreateOrderedLevel();
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
}
