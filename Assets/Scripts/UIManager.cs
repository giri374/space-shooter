using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI highScoreText;
    public int highScore;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI waveText;
    public int wave;

    public Image[] lifeSprites;
    public Image healthBar;

    public Sprite[] healthBars;

    private Color32 activeColor = new Color32(255, 255, 255, 255);
    private Color32 inactiveColor = new Color32(255, 255, 255, 100);
    private static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateLives(int l)
    {
        foreach (Image i in instance.lifeSprites)
            i.color = inactiveColor;
        for (int i = 0; i < l; i++)
        {
                instance.lifeSprites[i].color = activeColor;
        }
    }
    public void UpdateHealthbar(int h)
    {
        instance.healthBar.sprite = instance.healthBars[h];
    }

    public void UpdateScore(int s)
    {

    }
    public void UpdateHighscore(int h)
    {

    }
    public void UpdateCoins(int c)
    {

    }
    public void UpdateWave(int w)
    {

     }
}
