using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePooler : MonoBehaviour
{
    private void OnDisable()
    {
        if (Pool.Instance != null)
        Pool.Instance.AddToPool(gameObject);
    }
}
