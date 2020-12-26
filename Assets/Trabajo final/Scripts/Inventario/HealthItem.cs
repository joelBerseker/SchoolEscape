using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

    private PlayerData player;
    private Inventory inventory;
    public GameObject healthEffect;
    public int healthBoost;

    private void Start()
    {
        player      = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        inventory   = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use() {
        if (!player.isHealthMax())
        {
            int i = transform.parent.GetComponent<Slot>().index;
            Instantiate(healthEffect, player.transform.position, Quaternion.identity);
            player.health += healthBoost;
            inventory.items[i] = inventory.items[i] - 1;
            if (inventory.items[i] == 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Mucha vida muchacho :'v \n tu quieres estar mamadisimo?");
        }
    }
}
