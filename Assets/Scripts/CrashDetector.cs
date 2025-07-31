using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public FinishLine finishLine; // Reference to the FinishLine script
    [SerializeField] float restartDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;

    void Start()
    {
        // Ensure the FinishLine script is assigned
        if (finishLine == null)
        {
            finishLine = FindObjectOfType<FinishLine>();
        }

    }
    void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
        if (PlayerCollider.CompareTag("Ground"))
        {
            FindObjectOfType<SnowboarderController>().DisableControls();
            crashEffect.Play();
            Invoke("RestartLevel", restartDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSound);
        }
    }
    void RestartLevel()
    {
        Int32 currentLevel = finishLine.CurrentLevel;
        SceneManager.LoadScene(currentLevel);
    }
}
