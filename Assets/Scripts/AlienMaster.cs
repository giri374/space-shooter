using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject motherShipPrefab;

    public Vector3 hMoveDistance = new Vector3(0.1f, 0, 0);
    public Vector3 vMoveDistance = new Vector3(0, -0.1f, 0);
    public Vector3 motherShipPosition = new Vector3(3.5f, 3.75f, 0);

    private const float MAX_LEFT = -3.15f;
    private const float MAX_RIGHT = 3.15f;
    private const float MAX_SPEED_TIMER = 0.02f;

    private float moveTimer = 0.01f;
    public float moveTime = 0.005f;

    private float shootTimer = 3f;
    public float shootTime = 3f;

    public float motherShipTimer = 15f;
    private const float MOTHERSHIP_MIN = 15F;
    private const float MOTHERSHIP_MAX = 60F;

    private bool movingRight = true;

    public static List<GameObject> allAliens = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject alien in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(alien);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();
        }

        if (shootTimer <= 0)
        {
            Shoot();
        }
        
        if (motherShipTimer <= 0)
        {
            SpawnMotherShip();
        }

        shootTimer -= Time.deltaTime;
        moveTimer -= Time.deltaTime;
        motherShipTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        if (allAliens.Count > 0)
        {
            int hitMax = 0;

            foreach (GameObject alien in allAliens)
            {
                if (movingRight)
                {
                    alien.transform.Translate(hMoveDistance);
                }
                else
                {
                    alien.transform.Translate(-hMoveDistance);
                }
                if (alien.transform.position.x > MAX_RIGHT || alien.transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }
            if (hitMax > 0)
            {

                for (int i = 0; i < allAliens.Count; i++) // foreach and for loop are interchangeable here
                {
                    allAliens[i].transform.Translate(vMoveDistance);
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    public void Shoot()
    {

        Vector2 spawnPosition = allAliens[Random.Range(0, allAliens.Count)].transform.position;
        Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        shootTimer = shootTime;
    }

    public void SpawnMotherShip()
    {

        Instantiate(motherShipPrefab, motherShipPosition, Quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f < MAX_SPEED_TIMER)
            return MAX_SPEED_TIMER;
        else
            return f;
    }
}
