    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
                if (inventory.slots[i].transform.childCount > 0) { 
                    Instantiate(effect, transform.position, Quaternion.identity);
                    GameObject child = inventory.slots[i].transform.GetChild(0).gameObject;
                    if (child.CompareTag("Key"))
                    {
                        continue;
                    }
                    if (inventory.items[i] > 0 && inventory.items[i] <= 3 && child.CompareTag(itemButton.tag))
                    {
                        inventory.items[i] += 1;
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
        
    }
}
