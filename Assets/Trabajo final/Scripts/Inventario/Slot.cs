using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    private Inventory inventory;
    public int index;
    public Text text;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) {
            inventory.items[index] = 0;
        }
        if(inventory.items[index] == 0)
        {
            text.text = " ";
        }
        else
        {
            text.text = inventory.items[index].ToString();
        }
    }

    public void Cross() {

        int i = transform.parent.transform.GetChild(0).gameObject.GetComponent<Slot>().index;
        Debug.Log("Slot numero: " + i);
           
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnItem();
            if (inventory.items[i] <= 1)
            {
                    GameObject.Destroy(child.gameObject);
            }
            else
            {
                inventory.items[i] = inventory.items[i] - 1;
            }
         
        }
    }

}
