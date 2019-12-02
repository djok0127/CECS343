using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    protected Image healthBackGround;
    protected Image healthBar;
    protected Text bossText;
   
    
    //tracking boss hp and defense
   
    public float defense;
    public RectTransform canvasTransform;

    //boss icon
    //spawn icon
    public GameObject icon;
    protected GameObject sct;
    //xPosition= 376.5
    //yPosition= 147.5

    //boss death effect
    
    //dialogue fade out timer
    private float fadeTime;
    
    public void Initialize()
    {
        //This to make UI for boss appeared by adjusting alpha value in color
        healthBackGround=GameObject.FindGameObjectWithTag("BossHealthBackGround").GetComponent<Image>();
        healthBar= GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Image>();
        bossText= GameObject.FindGameObjectWithTag("bossText").GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();


        healthBackGround.color = new Color(healthBackGround.color.r, healthBackGround.color.g, healthBackGround.color.b, 255f);
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 255f);

        //intialize boss health
        
        currentHealth = maxHealth;

        //boss icon set up
        RectTransform rt = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>();
        sct = (GameObject)Instantiate(icon, new Vector3(376.5f,147.5f,0f), Quaternion.identity);
        sct.transform.SetParent(rt,false);
        
    }

    // Update is called once per frame
    
    
    //When boss wants to say something
    public void Say(string what,float fadeTime)
    {
        bossText.text = what;
        this.fadeTime = fadeTime;
        //bossText.color = new Color(bossText.color.r, bossText.color.g, bossText.color.b, 255f);
        StartCoroutine(FadeOut());

    }
    
    //When boss died this need to be called to adjusting alpha value in color
    public void RemoveUI()
    {
        healthBackGround.color = new Color(healthBackGround.color.r, healthBackGround.color.g, healthBackGround.color.b, 0f);
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 0f);
        bossText.text = "";
        Destroy(sct);
    }
    private IEnumerator FadeOut()
    {
        bossText.color = new Color(bossText.color.r, bossText.color.g, bossText.color.b, 1);
        while (bossText.color.a > 0.0f)
        {
            bossText.color = new Color(bossText.color.r, bossText.color.g, bossText.color.b, bossText.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }
    //i need to access this in specific boss script
    public float getCurrentHealth()
    {
        return currentHealth;
    }
}
