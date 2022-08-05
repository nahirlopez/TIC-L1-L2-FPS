using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrito : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        cerca = false;
    }
    public GameObject compu;
    bool cerca;
    public Text tecla;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && cerca)
        {
           GameObject clon = Instantiate(compu);
            clon.transform.position = spawnPoint.position;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "carrito")
        {
            cerca = true;
            tecla.text = "YA ESTA LO SUFICIENTEMENTE CERCA, PRESIONE N PARA CLONAR NETS ";
        }

        if (col.gameObject.tag != "carrito")
        {
            cerca = false;
        }
    }

}
