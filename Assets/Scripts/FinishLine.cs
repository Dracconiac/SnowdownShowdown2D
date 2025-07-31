using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    public Int32 CurrentLevel = 0;
    Int32 nextLevel = 0;

    void OnTriggerExit2D(Collider2D finishLineCollider)
    {
        if (finishLineCollider.CompareTag("Player"))
        {
            //nextLevel = CurrentLevel++;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("LoadNextLevel", finishDelay);
        }
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
