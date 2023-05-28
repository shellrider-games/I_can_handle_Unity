using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLifeTime;

    private void Start()
    {
        StartCoroutine(DestroyAfer(maxLifeTime));
    }

    private void Update()
    {
        transform.Translate(speed* Time.deltaTime * Vector3.forward);
    }

    private IEnumerator DestroyAfer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
