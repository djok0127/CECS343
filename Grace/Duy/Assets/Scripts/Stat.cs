using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;
    [SerializeField]
    private Text statValue;
    //bar changing color
    [SerializeField] private Color fullColor;
    [SerializeField] private Color lowColor;
    private float currentFill;

    public float lerpSpeed;
    private float maxValue;
    private float currentValue;
    public float MyMaxValue { get; set; }
    
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value <= 0)
            {
                currentValue = 0;
            }
            else if(value>MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue;
            statValue.text = currentValue + "/" + MyMaxValue;
        }
    }
    void Start()
    {
        content = GetComponent<Image>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
        content.color = Color.Lerp(lowColor, fullColor,currentFill);
        //content.fillAmount = currentFill;
    }
    public void Initialize(float currentValue,float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
