using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

    public  bool isClosed;
    public GameObject bag;

    private void Start()
    {
        isClosed=true;
    }
    public void OpenCloseBag() {
        if (isClosed == true)
        {
            bag.SetActive(true);
            isClosed = false;
        }
        else {
            bag.SetActive(false);
            isClosed = true;
        }
    }
    public void CloseBag()
    {
        if (!isClosed)
        {
            bag.SetActive(false);
            isClosed = true;
        }
    }
}
