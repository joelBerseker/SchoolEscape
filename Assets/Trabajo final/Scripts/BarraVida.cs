using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraVida : MonoBehaviour
{
    // Start is called before the first frame update
    public Image barraDeVida;

    public float vidaActual;

    public float vidaMaxima;

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        if (vidaActual == 0)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

}
