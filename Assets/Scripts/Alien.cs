using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue = 10;
    public GameObject explosionPrefab;

    public void Killed()
    {
        AlienMaster.allAliens.Remove(gameObject);
        // Optionally, you can instantiate an explosion effect here

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
