using System.Collections;
using RPGM.Core;
using UnityEngine;

public class FadingCeiling : MonoBehaviour
{
    public GameObject ceiling;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
           
            //this.gameObject.SetActive(false);
            
           
            //ceiling.targetAlpha = 0.5f;
            //this.GetComponent<TileMapRenderer>().sortingOrder=-20;
            ceiling.transform.position = new Vector3(0, 0, -50);
            ceiling.layer=LayerMask.NameToLayer("Default");
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            //ceiling.gameObject.SetActive(true);
            //this.GetComponent<TileMapRenderer>().sortingOrder=10;
           ceiling.transform.position = new Vector3(0, 0, 0);
           ceiling.layer=LayerMask.NameToLayer("NoVisible");
        //ceiling.targetAlpha = 0.5f;
        }
    }
    
}