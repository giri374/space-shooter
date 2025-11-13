using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] states; // Array of shield states (0: full, 1: half, 2: empty)
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            health--;
            UpdateShieldState();
            Destroy(collision.gameObject); // Destroy the bullet on collision
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet on collision
        }
    }

    private void UpdateShieldState()
    {
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the shield when empty
        }
        else
        {
            spriteRenderer.sprite = states[health - 1]; // Update to the corresponding state
        }
    }

}
