using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject PrefabObjectA;
    public GameObject PrefabObjectB;

    private GameObject ObjectA;
    private GameObject ObjectB;
    private List<GameObject> ObjectBs;

    private Rigidbody RigidbodyA;

    public Vector3 _rotation;
    public float rotate_speed;
    public bool is_rotate;
    public bool is_change;

    // Start is called before the first frame update
    void Start()
    {
        ObjectA = Instantiate(PrefabObjectA, new Vector3(0, Random.Range(10.0f, 20.0f), 0), Quaternion.identity);
        RigidbodyA = ObjectA.GetComponent<Rigidbody>();
        RigidbodyA.useGravity = false;
        ObjectBs = new List<GameObject>();

        _rotation = new Vector3(1, 1, 0);
        rotate_speed = 30.0f;
        is_rotate = false;
        is_change = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (is_rotate)
        {
            for (int i = 0; i < ObjectBs.Count; i++)
            {
                ObjectBs[i].transform.Rotate(_rotation * rotate_speed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectB = Instantiate(PrefabObjectB, new Vector3(Random.Range(-15.0f, 10.0f), Random.Range(10.0f, (10.0f + 19120223.0f % 10.0f)), Random.Range(-10.0f, 15.0f)), Quaternion.identity);
            ObjectBs.Add(ObjectB);
            is_change = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            float waitTime = 2.0f;
            StartCoroutine(DelayDeleteAction(waitTime));
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i=0; i<ObjectBs.Count; i++)
            {
                ObjectBs[i].GetComponent<Rigidbody>().useGravity = false;
                if (!is_change)
                {
                    ObjectBs[i].transform.position += new Vector3(0f, Random.Range(1.0f, 5.0f), 0f);
                }
            }

            if (!is_change)
            {
                is_change = true;
            }

            if (is_rotate)
            {
                is_rotate = false;
            }
            else
            {
                is_rotate = true;
            }
        }
    }

    void Destruction(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private IEnumerator DelayDeleteAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        int count = ObjectBs.Count;
        if (count != 0)
        {
            int rng = Random.Range(0, count);
            if (rng >= 0)
            {
                Destruction(ObjectBs[rng]);
                ObjectBs.RemoveAt(rng);
            }
        }
    }
}
