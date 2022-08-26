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
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave() 
    {
        var wait = new WaitForSeconds(10f);
        var inwait = new WaitForSeconds(3f);
        while(true)
        {
            yield return inwait;
            StartCoroutine(FadeOut(1f));
            //Save
            yield return inwait;
            StartCoroutine(FadeIn(1f));

            yield return wait;
        }
        
    }

    public IEnumerator FadeIn(float time)
    {
        Color color = saveText.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            saveText.color = color;
            yield return null;
            

        }
        FurnitureManager.Instance.Save();
    }

    public IEnumerator FadeOut(float time)
    {
        Color color = saveText.color;
        while (color.a < 1f)
        {
            //StartCoroutine(FadeIn(5f));
            color.a += Time.deltaTime / time;
            saveText.color = color;
            yield return null;
            
        }
    }
}
