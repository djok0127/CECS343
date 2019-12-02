using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject eneryBallPrefab;
    public GameObject fireBallPrefab;
    public GameObject helicopterPrefab;
    public GameObject vortexPrefab;
    public GameObject bulletPrefab;

    public float fireInterval = 5f;
    public float yDistanceFromPlayer=100f;
    public float xDistanceFromPlayer = 100f;
    
    private float counter = 0f;
    private Transform target;
    private int number;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        counter += Time.deltaTime;
        if (counter>=fireInterval)
        {

            
            Random.seed = (int)System.DateTime.Now.Ticks;
            number = Random.Range(1, 101);
            Debug.Log(number);
            if (number <=30 )
            {
                FireBullet();
            }
            else if (number <=50)
            {
                FlameWall();
            }
            
            else if (number <= 70)
            {
                EnergyBall();
                
            }
            else if (number <= 90)
            {
                SummonVortex();
            }
            else
            {
                SummonHelicopter();
            }
            
            
            counter = 0f;

        }

    }
    
    void EnergyBall()
    {
        Instantiate(eneryBallPrefab, firePoint.position, firePoint.rotation);
    }
    void FlameWall()
    {
        Instantiate(fireBallPrefab, new Vector2(target.position.x+5f,target.position.y), target.rotation);
    }
    void SummonHelicopter()
    {
        Instantiate(helicopterPrefab, new Vector2(target.position.x - xDistanceFromPlayer, 
            target.position.y+yDistanceFromPlayer), Quaternion.identity);
    }
    void SummonVortex()
    {
        Instantiate(vortexPrefab, target.position, target.rotation);
    }
    void FireBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
