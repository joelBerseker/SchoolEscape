using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyMovement : MonoBehaviour
{
    private Animator myAnim;
    public AIPath aIPath;
    Vector2 direccion;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();

        myAnim.SetBool("Range", true);
        myAnim.SetFloat("moveX", (direccion.x - transform.position.x));
        myAnim.SetFloat("moveY", (direccion.y - transform.position.y));

    }

    void faceVelocity(){
        direccion = aIPath.desiredVelocity;
        transform.right = direccion;
    }
}
