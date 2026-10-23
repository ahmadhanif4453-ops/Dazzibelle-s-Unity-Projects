using UnityEngine;

public class DetectCollision : MonoBehaviour
{
  public AudioClip hitSound;
  public GameObject hitParticlePrefab;
  private GameManajer gameManager;

  void Start()
  {
    gameManager = GameObject.Find("GameManajer").GetComponent<GameManajer>();
  }
  void OnTriggerEnter(Collider other)
  {
    
    if(other.CompareTag("Player"))
    {
      gameManager.AddLives(-1);
      Destroy(gameObject);
    }
    else if (other.CompareTag("Projectile"))
    {
      Destroy(other.gameObject);
      AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
    if(hitParticlePrefab != null)
    {
      GameObject particleInstance = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
      Destroy(particleInstance, 2.0f);
    }
      AnimalHunger animalHunger = GetComponent<AnimalHunger>();
      if (animalHunger != null)
      {
        animalHunger.FeedAnimal(1);
      }
    }
    
  }
}
