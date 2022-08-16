using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text saveText;
    public Color color;
    private void Start()
    {
        //color = saveText.GetComponent<Color>();
    }
    void Update()
    {
        StartCoroutine(AutoSave());   
    }



    IEnumerator AutoSave() 
    {
        yield return new WaitForSeconds(3f);
        //FurnitureManager.Instance.Save();


        color.r = Mathf.Lerp(0,255,2f);
       //. Color.Lerp(saveText.color.r, saveText.color, color.r);
        saveText.color = color;

        //saveText.SetActive(true);
    }
}
