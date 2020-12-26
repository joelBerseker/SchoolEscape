using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public float health;
    public Text healthDisplay;
    public float healthMax;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    public bool isHealthMax()
    {
        return health >= healthMax;
    }
}
