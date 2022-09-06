using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENCONTRAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject lista;
    bool inv = true;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lista.SetActive(inv);
            inv = !inv;
        }

    }


}
