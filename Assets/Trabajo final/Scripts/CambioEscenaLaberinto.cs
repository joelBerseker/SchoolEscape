﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEscenaLaberinto : MonoBehaviour
{

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CambioEscenaLaberinto"))
        {           
            SceneManager.LoadScene("Laberinto");
        }
           
    }
}
