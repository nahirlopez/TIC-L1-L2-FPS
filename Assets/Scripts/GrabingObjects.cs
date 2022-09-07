﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabingObjects : MonoBehaviour
{
    bool inRange = false;

    GameObject pickableInRange;
    public Text tecla;
    bool canopen = false;

    [SerializeField] GameObject[] objetos;
    public GameObject netbook;

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

            for(int e = 0; e <objetos.Length; e++)
            {
                if (objetos[e].name == "llave")
                {
                    canopen = true;
                    break;
                }
                
            }
            
            
        }
        

        if (Input.GetKeyDown(KeyCode.Q) && inRange && canopen)
        {
            netbook.SetActive(true);
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
            if (hit.collider.gameObject.CompareTag("open"))
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
