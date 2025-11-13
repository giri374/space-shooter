using UnityEngine;

public class Mothership : MonoBehaviour
{
    public int scoreValue = 500;
    public float speed = 5f;
    private const float MAX_LEFT = -3.5f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= MAX_LEFT)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // // Handle collision with player or bullets
        // if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        // {
        //     if (other.CompareTag("Player"))
        //     {
        //         // Assuming Player has a method to increase score
        //         other.GetComponent<Player>().IncreaseScore(scoreValue);
        //         Destroy(gameObject);
        //     }
        //     else if (other.CompareTag("Bullet"))
        //     {
        //         Destroy(other.gameObject); // Destroy the bullet
        //         Destroy(gameObject); // Destroy the mothership
        //     }
        // }
    }
}
