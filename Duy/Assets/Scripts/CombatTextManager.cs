using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
    public GameObject textPrefab;
    //public RectTransform canvasTransform;
    public float speed;
    //public Vector3 direction;
    public float fadeTime;
    //singleton pattern
    private static CombatTextManager instance;
    public static CombatTextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }
    public void CreateText(Vector3 position,string text,Color color, RectTransform canvasTransform, Vector3 direction)
    {
        GameObject sct=(GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        //sct.GetComponent<RectTransform>().localWidth = .35f;
        //sct.GetComponent<RectTransform>().localHeight = .13f;
        sct.GetComponent<CombatText>().Initialize(speed, direction,fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;

    }
    /*public void CreateWaveText(Vector3 position, string text, Color color, RectTransform canvasTransform)
    {
        GameObject sct = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        sct.GetComponent<CombatText>().Initialize(speed, new Vector3(0f,0f,0f), fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
    }*/
}
