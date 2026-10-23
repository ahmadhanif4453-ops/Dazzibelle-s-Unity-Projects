using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int capacity;
    private int currentFedAmount = 0;
    private GameManajer gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManajer").GetComponent<GameManajer>();
        hungerSlider.maxValue = capacity;
        hungerSlider.value = capacity;
    }

    // Update is called once per frame
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.value = capacity - currentFedAmount;
        if (currentFedAmount >= capacity)
        {
            gameManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
