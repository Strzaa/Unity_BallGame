using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallBust : MonoBehaviour
{
    [SerializeField]
    float boostForce = 1f;

    GameObject boostText;

    Rigidbody rb;
    bool boostActivated = false;
    bool boostReady = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostText = GameObject.Find("Boost").gameObject;
        TextVisible();
    }

    private void TextVisible()
    {
        if (boostReady) boostText.SetActive(true);
        else boostText.SetActive(false);
    }

    void Update()
    {
        TextVisible();

        if (Input.GetKeyDown(KeyCode.Space) && boostReady)
        {
            boostActivated = true;
            boostReady = false;
        }
    }

    private void FixedUpdate()
    {
        if (boostActivated)
        {
            rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse);
            boostActivated = false;
            StartCoroutine("BoostCoroutine");
        }
    }
    IEnumerator BoostCoroutine()
    {
        yield return new WaitForSeconds(3f);
        boostReady = true;
        yield break;
    }
}
