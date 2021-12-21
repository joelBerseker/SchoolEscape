using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunItem : MonoBehaviour {

    private BarraVida enemy;
    private Inventory inventory;
    public GameObject explosionEffect;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BarraVida>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use() {
        int i = transform.parent.GetComponent<Slot>().index;
        Instantiate(explosionEffect, enemy.transform.position, Quaternion.identity);
        enemy.vidaActual -= 25;
        inventory.items[i] = inventory.items[i] - 1;
        if (inventory.items[i] == 0)
        {
            Destroy(gameObject);
        }
    }

}
