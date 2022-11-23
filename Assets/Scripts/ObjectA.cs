using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public Vector3 _rotation;
    public float rotate_speed;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Vector3(1, 0, 0);
        rotate_speed = 45.0f;
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(_rotation * rotate_speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {

        }
    }


}
