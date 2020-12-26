using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPizarra : MonoBehaviour
{

    public GameObject task;
    bool playerClose;
    private Pizzarra pizzarra;
    Bag bag;
    private void Start()
    {
        pizzarra = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pizzarra>();
        bag = GameObject.FindGameObjectWithTag("Bag").GetComponent<Bag>();
    }

    void Update()
    {
        if (isTaskActive() && Input.GetKeyDown(KeyCode.E))
        {
            task.SetActive(true);
            pizzarra.Generated();
            bag.CloseBag();
        }
    } 


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    private bool isTaskActive()
    {
        return playerClose;
    }
}