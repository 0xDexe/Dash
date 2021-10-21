using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaviour : MonoBehaviour
{
    public GameObject sm;
    ScoreManager sm_script; 
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindWithTag("sm"); 
        sm_script= sm.GetComponent<ScoreManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        gameObject.SetActive(false);
        sm_script.PowerUp(); 
    }
}
