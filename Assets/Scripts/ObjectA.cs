using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public Vector3 _rotation;
    public float rotate_speed;
    public bool is_rotate;

    public float speed;

    public bool is_move;
    public int axis;
    public float height;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Vector3(0, 1, 0);
        rotate_speed = 45.0f;
        is_rotate = false;

        speed = 10.0f;

        is_move = false;
        axis = 0;
        height = 0.2f;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        
        if (is_rotate)
        {
            transform.Rotate(_rotation * rotate_speed * Time.deltaTime);
        }

        if (is_move)
        {
            if (axis == 0)
            {
                transform.Translate(Mathf.Sin(Time.time * (2.0f + 19120223.0f % 10.0f)) * height, 0f, 0f);
            }
            else if (axis == 1)
            {
                transform.Translate(0f, Mathf.Sin(Time.time * (2.0f + 19120223.0f % 10.0f)) * height, 0f);
            }
            else
            {
                transform.Translate(0f, 0f, Mathf.Sin(Time.time * (2.0f + 19120223.0f % 10.0f)) * height);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (is_rotate)
            {
                is_rotate = false;
            }
            else
            {
                is_rotate = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (is_move)
            {
                is_move = false;
            }
            else
            {
                is_move = true;
                axis = Random.Range(0, 3);
            }
        }
    }
}
