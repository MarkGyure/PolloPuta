using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int totalEnemies; 
    public int totalBirds;   

    private int remainingEnemies;
    private int remainingBirds;

    [SerializeField] private float secondsToWaitBeforeDeathCheck = 5f;

    public Canvas winCanvas;
    public Canvas loseCanvas;

    private void Awake()
    {
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
    }

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

        Debug.Log(remainingEnemies);

        if (remainingEnemies > 0)
        {
            LoseGame();
        }
        else
        {
            WinGame();
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
        winCanvas.gameObject.SetActive(true);
        //Debug.Log("You won!");
    }

    private void LoseGame()
    {
        loseCanvas.gameObject.SetActive(true);
        //Debug.Log("You lost...");
    }
}
