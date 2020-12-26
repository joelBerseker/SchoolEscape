using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualDoorScript : MonoBehaviour
{
    public Sprite SpriteOpenDoor1;
    public Sprite SpriteOpenDoor2;
    public Sprite SpriteCloseDoor1;
    public Sprite SpriteCloseDoor2;
    public GameObject Message;
    public Vector2 offsetOpen;
    public Vector2 sizeOpen;
    public Vector2 offsetClose;
    public Vector2 sizeClose;
    public bool isLocked;


    private Inventory inventory;
    private bool triggerEntered=false;
    private bool isOpen=false;
    private Vector2 offsetOpenInverso;
    private Text txt;
    private Transform door1;
    private Transform door2;


    private void Start(){

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        offsetOpenInverso =new Vector2(-offsetOpen.x,offsetOpen.y);
        txt=Message.transform.GetChild(0).GetComponent<Text>();
        door1=this.transform.GetChild(0);
        door2=this.transform.GetChild(1);
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
                    isLocked=false;
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
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        
        
        if (collision.tag=="Player")
        {
            Message.gameObject.SetActive(false);
            triggerEntered=false;
        }
        
        
    }
    private void Open(){
        //door 1
        door1.GetComponent<SpriteRenderer>().sprite = SpriteOpenDoor1;
        door1.GetComponent<BoxCollider2D>().size = sizeOpen;
        door1.GetComponent<BoxCollider2D>().offset = offsetOpen;
        door1.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = false;

        //door 2
        door2.GetComponent<SpriteRenderer>().sprite = SpriteOpenDoor2;
        door2.GetComponent<BoxCollider2D>().size = sizeOpen;
        door2.GetComponent<BoxCollider2D>().offset = offsetOpenInverso;
        door2.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = false;

        txt.text="ESPACIO/CERRAR";
        isOpen=true;
    }
    private void Close(){
        //door 1
        door1.GetComponent<SpriteRenderer>().sprite = SpriteCloseDoor1;
        door1.GetComponent<BoxCollider2D>().size = sizeClose;
        door1.GetComponent<BoxCollider2D>().offset = offsetClose;
        door1.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = true;

        //door 2
        door2.GetComponent<SpriteRenderer>().sprite = SpriteCloseDoor2;
        door2.GetComponent<BoxCollider2D>().size = sizeClose;
        door2.GetComponent<BoxCollider2D>().offset = offsetClose;
        door2.transform.GetChild(0).GetComponent<BoxCollider2D> ().enabled = true;

        
        txt.text="ESPACIO/ABRIR";
        isOpen=false;
    }

    private bool IsThereKey(){
        bool open = false;
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
