using UnityEngine;

public class DetectCollision : MonoBehaviour
{
  public AudioClip hitSound;
  public GameObject hitParticlePrefab;

  void OnTriggerEnter(Collider other)
  {
    AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
    if(hitParticlePrefab != null)
    {
      GameObject particleInstance = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
      Destroy(particleInstance, 2.0f);
    }
    Destroy(gameObject);
    Destroy(other.gameObject);
  }
}
