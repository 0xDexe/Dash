using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;
using Random2 = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	
	public GameObject pillarHolder;
	public GameObject cube;	

	public float minDistance = 4f, maxDistance = 5f;

	Vector3 spawnPosition;
	bool isPaused; 

	public Pooler pooler;
	public DiamondPool powerPool; 
	public ScoreManager sm;
    Random rand;

	public GameObject refpoint;
	float height;
	public double probability; 
	

	// Use this for initialization
	void Start()
	{
		sm  = FindObjectOfType<ScoreManager>();
		spawnPosition = transform.position;
	
		isPaused = false; 
		rand = new Random();
		//InvokeRepeating()
	}

	void Update()
    {
		if(spawnPosition.z > refpoint.transform.position.x)
        {
			isPaused = true;
			Debug.Log("stop spawn");
		}
		else
        {
			isPaused = false;
			StartCoroutine(makingPillars());
			Debug.Log("Current " +transform.position.z);
			Debug.Log(refpoint.transform.position.x); 
		}
		
	}



	
	IEnumerator makingPillars()
	{
		
		while (isPaused)
		{
			yield return null;
		}
		while(!isPaused)
        {
			GameObject tempPillar = pooler.getObject();
			tempPillar.transform.position = spawnPosition;
			tempPillar.SetActive(true);
			tempPillar.transform.SetParent(pillarHolder.transform);
			tempPillar.GetComponent<PillarBehaviour>().cube = cube;
			//height = tempPillar.GetComponent<BoxCollider>().size.y;	

			
			if (  rand.NextDouble() <0.7) //use public var
			{
				GameObject tempDiamond = powerPool.getObject();
				tempDiamond.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + tempPillar.transform.lossyScale.y -4.5f, spawnPosition.z) ;
				tempDiamond.SetActive(true);
				//Debug.Log("Diamond Spawned at "+ tempDiamond.transform.position);
			}

			spawnPosition = new Vector3(spawnPosition.x, Random2.Range(-8, -3),
							spawnPosition.z + Random2.Range(minDistance, maxDistance));
			yield return new WaitForSeconds(3f);
		}
					
			
	}


	public void restart()
	{
		StopCoroutine(makingPillars());
		SceneManager.LoadScene("Main");
		
	}

	public void increaseDistance()
    {
		maxDistance += Random2.Range(0.08f, 0.3f) ; 
    }

}
