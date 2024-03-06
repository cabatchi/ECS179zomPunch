using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {

            // Reset Hearts if they are greater than max
            if (health > numOfHearts) 
            {
                health = numOfHearts;
            }

            // Render Hearts
            if (i < health) 
            {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
            
            // Display max hearts
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by the amount of damage taken
        health -= damage;

        // Ensure health doesn't go below 0
        health = Mathf.Max(health, 0);
    }
}
