using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Image healthBackGround;
    private Image healthBar;
    private Text bossName;

    private float timeTester = 5f;
    private float count = 0f;
    void Start()
    {
        //This to make UI for boss appeared by adjusting alpha value in color
        healthBackGround=GameObject.FindGameObjectWithTag("BossHealthBackGround").GetComponent<Image>();
        healthBar= GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Image>();
        bossName= GameObject.FindGameObjectWithTag("BossName").GetComponent<Text>();
        
        healthBackGround.color = new Color(healthBackGround.color.r, healthBackGround.color.g, healthBackGround.color.b, 255f);
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 255f);
        bossName.color = new Color(bossName.color.r, bossName.color.g, bossName.color.b,255f);
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > timeTester)
        {
            RemoveUI();
            Destroy(gameObject);
        }
    }
    //When boss died this need to be called to adjusting alpha value in color
    void RemoveUI()
    {
        healthBackGround.color = new Color(healthBackGround.color.r, healthBackGround.color.g, healthBackGround.color.b, 0f);
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 0f);
        bossName.color = new Color(bossName.color.r, bossName.color.g, bossName.color.b, 0f);
    }
}
