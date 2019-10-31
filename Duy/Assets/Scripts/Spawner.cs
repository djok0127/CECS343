using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    //spawn interval, wavecounter
    public float spawnInterval = 2f;
    public float waveInterval = 60f;
    public float statBonus = 10f;
    private float waveTimer = 0f;
    private float iSpawnCounter = 0f;
    private float spawnTimer = 0f;
    public int maxEnemy;
    private int enemyCounter = 0;
    //wave control
    [SerializeField] private Text waveText;
    private int waveCount = 1;
    public int bossWave;
    private bool isBossWave=false;
    //enemy spawn point
    public Transform point1;
    public Transform point2;
    //item spawn point
    public Transform point3;
    //normal enemy game object to spawn
    public GameObject policePrefab;

    //boss enemy game object to spawn
    public GameObject bossPrefab;

    //item to spawn
    public GameObject cherryPrefab;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        waveText.text = "Wave: " + waveCount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBossWave)
        {
            waveTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            if (waveTimer > waveInterval)
            {
                waveCount++;
                
                waveText.text = "Wave: " + waveCount.ToString();
                
                //boss wave
                if (waveCount % bossWave == 0)
                {
                    isBossWave = true;
                    waveText.text = "Wave: Boss";
                    Instantiate(bossPrefab, transform.position, transform.rotation);
                }
                waveTimer = 0f;
            }
            if (enemyCounter < maxEnemy)//spawn if enemy count is less
            {
                if (spawnTimer > spawnInterval)
                {
                    Instantiate(policePrefab, point1.position, point1.rotation);
                    Instantiate(policePrefab, point2.position, point2.rotation);
                    enemyCounter += 2;
                    spawnTimer = 0f;
                }
            }
        }
        iSpawnCounter += Time.deltaTime;
        if (iSpawnCounter > spawnTimer)
        {
            Instantiate(cherryPrefab, point3.position, point3.rotation);
            iSpawnCounter = 0f;
         
        }
     
    }
    public void ReduceEnemyCount()
    {
        enemyCounter--;
    }
    public void isDead()
    {
        waveText.text = "Wave: " + waveCount.ToString();
        isBossWave = false;
    }
}
