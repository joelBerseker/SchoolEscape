using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public Sprite SpriteOpen;
    public Sprite SpriteClose;
    public GameObject Message;
    public Vector2 offsetOpen;
    public Vector2 sizeOpen;
    public Vector2 offsetClose;
    public Vector2 sizeClose;
    public bool isLocked;


    private Inventory inventory;
    private bool triggerEntered=false;
    private bool isOpen=false;
    private Text txt;

    private void Start()
    {
        txt=Message.transform.GetChild(0).GetComponent<Text>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        // We check if user pressed E key and character is inside trigger
        if (Input.GetKeyDown (KeyCode.Space) && triggerEntered == true) 
        {
            if(isOpen)
                Close();
            else
                if(isLocked==false)
                    Open();
                else if(IsThereKey()){
                    Open();
                    //isLocked=false;
                }
                else{
                    txt.text="BLOQUEADO";
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.tag=="Player")
        {
            if(isOpen)
                txt.text="ESPACIO/CERRAR";
            else
                txt.text="ESPACIO/ABRIR";
            

            Message.gameObject.SetActive(true);
            triggerEntered=true;
            /*if (Input.GetKey(KeyCode.Space)){
                this.GetComponent<SpriteRenderer>().sprite = SpriteOpen;
                //this.GetComponent<BoxCollider2D> ().enabled = false;

                this.GetComponent<BoxCollider2D>().size = sizeOpen;
                this.GetComponent<BoxCollider2D>().offset = offsetOpen;
                //this.GetComponent<BoxCollider2D> ().isTrigger = true;
                this.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = false;
            }*/
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        
        
        if (collision.tag=="Player")
        {
            Message.gameObject.SetActive(false);
            triggerEntered=false;
            
            //Close();
            
        }
        
        
    }
    private void Open(){
        this.GetComponent<SpriteRenderer>().sprite = SpriteOpen;
        this.GetComponent<BoxCollider2D>().size = sizeOpen;
        this.GetComponent<BoxCollider2D>().offset = offsetOpen;
        this.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = false;
        
        txt.text="ESPACIO/CERRAR";
        isOpen=true;
    }
    private void Close(){
        this.GetComponent<SpriteRenderer>().sprite = SpriteClose;
        this.GetComponent<BoxCollider2D>().size = sizeClose;
        this.GetComponent<BoxCollider2D>().offset = offsetClose;
        this.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = true;
        
        txt.text="ESPACIO/ABRIR";
        isOpen=false;
    }

    private bool IsThereKey(){
        bool open=false;
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.slots[i].transform.childCount > 0)
            {
                GameObject child = inventory.slots[i].transform.GetChild(0).gameObject;
                if (child.CompareTag("Key"))
                {
                    open = true;
                    Destroy(child);
                    break;
                }
            }
        }
        return open;
    }
}
