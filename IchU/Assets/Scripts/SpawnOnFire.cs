using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SpawnOnFire : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float spawnOffset;

    private void OnFire(InputValue inputValue)
    {
        GameObject noob = Instantiate(spawnObject, transform.position, Quaternion.identity);
        noob.transform.LookAt(transform.position + transform.forward, Vector3.up);
        noob.transform.Translate(spawnOffset* Vector3.forward);
        AkSoundEngine.PostEvent("shot", gameObject);
    }
}
