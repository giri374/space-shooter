using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ShipStats shipStats;

    private Vector3 offScreenPosition = new Vector3(0, -10f, 0);
    private Vector3 startPosition = new Vector3(0, -4.2f, 0);

    private const float MAX_LEFT = -2.3f;
    private const float MAX_RIGHT = 2.3f;
    // Update is called once per frame

    private bool isShooting = false;

    private void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;
        transform.position = startPosition;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > MAX_LEFT)
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < MAX_RIGHT)
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }
#endif

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * shipStats.shipSpeed);
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * shipStats.shipSpeed);
    }

    public IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }
    public IEnumerator Respawn()
    {
        transform.position = offScreenPosition;
        yield return new WaitForSeconds(2f);
        shipStats.currentHealth = shipStats.maxHealth;
        transform.position = startPosition;
        Debug.Log("Player respawned!");
    }
    public void TakeDamage()
    {
        Debug.Log("Player took damage!");
        shipStats.currentHealth--;
        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;
            if (shipStats.currentLives <= 0)
            {
                Debug.Log("Game Over!");
                // Handle game over logic here, e.g., reload the scene or show a game over screen
            }
            else
            {
                StartCoroutine(Respawn());
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            TakeDamage();
            Debug.Log("Hit by alien!");
            Destroy(collision.gameObject);
        }
    }
}