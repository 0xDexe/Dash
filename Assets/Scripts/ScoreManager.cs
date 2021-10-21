using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ScoreManager : MonoBehaviour
{
    public int score, jumps;

    public AudioSource audioData;
    bool isPlaying;
    public GameObject cube;
    Rigidbody rb;
    bool gameOver;
    

    //UI 
    public GameObject losePanel;

	public Text scoreText, finalScoreText, bestScoreText;
     

    // Start is called before the first frame update
    void Start()
    {
        rb = cube.GetComponent<Rigidbody>();  
        score = 0;
        jumps = 0;
        gameOver = false;
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        isPlaying = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            ChangeState(); 
        }
        
    }

    void FixedUpdate()
    {
        if (cube.transform.position.y < -13 && !gameOver)
        {
            gameOver = true;
            Camera.main.gameObject.GetComponent<CameraBehaviour>().gameOver = true;
            StartCoroutine(loseGame());
        }
    }

    IEnumerator loseGame()
    {
        
        cube.GetComponent<CubeBehaviour>().loseGame = true;
        if (score > PlayerPrefs.GetInt("bestScore", 0)) PlayerPrefs.SetInt("bestScore", score);
        losePanel.SetActive(true);
        finalScoreText.GetComponent<Text>().text = "" + score;
        bestScoreText.GetComponent<Text>().text = "Best score:" + PlayerPrefs.GetInt("bestScore", 0);
       
        yield return new WaitForSeconds(.5f);
    }


    public void JumpsUp()
    {
        jumps++;         
       
    }


    public void PowerUp()
    {
        score++;
        scoreText.GetComponent<Text>().text = "score: " + score;
        Debug.Log("Score:man increase");
    }

    public void reset()
    {
        jumps = 0;
        score = 0; 
    }


    public void ChangeState()
    {

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        if (isPlaying)
        {
            audioData.Stop();
            isPlaying = false;
        }
        else
        {
            audioData.Play();
            isPlaying = true; 
        }

        rb.constraints = RigidbodyConstraints.None; 
    }
}
