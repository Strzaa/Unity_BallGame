using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poruszanie : MonoBehaviour
{
    public float speed = 1f;
    public float maxspeed;

    [SerializeField]
    private Rigidbody rb;
    private bool isRB;

    private GameManager gameManager;

    void Start()
    {
        if(isRB = TryGetComponent<Rigidbody>(out rb))
        {
            rb.maxAngularVelocity = maxspeed;
        }

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }

    void Update()
    {
        if(transform.position.y <= -10f)
        {
            gameManager.RestartLevel();
        }
    }

    private void FixedUpdate()
    {
        float Hdirection;
        float Vdirection;

        if (isRB && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddTorque(0, 0, -Hdirection * speed);
        }
        if (isRB && (Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddTorque(Vdirection * speed, 0, 0);
        }
    
    }
}
