using UnityEngine;
using TMPro;
public class GameManajer : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int missCount = 0;
    public TextMeshProUGUI missText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Nyawa = " + lives);
        Debug.Log("Skor = " + score);
    }

   
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }
    
    void UpdateScoreUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void AddMiss()
    {
        missCount += 1;
        UpdateMissUI();
    }

    void UpdateMissUI()
    {
        if(missText != null)
        {
            missText.text = "Miss: " + missCount;
        }
    }
    public void AddLives(int value)
    {
        lives += value;
        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            lives = 0;
        }
        else
        {
            Debug.Log("Nyawa = " + lives);
        }
    }
}
