using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyMovement : MonoBehaviour
{

    public AIPath aIPath;
    Vector2 direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();
    }

    void faceVelocity(){
        direccion = aIPath.desiredVelocity;
        transform.right = direccion;
    }
}
