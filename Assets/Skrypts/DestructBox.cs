using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructBox : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public int life;
    public bool isRigidbody = false;

    private Material material;
    private int maxLife = 3;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        life = Mathf.Clamp(life, 1, maxLife);
        material = GetComponent<MeshRenderer>().material;
        SetColor();

        if (isRigidbody)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.mass = 0.75f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            life--;

            if (life > 0)
            {
                SetColor();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    void SetColor()
    {
        material.color = Color.Lerp(endColor, startColor, (float)(life - 1) / (float)(maxLife - 1));
    }

    private void OnValidate()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        SetColor();
    }
}
