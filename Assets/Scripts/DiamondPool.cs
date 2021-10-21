using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPool : MonoBehaviour
{
    public int poolSize;
    public GameObject diamondPrefab;
    List<GameObject> Pool;
    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = (GameObject)Instantiate(diamondPrefab, transform.position, diamondPrefab.transform.rotation);
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

        GameObject gameObject = (GameObject)Instantiate(diamondPrefab, transform.position, diamondPrefab.transform.rotation);
        gameObject.SetActive(false);
        Pool.Add(gameObject);
        return gameObject;
    }
}
