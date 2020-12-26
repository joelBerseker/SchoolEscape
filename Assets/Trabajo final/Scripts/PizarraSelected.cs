using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizarraSelected : MonoBehaviour
{
    public Text respuesta;
    public GameObject cuadroRespuesta;
    private int res;
    private float tiempo;

    public GameObject itemHealth;
    public GameObject itemKey;


    private Transform playerPos;
    private GameObject pizarra;
    private bool keyDrop;

    private void Start()
    {
        keyDrop = false;
        pizarra = GameObject.FindGameObjectWithTag("Pizarra");
        res = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>().res;
        tiempo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>().tiempo;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        res = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>().res;
        tiempo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>().tiempo;
        if (tiempo <= 0)
        {
            cuadroRespuesta.gameObject.SetActive(true);
            respuesta.text = "Se acabo el tiempo \n La respuesta era: " + res;
            pizarra.SetActive(false);

        }
    }


        public void isCorrect()
    {
        res = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>().res;
        
        string num = transform.GetChild(0).gameObject.GetComponent<Text>().text;
        int numE;
        int.TryParse(num, out numE);
        cuadroRespuesta.gameObject.SetActive(true);
        if (res == numE)
        {
            respuesta.text="Respuesta Correcta";
            Instantiate(itemHealth, playerPos.position, Quaternion.identity);
            if (!keyDrop)
            {
                int number1 = Random.Range(1, 101);
                if (number1 >= 50)
                {
                    Instantiate(itemKey, playerPos.position, Quaternion.identity);
                    keyDrop = false;
                }
            }

        }
        else
        {
            respuesta.text = "Error \n La respuesta era: " +res;
        }
        StartCoroutine(espera());
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1f);

        pizarra.SetActive(false);
    }
}
