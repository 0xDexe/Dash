using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public int poolSize;
    public GameObject Prefab;
    List<GameObject> Pool = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = (GameObject)Instantiate(Prefab, transform.position, Prefab.transform.rotation);
        
            gameObject.SetActive(false);
            Pool.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject getObject()
    {
        foreach (GameObject obj in Pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        GameObject gameObject = (GameObject)Instantiate(Prefab, transform.position, Prefab.transform.rotation);
        gameObject.SetActive(false);
        Pool.Add(gameObject);
        return gameObject;
    }
}
