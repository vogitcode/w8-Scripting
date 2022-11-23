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

    // Start is called before the first frame update
    void Start()
    {
        ObjectA = Instantiate(PrefabObjectA, new Vector3(0, Random.Range(10.0f, 20.0f), 0), Quaternion.identity);
        RigidbodyA = ObjectA.GetComponent<Rigidbody>();
        RigidbodyA.useGravity = false;
        ObjectBs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectB = Instantiate(PrefabObjectB, new Vector3(Random.Range(-15.0f, 10.0f), Random.Range(10.0f, (10.0f + 19120223.0f % 10.0f)), Random.Range(-10.0f, 15.0f)), Quaternion.identity);
            ObjectBs.Add(ObjectB);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            float waitTime = 2.0f;
            StartCoroutine(DelayDeleteAction(waitTime));
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
