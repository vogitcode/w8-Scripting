using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject PrefabObjectA;
    public GameObject PrefabObjectB;
    public float velocity = 10.0f;

    private GameObject ObjectA;
    private Rigidbody RigidbodyA;
    private GameObject ObjectB;

    // Start is called before the first frame update
    void Start()
    {
        ObjectA = Instantiate(PrefabObjectA, new Vector3(0, Random.Range(10.0f, 20.0f), 0), Quaternion.identity);
        RigidbodyA = ObjectA.GetComponent<Rigidbody>();
        RigidbodyA.useGravity = false;

        //bool useGravity = ObjectA.GetComponent<Rigidbody>().useGravity;
        //useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RigidbodyA.AddForce(Vector3.left * velocity);
            //ObjectA.transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ObjectA.transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ObjectA.transform.position += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ObjectA.transform.position += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectB = Instantiate(PrefabObjectB, new Vector3(10.0f, Random.Range(5.0f, 10.0f), 0), Quaternion.identity);
            //Destruction(ObjectA);
        }
    }

    void Destruction(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
