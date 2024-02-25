using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    public float minVelocity = 7f;

    int lives = 5;
    int score = 0;

    Rigidbody2D rb;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    public GameObject homePanel;

    int brickCount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if(lives <= 0)
            {
                GameOver();
            } else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
        
        if(rb.velocity.magnitude < minVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, minVelocity);
        }
        Debug.Log(rb.velocity.magnitude);   

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("00000");
            brickCount--;
            if(brickCount <= 0)
            {
                gameWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }

    public void Home()
    {
        Time.timeScale = 0;
        homePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
    }
}
