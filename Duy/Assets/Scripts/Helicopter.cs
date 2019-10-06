using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{
    public Transform dropPoint;
    public float speed = 20f;
    public GameObject bombPrefab;
    public GameObject policePrefab;
    public GameObject textPrefab;
    private Enemy enemy;
    public RectTransform canvasTransform;
    public float bonusHealth=10f;
    public float bonusDamage = 1f;
    public float dropInterval=1f;
    public float deathTime = 30f;
    private float counter1=0f;
    private float timer = 0f;
    private int waveCount = 1;
    private Rigidbody2D rb;
    private int number;
    private Transform player;
    [SerializeField] private Text waveText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        enemy = policePrefab.GetComponent<Enemy>();
        enemy.maxHealth = 10f;
        enemy.damageDealt = 1f;
        //rb.velocity = transform.right * speed;
        Random.seed = (int)System.DateTime.Now.Ticks;
        number = Random.Range(1, 101);
        waveText.text="Wave: "+ waveCount.ToString();
        //textPrefab.GetComponent<Text>().text="Wave "+waveCount.ToString();
        //GameObject sct = (GameObject)Instantiate(textPrefab, new Vector3(player.position.x-120f, player.position.y + 325f, 0f), Quaternion.identity);
        //sct.transform.SetParent(canvasTransform);
        //CombatTextManager.Instance.CreateText(new Vector3(player.position.x,player.position.y+25f,0f), "Wave "+waveCount.ToString(), Color.red, canvasTransform, new Vector3(0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            waveCount++;
            waveText.text = "Wave: " + waveCount.ToString();
            //textPrefab.GetComponent<Text>().text = "Wave " + waveCount.ToString();
            //GameObject sct = (GameObject)Instantiate(textPrefab, new Vector3(player.position.x - 120f, player.position.y + 325f, 0f), Quaternion.identity);
            //sct.transform.SetParent(canvasTransform);
            //CombatTextManager.Instance.CreateText(new Vector3(player.position.x, player.position.y + 25f, 0f), "Wave " + waveCount.ToString(), Color.red, canvasTransform, new Vector3(0f, 0f, 0f));
            enemy.maxHealth += bonusHealth;
            enemy.damageDealt += bonusDamage;
            //bonusStat += 10f;
            timer = 0f;
        }
        counter1 += Time.deltaTime;
        
        if (counter1 >= dropInterval)
        {

            //suppose to be 30% that police will drop

            DropPolice();
            counter1 = 0f;
        }
        
    }
    void DropBomb()
    {
        Instantiate(bombPrefab, dropPoint.position, dropPoint.rotation);
    }
    void DropPolice()
    {
        
        Instantiate(policePrefab, dropPoint.position, policePrefab.GetComponent<Transform>().rotation);
    }
}
