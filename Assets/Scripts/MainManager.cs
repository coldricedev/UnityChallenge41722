using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{


    public TMP_Text nameLabel;
 
    public TMP_Text bestLabel;


    string bestname = "ERROR";
    int bestScore = 0;


    public static string nameString = "ERROR";
    private static MainManager instance;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {

        LoadPlayerPrefs();

        UpdateNameLabel();
        UpdateBestLabel(bestname, bestScore);

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
              
               
            }
        }
    }

    void UpdateNameLabel()
    {
        nameLabel.text = nameString;
    }
    void UpdateBestLabel(string name, int best)
    {
        bestLabel.text = "BEST SCORE: " + name + ", " + best;
    }
   


    private void Update()
    {

        if  ( Input.GetKeyUp(KeyCode.Tab))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("deleted saved prefs");
        }

        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
   

    public static void AddAPoint(int point)
    {
        if (instance != null)
        {
            instance.AddPoint(point);
        }
    }
    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";



        if ( point > bestScore)
        {
            bestScore = point;
            bestname = nameString;
            UpdateBestLabel(bestname, bestScore);
            SavePlayerPrefs();
        }
    }

    public void LoadPlayerPrefs()
    {

        bestname = PlayerPrefs.GetString("bestname");
        if (bestname == null || bestname == "" || bestname == " ")
        {
            bestname = "NONE";
        }

        bestScore = PlayerPrefs.GetInt("bestscore");

    }
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("bestscore", bestScore);
        PlayerPrefs.SetString("bestname", bestname);
        PlayerPrefs.Save();
        Debug.Log("saved new high score!");
    }
    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
