using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pizzarra : MonoBehaviour
{
    //(inventory.slots[i].transform.childCount > 0) { 
    //GameObject child = inventory.slots[i].transform.GetChild(0).gameObject;

    public Text number01;
    public Text signo;
    public Text number02;

    public int res;
    
    public Text[] options;

    public Text contador;
    public float tiempo = 10f;

    public GameObject cuadroRespuesta;


    void Start()
    {
        Generated();
        contador.text = " " + tiempo;
    }
    public void Generated()
    {
        cuadroRespuesta.gameObject.SetActive(false);
        tiempo = 10f;
        int signoT    = Random.Range(0, 4);
        int number1   = Random.Range(1, 20);
        number01.text = number1.ToString();
        int number2   = Random.Range(1, 20);
        number02.text = number2.ToString();
        int tem = Random.Range(0, 4);
        Debug.Log(tem);
        if (signoT == 0)
        {
            signo.text = "+";
            res = number1 + number2;
            Debug.Log("Respuesta " + res);
            for (int i = 0; i < options.Length; i++)
            {
                options[i].text = (res + Random.Range(0, 11) - 5).ToString();
            }
        }
        else
        {
            if (signoT == 1)
            {
                signo.text = "-";
                res = number1 - number2;
                Debug.Log("Respuesta " + res);

                for (int i = 0; i < options.Length; i++)
                {   
                    options[i].text = (res + Random.Range(0, 5) - 2).ToString();
                }
            }
            else
            {
                if (signoT == 2)
                {
                    signo.text = "x";
                    res = number1 * number2;
                    Debug.Log("Respuesta " + res);

                    for (int i = 0; i < options.Length; i++)
                    {
                        options[i].text = (res + Random.Range(0, 5) - 2).ToString();
                    }
                }
                else
                {
                    signo.text = "/";
                    res = number1 / number2;
                    Debug.Log("Respuesta " + res);

                    for (int i = 0; i < options.Length; i++)
                    {
                        options[i].text = (res + Random.Range(0, 5) - 2).ToString();
                    }
                }
            }
        }
        options[tem].text = res.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
        }
        
        contador.text = " " + tiempo.ToString("f0");
    }
}
