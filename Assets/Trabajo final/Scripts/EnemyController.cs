using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
 
    //private float speed=2;
    [SerializeField]
    private float maxrange;
    [SerializeField]
    private float minrange;
    private float time = 0.0f;
    [SerializeField] 
    public Transform[] waypoints;
    [SerializeField]
    public Vector3 siguientePosicion;
    [SerializeField]
    float velocidad = 1.5f;
    float distanciaCambio = 0.5f;
    int numeroSiguientePosicion = 0;



    void Start()
    {
        
        myAnim = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        siguientePosicion = waypoints[0].position;

       
    }
    void Update()
    {
        
        if(Vector3.Distance(target.position, transform.position) <= maxrange&& Vector3.Distance(target.position, transform.position) >= minrange)
        {
            time ++;
            FollowPlayer();
            if (Vector3.Distance(target.position, transform.position) <= minrange && time%5==0)
            {
                
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>().health != 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>().health--;
                }
                time = 0.0f;
            }
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxrange)
        {


            myAnim.SetBool("Range", true);
            myAnim.SetFloat("moveX", (siguientePosicion.x - transform.position.x));
            myAnim.SetFloat("moveY", (siguientePosicion.y - transform.position.y));

            transform.position = Vector3.MoveTowards(
           transform.position,
           siguientePosicion,
           velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position,
                siguientePosicion) < distanciaCambio)
            {
                numeroSiguientePosicion++;
                if (numeroSiguientePosicion >= waypoints.Length)
                    numeroSiguientePosicion = 0;
                siguientePosicion =
                    waypoints[numeroSiguientePosicion].position;

            }

        }
    }

    
    public void FollowPlayer()
    {
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY",(target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocidad * Time.deltaTime);
    }
    /*
    public void GoHome()
    {
        myAnim.SetFloat("moveX", (homepos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homepos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, homepos.position) == 0)
        {
            myAnim.SetBool("Range", false);
        }
    }
    */
}