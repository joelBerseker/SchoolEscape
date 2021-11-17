using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventKeyLab : MonoBehaviour

{
    public GameObject enemigo;
    public GameObject llave;
    public Texture icoVida;
    private int vidas = 3;
    private AudioSource source;
    public AudioClip kill_1;
    public AudioClip kill_2;
    public AudioClip intro;
    public AudioClip gameOver;
    

    private void Awake()
    {
        source = GetComponent<AudioSource>();

    }
    void Start()
    {

            StartCoroutine("musica");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {           
            Destroy(other.gameObject);
            Destroy(enemigo);
            SceneManager.LoadScene("GameWin");


        }

        if (other.CompareTag("Enemy")){

            vidas--;
            
                switch(vidas) {
                    case 2: StartCoroutine("primeraMuerte");
                    break;
                    case 1: StartCoroutine("segundaMuerte");
                    break;
                    
                }
            
                
            if (vidas <= 0)
            {
                // Game Over
                StartCoroutine("finPartida");
                return;
            }
            else
            {
                resetbyDeath();
            }
        }
           
    }

    public IEnumerator musica()
    {
        
        source.PlayOneShot(intro, 1.0f);
        yield return new WaitForSeconds(5);
        
        
        
    }

    public void OnGUI()
    {

        if(vidas >= 1)
            GUI.Box(new Rect(30, 0, 30, 30), icoVida);
        if(vidas >= 2)
            GUI.Box(new Rect( 60, 0, 30, 30), icoVida);
        if(vidas >= 3)
            GUI.Box(new Rect(90, 0, 30, 30), icoVida);
    }
    public void resetbyDeath()
    {
        // Se eliminan los monstruos actuales
        //Destroy(enemigo);

        //Insertar Jugador con la puntuacion
        //pj = gdl.colocarJugador();

    }

    public IEnumerator primeraMuerte()
    {
        //Destroy(enemigo);
        source.PlayOneShot(kill_1, 1.0f);
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("GameOver");

    }
    public IEnumerator segundaMuerte()
    {
        //Destroy(enemigo);
        source.PlayOneShot(kill_2, 1.0f);
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("GameOver");

    }
    public IEnumerator finPartida()
    {
        Destroy(enemigo);
        source.PlayOneShot(gameOver, 1.0f);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");

    }
}
