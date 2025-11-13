using UnityEngine;
[System.Serializable]

public class ShipStats
{
    [Range(1, 5)]
    public int maxHealth;
    // [HideInInspector]
    public int currentHealth;
    // [HideInInspector]
    public int maxLives=3;
    // [HideInInspector]
    public int currentLives;

    public float shipSpeed=3f;
    public float fireRate=0.5f; // Time between shots in seconds
}
