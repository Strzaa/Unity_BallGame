using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip hit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(hit, collision.contacts[0].point);
        }
    }
}
