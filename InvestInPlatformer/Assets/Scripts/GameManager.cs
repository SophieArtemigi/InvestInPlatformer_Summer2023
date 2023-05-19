using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab, monsterPrefab, gameOverScreen;

    int platformCount = 50;
    float highestPos = 0f;
    Vector3 spawnPosition;
    float screenX;

    [SerializeField] TextMeshProUGUI scoreTxt;
    int newScore;

    [SerializeField] PlayerController pc;
    [SerializeField] CameraFollow camFollows;

    bool monsterCoroutine = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();
        screenX = Screen.width;



        for (int i = 0; i < platformCount; i++)
        {
            

            spawnPosition.y += Random.Range(0.5f, 2f);
            spawnPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(screenX * Random.Range(0.1f, 0.9f), 0, 0)).x; // finds a point somewhere between the first and last tenth of the screen's width

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            if (i == platformCount - 1) highestPos = spawnPosition.y;

        }
        StartCoroutine(SpawnMonster());
       // Debug.Log("Initial highest pos: " + highestPos);
    }

    
    private void Update()
    {
       if (!monsterCoroutine) StartCoroutine(SpawnMonster());
    } 

    IEnumerator SpawnMonster()
    {
        monsterCoroutine = true;
        yield return new WaitForSeconds(5f);

        Vector3 monsterPos = new Vector3(spawnPosition.x, highestPos, 0f);

        Instantiate(monsterPrefab, monsterPos, Quaternion.identity);

        monsterCoroutine = false;

    }

    public void MovePlatformsUp(GameObject platformToMove)
    {
       // Debug.Log("Highest pos: " + highestPos);
        spawnPosition.y = highestPos + Random.Range(0.5f, 2f);
        spawnPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(screenX * Random.Range(0.1f, 0.9f), 0, 0)).x; // finds a point somewhere between the first and last tenth of the screen's width

        highestPos = spawnPosition.y;

        platformToMove.transform.position = spawnPosition;
    }
    /*
    void ReplacePlatforms()
    {
        highestPos = -5f;

        for (int i = 0; i < platformCount; i++) // copies code from start()
        {


            spawnPosition.y += Random.Range(0.5f, 2f);
            spawnPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(screenX * Random.Range(0.1f, 0.9f), 0, 0)).x; 

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            if (i == platformCount - 1) highestPos = spawnPosition.y;

        }

    } */

    public void ScoreManager(int score)
    {
        newScore += score;
        scoreTxt.text = "Score: " +newScore.ToString();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }


  
}
