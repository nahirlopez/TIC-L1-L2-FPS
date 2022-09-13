using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabingObjects : MonoBehaviour
{
    bool inRange = false;

    public GameObject pickableInRange;
    public Text tecla;
    bool canopen = false;
    int contador = 0;
    bool EXIT;
    bool isopen;

    public GameObject[] objetos;
    public GameObject netbook;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 5)
        {
            EXIT = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && inRange)
        {
           
               pickableInRange.SetActive(false);
                

            pickable pickablescript = pickableInRange.GetComponent<pickable>();

            if (pickablescript)
            {
                pickablescript.tick.SetActive(true);
                    Debug.Log("activado");
            }
            contador++;

            int i = 0;
            while (i < objetos.Length)
            {
                if (objetos[i] == null)

                {
                    objetos[i] = pickableInRange;
                    break;

                }

                else

                {
                    i++;

                }

            }
           

            for (int e = 0; e < objetos.Length; e++)
            {
                if (objetos[e] && objetos[e].name == "llave")
                {
                    canopen = true;
                    break;
                }

            }
                pickableInRange = null;
            inRange = false;
           

            
        }

        if (Input.GetKeyDown(KeyCode.R) && canopen)
        {
            if (isopen && (Input.GetKeyDown(KeyCode.R) && canopen))
            {
                netbook.SetActive(true);
                canopen = false;
                
                pickableInRange = null;
            }
        }




            if (Input.GetKeyDown(KeyCode.R) && EXIT && pickableInRange)
        {
           pickableInRange.SetActive(false);
            contador = 0;
            pickableInRange = null;
        }
        
       

        if (pickableInRange )
        {
            tecla.text = "'R' para interactuar";
        }
        


    }

    void FixedUpdate()
    {
        RaycastHit hit;
        //   // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.gameObject.CompareTag("pickable"))
            {
                inRange = true;
                isopen = false;
                pickableInRange = hit.collider.gameObject;
            }
            if (hit.collider.gameObject.CompareTag("open") )
            {

                isopen = true;
                inRange = false;
                pickableInRange = hit.collider.gameObject;

            }
            if (hit.collider.gameObject.CompareTag("exit") )
            {
                inRange = false;
                isopen = false;
                pickableInRange = hit.collider.gameObject;

            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            inRange = false;
            pickableInRange = null;
            tecla.text = "";
        }
    }
}
