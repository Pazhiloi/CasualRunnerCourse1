using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
  [SerializeField] private float radius;
  [SerializeField] private float angle;

  private void Update()
  {
    PlaceRunners();
  }

  private void PlaceRunners()
  {
    for (int i = 0; i < transform.childCount; i++)
    {
      Vector3 childLocalPosition = GetRunnerLocalPosition(i);
      transform.GetChild(i).localPosition = childLocalPosition;
    }
  }
  private Vector3 GetRunnerLocalPosition(int index)
  {
    float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
    float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

    return new Vector3(x, 0, z);
  }
}
