using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Generic : MonoBehaviour
{
    DataStore<Vector3> store = new DataStore<Vector3>();
    DataStore<float> MasaObj = new DataStore<float>();
    DataStore<bool> GravityObj = new DataStore<bool>(); 

    Transform tr;
    Rigidbody rb;

    class DataStore<T>
    {
        public T Data { get; set; }
        public T Masa { get; set; }
        public T Gravity { get; set; }
        
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        MasaObj.Masa = rb.mass;
        store.Data = tr.transform.position;
        GravityObj.Gravity = rb.useGravity;
        Debug.Log("Masa Pi³ki: " + MasaObj.Masa);
        Debug.Log("Pocz¹tkowa Pozycja: " + store.Data);
        if (GravityObj.Gravity == false) Debug.Log("Nie U¿ywa Grawitacji");
        if (GravityObj.Gravity == true) Debug.Log("U¿ywa Grawitacji");
    }

}
