using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int totalEnemies; 
    public int totalBirds;   

    private int remainingEnemies;
    private int remainingBirds;

    [SerializeField] private float secondsToWaitBeforeDeathCheck = 5f;
    void Start()
    {
        remainingEnemies = totalEnemies;
        remainingBirds = totalBirds;
    }

    void Update()
    {
        if (remainingEnemies == 0 && remainingBirds > 0)
        {
            //Debug.Log("You still have birds left but all enemies are defeated.");
        }
        else if (remainingEnemies > 0 && remainingBirds == 0)
        {
            //Debug.Log("You have no birds left, but there are still enemies.");
        }
    }

    public void OnEnemyKilled()
    { 

        if (remainingEnemies > 0)
        {
            remainingEnemies--;
        }

        checkIfAllEnemiesDead();

        Debug.Log("Enemy killed, remaining enemies = " + remainingEnemies);
    }
    public void OnBirdUsed()
    {
        if (remainingBirds > 0)
        {
            remainingBirds--;
        }

        CheckIfLastBird();
    }

    public void CheckIfLastBird()
    {
        if(remainingBirds == 0)
        {
            StartCoroutine(CheckAfterWaitTime());
        }
    }

    private IEnumerator CheckAfterWaitTime()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeDeathCheck);

        if(remainingEnemies == 0)
        {
            WinGame();
        }

        else
        {
            LoseGame();
        }
    }

    private void checkIfAllEnemiesDead()
    {
        if (remainingEnemies == 0)
        {
            WinGame();
        }
    }
    
    private void WinGame()
    {
        Debug.Log("You won!");
    }

    private void LoseGame()
    {
        Debug.Log("You lost...");
    }
}
