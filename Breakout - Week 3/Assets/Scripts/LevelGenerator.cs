using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{

    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public Gradient gradient;

    private void Awake()
    {
        for (int i=0;i < size.x; i++)
        {
            for (int j=0;j<size.y;j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                Vector3 v = new Vector3((float)((size.x - 1) * 0.5f - i) * offset.x, j * offset.y, 0f);
                newBrick.transform.position = transform.position + v;
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
            }
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("HomeScence");
    }
}
