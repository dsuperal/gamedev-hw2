using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    public TMP_Text scoreText;    // assign Score Text UI
    public GameObject basketParent;    // assign BasketParent object
    public GameObject gameOverPanel;   // assign GameOver Panel

    private int score = 0;
    private int lives = 3;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateScore();
    }

    public void CatchApple()
    {
        score++;
        UpdateScore();

        // Increase difficulty every 5 apples
        if (score % 2 == 0)
        {
            var tree = FindObjectOfType<TreeObjectHierarchy>();
            if (tree != null)
            {
                tree.IncreaseDifficulty();
            }
        }
    }

    public void MissApple()
    {
        lives--;
        if (lives >= 0 && basketParent.transform.childCount > 0)
        {
            Destroy(basketParent.transform.GetChild(0).gameObject);
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("HighScore", Mathf.Max(score, PlayerPrefs.GetInt("HighScore", 0)));
    }


   public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    

}
