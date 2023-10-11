using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    public float timeToAdd = 5f;
    public GameObject bonusParticle;
    SoundMenager soundMenager;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        soundMenager = GameObject.FindGameObjectWithTag("SoundMenager").GetComponent<SoundMenager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundMenager.PlaySound(SoundMenager.Sounds.Bonus);
            gm.time += timeToAdd;
            Instantiate(bonusParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
