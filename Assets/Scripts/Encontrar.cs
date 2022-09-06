using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encontrar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool inv = true;
    public GameObject listado;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            listado.SetActive(inv);
            inv = !inv;
        }
    }
}
