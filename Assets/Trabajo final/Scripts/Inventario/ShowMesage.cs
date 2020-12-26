using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMesage : MonoBehaviour
{
    public GameObject Message;
    public string Descripcion;

    private Text txt;
    // Start is called before the first frame update
    private void Start()
    {
        txt=Message.transform.GetChild(0).GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.tag=="Player")
        {
            Message.gameObject.SetActive(true);
            txt.text= Descripcion;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        
        
        if (collision.tag=="Player")
        {
            Message.gameObject.SetActive(false);    
        }
        
        
    }
}
