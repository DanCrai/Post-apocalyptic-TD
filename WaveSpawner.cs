using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemy;
    public Transform spawnPoint;

    public float timeBetweenWaves = 6f;
    public float timeBetweenEnemies = 0.8f;
    private float countdown = 2f;

    private int waveNumber = 1;


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {   
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        waveNumber++;
        //Debug.Log("Spawn wave succed");

    }

    void SpawnEnemy()
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    }

}
