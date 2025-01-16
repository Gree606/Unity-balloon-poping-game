using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalloomController : MonoBehaviour
{
    public float upSpeed;
    int score;
    AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    public RawImage startImage;
    private bool isGameStarted = false;
    private float speedIncreaseRate = 0.001f;

    private void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        if(!isGameStarted &&(Input.GetMouseButtonDown(0) || Input.touchCount >0))
        {
            isGameStarted=true;
            if(startImage!=null){
                startImage.gameObject.SetActive(false);
            }
            scoreText.gameObject.SetActive(true);
        }
        if(isGameStarted){
            if(transform.position.y >6.2f){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate(){
        if(isGameStarted){
            upSpeed += speedIncreaseRate * Time.fixedDeltaTime;
            transform.Translate(0, upSpeed, 0);
        }
    }

    private void OnMouseDown(){
        if(isGameStarted){
            score++;
            scoreText.text=score.ToString();
            audioSource.Play();
            resetPosition();
        }
    }

    public void resetPosition(){
        float randomX = Random.Range(-2f, 2f);
        transform.position = new Vector2(randomX, -7f);
    }
}
