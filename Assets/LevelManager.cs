using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript cs;
    float verticalDistance, horizontalDistance;

    float spawnTimer = 0;
    public float SpawnInterval = 5;

    public GameObject asteroidPrefab;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<CameraScript>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > SpawnInterval)
        {
            Vector3 spawnPosition = getRandomSpawnPosition();
            //Debug.Log("Kamulec na: " + spawnPosition.ToString());
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);


            spawnTimer = 0;
        }
    }

    Vector3 getRandomSpawnPosition()
    {
        verticalDistance = 0.55f * cs.gameHeight;
        horizontalDistance = 0.55f * cs.gameWidth;

        int randomSpawnLine = Random.Range(1, 5);
        Vector3 randomSpawnLocation = Vector3.zero;
        switch (randomSpawnLine)
        {
            case 1:
                //g�rna linia
                randomSpawnLocation = new Vector3(
                    Random.Range(-horizontalDistance, horizontalDistance), 0, verticalDistance);
                break;
            case 2:
                //prawa linia
                randomSpawnLocation = new Vector3(
                    horizontalDistance, 0, Random.Range(-verticalDistance, verticalDistance));
                break;
            case 3:
                //dolna linia
                randomSpawnLocation = new Vector3(
                    Random.Range(-horizontalDistance, horizontalDistance), 0, -verticalDistance);
                break;
            case 4:
                //lewa linia
                randomSpawnLocation = new Vector3(
                    -horizontalDistance, 0, Random.Range(-verticalDistance, verticalDistance));
                break;
        }
        return randomSpawnLocation;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
       gameOverScreen.SetActive(true);
    }
}
