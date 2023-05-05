using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalStats.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
