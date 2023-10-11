using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public bool reverse = false;

    Vector3 force;
    void Start()
    {
        force = Vector3.left * speed;

        if (reverse)
        {
            ReverseVectors();
        }
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f, false);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) 
        {
            //Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.CompareTag("Floor") ||
                hit.transform.gameObject.CompareTag("Player"))
            {
                Move();
            }
            else
            {
                ReverseVectors();
                Move();
            }
        }
        else
        {
            ReverseVectors();
            Move();
        }
    
    }

    void Move()
    {
        transform.GetComponent<Rigidbody>().velocity = force;
    }

    void ReverseVectors()
    {
        force = -force;
        direction.Set(-direction.x, direction.y, direction.z);
    }
}
