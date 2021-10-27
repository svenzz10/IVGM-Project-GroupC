using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StartMessage : MonoBehaviour
{

    public GameObject UIStart;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIStart.active == true && Input.GetKeyDown(KeyCode.E))
            UIStart.SetActive(false);
    }
}
