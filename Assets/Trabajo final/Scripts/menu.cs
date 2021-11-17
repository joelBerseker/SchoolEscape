using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Jugar(int Nivel)
    {
        PlayerPrefs.SetInt("Nivel", Nivel);
        SceneManager.LoadScene("Juego");
    }
    public void RedesSociales(string URL)
    {
        Application.OpenURL(URL);
    }
}
