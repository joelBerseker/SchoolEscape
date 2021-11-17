using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject mySwords;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = mySwords.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(espera());
               
        }
    }
    public void AddPoints()
    {
        currentPoints++;
        
    }
    IEnumerator espera()
    {
        
        yield return new WaitForSeconds(1f);
        transform.parent.gameObject.SetActive(false); 
        
    }
}
