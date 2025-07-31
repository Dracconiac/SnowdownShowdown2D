using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboarderController : MonoBehaviour
{
    Rigidbody2D rb2dPlayer;
    bool hasLost = false;
    bool leftArrowHeld = false;
    bool rightArrowHeld = false;
    float leftArrowTimer = 0f;
    float rightArrowTimer = 0f;
    const float holdTime = 1.0f;

    float torqueAmount = 65f;
    [SerializeField] AudioClip frontFlipSound;
    [SerializeField] AudioClip backFlipSound;

    void Start()
    {
        rb2dPlayer = GetComponent<Rigidbody2D>();
        rb2dPlayer.angularDrag = 15f;
        rb2dPlayer.gravityScale = 1.18f;
    }

    void Update()
    {
        if (!hasLost)
        {
            HandleMovement();
        }

    }
    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2dPlayer.AddTorque(torqueAmount);

            // Play backFlipSound only if LeftArrow has been held for holdTime seconds
            if (!leftArrowHeld)
            {
                leftArrowHeld = true;
                leftArrowTimer = 0f;
            }
            else
            {
                leftArrowTimer += Time.deltaTime;
                if (leftArrowTimer >= holdTime)
                {
                    GetComponent<AudioSource>().PlayOneShot(backFlipSound);
                    leftArrowTimer = 0f; // Reset timer after playing sound
                }
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2dPlayer.AddTorque(-torqueAmount);

            if (!rightArrowHeld)
            {
                rightArrowHeld = true;
                rightArrowTimer = 0f;
            }
            else
            {
                rightArrowTimer += Time.deltaTime;
                if (rightArrowTimer >= holdTime)
                {
                    GetComponent<AudioSource>().PlayOneShot(frontFlipSound);
                    rightArrowTimer = 0f;
                }
            }
        }
    }

    public void DisableControls()
    {
        hasLost = true;
    }
}
