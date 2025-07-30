using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
         Debug.Log("OnTriggerEnter2D was called.");
        if (PlayerCollider.CompareTag("Ground"))
        {
            Debug.Log("Crash detected with " + PlayerCollider.gameObject.name);
        }
    }
}
