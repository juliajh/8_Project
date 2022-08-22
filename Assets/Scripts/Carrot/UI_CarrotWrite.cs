using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CarrotWrite : MonoBehaviour
{
    private void Awake()
    {

        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
