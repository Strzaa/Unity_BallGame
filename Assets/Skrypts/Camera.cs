using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 distance;
    public float lookup;
    public float lerp;

    private GameObject ball;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        ball = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ball.transform.position + distance, lerp * Time.deltaTime);
        transform.LookAt(ball.transform.position);
        transform.Rotate(-lookup, 0, 0);
    }

}
