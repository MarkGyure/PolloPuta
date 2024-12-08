using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int totalEnemies; 
    public int totalBirds;   

    private int remainingEnemies;
    private int remainingBirds;

    void Start()
    {
        remainingEnemies = totalEnemies;
        remainingBirds = totalBirds;
    }

    public void OnEnemyKilled()
    {
        if (remainingEnemies > 0)
        {
            remainingEnemies--;
            Debug.Log($"Enemy killed! Remaining enemies: {remainingEnemies}");

            if (remainingEnemies == 0 && remainingBirds > 0)
            {
                Debug.Log("Player wins! All enemies are dead.");
            }
        }
    }
    public void OnBirdUsed()
    {
        if (remainingBirds > 0)
        {
            remainingBirds--;
            Debug.Log($"Bird used! Remaining birds: {remainingBirds}");

            if (remainingBirds == 0 && remainingEnemies > 0)
            {
                Debug.Log("Level lost! No birds left, but enemies are still alive.");
            }
        }
    }

    void Update()
    {
        if (remainingEnemies == 0 && remainingBirds > 0)
        {
            Debug.Log("You still have birds left but all enemies are defeated.");
        }
        else if (remainingEnemies > 0 && remainingBirds == 0)
        {
            Debug.Log("You have no birds left, but there are still enemies.");
        }
    }
}
