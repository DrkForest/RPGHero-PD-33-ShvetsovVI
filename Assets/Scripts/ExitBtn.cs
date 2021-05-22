using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ExitBtn : MonoBehaviour
{

    public Action ExitBtnClicked = delegate { };

    public void OnMouseDown()
    {
        Debug.Log("exitBTN_click");
        ExitBtnClicked();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
