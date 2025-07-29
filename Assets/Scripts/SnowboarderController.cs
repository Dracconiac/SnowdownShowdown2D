using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboarderController : MonoBehaviour
{
    Rigidbody2D rb2dPlayer;
    [SerializeField] float torqueAmount = 10f;

    void Start()
    {
        rb2dPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2dPlayer.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2dPlayer.AddTorque(-torqueAmount);
        }

    }
}
