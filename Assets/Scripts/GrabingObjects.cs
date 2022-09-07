using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabingObjects : MonoBehaviour
{
    bool inRange = false;

    GameObject pickableInRange;
    public Text tecla;

    [SerializeField] GameObject[] objetos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inRange)
        {
            pickableInRange.SetActive(false);

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
            
            
        }

        if (inRange)
        {
            tecla.text = "'Q' para interactuar";
        }
        else
        {
            tecla.text = "";
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
                pickableInRange = hit.collider.gameObject;
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            inRange = false;

        }
    }
}
