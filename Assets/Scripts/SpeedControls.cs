using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControls : MonoBehaviour
{

    SurfaceEffector2D surfEffSnow;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float maxSpeed = 16f;

    void Start()
    {
        surfEffSnow = GetComponent<SurfaceEffector2D>();
        surfEffSnow.speed = 2f;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfEffSnow.speed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfEffSnow.speed -= acceleration * Time.deltaTime;
        }

        surfEffSnow.speed = Mathf.Clamp(surfEffSnow.speed, 0, maxSpeed);        
    }
}
