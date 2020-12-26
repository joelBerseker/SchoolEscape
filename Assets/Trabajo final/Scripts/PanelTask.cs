﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelTask : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI papel;

    public AudioClip approved;
    public AudioClip denied;

    public GameObject itemKey;
    private Transform playerPos;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
         playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GeneratePassword();
    }

    public void AddNumber(string number)
    {
        if (display.text.Length >= 4)
        {
            return;
        }

        display.text += number;
    }

    public void EraseDisplay()
    {
        display.text = "";
    }

    private void GeneratePassword()
    {
        papel.text = "";

        for (int i = 0; i < 4; i++)
        {
            int randNumber = UnityEngine.Random.Range(1, 9);
            papel.text += randNumber;
        }
    }

    public void CheckPassword()
    {
        if (display.text.Equals(papel.text))
        {
            audioSource.PlayOneShot(approved);
            display.color = Color.green;
            display.text = "Granted";
            Destroy(gameObject, 1.0f);
            Instantiate(itemKey, playerPos.position, Quaternion.identity);
        }
        else
        {
            audioSource.PlayOneShot(denied);
            display.text = "Denied";
        }
    }
}