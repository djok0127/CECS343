using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatEnemy : MonoBehaviour
{
    private Image content;
    
    private float currentFill;
    [SerializeField] private Color fullColor;
    [SerializeField] private Color lowColor;
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
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue;
            
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
        content.color = Color.Lerp(lowColor, fullColor, currentFill);
        //content.fillAmount = currentFill;
    }
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
