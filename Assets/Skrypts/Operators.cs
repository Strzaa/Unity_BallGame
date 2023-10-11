using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Operators : MonoBehaviour
{
    struct Pozycja
    {
        public Vector3 vector3;

        public Pozycja (Vector3 input)
        {
            vector3 = input;
        }

        public static Pozycja operator -(Pozycja obj1, Pozycja obj2)
        {
            Pozycja wynik;
            wynik.vector3.x = obj1.vector3.x - obj2.vector3.x;
            wynik.vector3.y = obj1.vector3.y - obj2.vector3.y;
            wynik.vector3.z = obj1.vector3.z - obj2.vector3.z;
            return wynik;
        }

        public static Pozycja operator *(Pozycja obj, int x)
        {
            Pozycja wynik;
            wynik.vector3.x = obj.vector3.x * x;
            wynik.vector3.y = obj.vector3.y * x;
            wynik.vector3.z = obj.vector3.z * x;
            return wynik;
        }

        public static Pozycja operator +(Pozycja obj1, Pozycja obj2)
        {
            Pozycja wynik;
            wynik.vector3.x = obj1.vector3.x + obj2.vector3.x;
            wynik.vector3.y = obj1.vector3.y + obj2.vector3.y;
            wynik.vector3.z = obj1.vector3.z + obj2.vector3.z;
            return wynik;
        }


    }

    [Header("Ró¿nica/Suma Pozycji 2 Obiektów")]
    public GameObject obj1;
    public GameObject obj2;
    [Header("Mno¿enie wektorów przez skalar")]
    public GameObject obj3;
    public int x;
    private void Start()
    {

        obj1 = GameObject.Find(obj1.name).gameObject;
        obj2 = GameObject.Find(obj2.name).gameObject;
        obj3 = GameObject.Find(obj3.name).gameObject;

        Pozycja nr1 = new Pozycja(obj1.transform.position);
        Pozycja nr2 = new Pozycja(obj2.transform.position);
        Pozycja nr3 = new Pozycja(obj3.transform.position);
        Pozycja nr_wynik = nr1 - nr2;

        if (nr_wynik.vector3.x < 0 || nr_wynik.vector3.y < 0 || nr_wynik.vector3.z < 0)
        { 
           if (nr_wynik.vector3.x < 0) nr_wynik.vector3.x = -nr_wynik.vector3.x;
           if (nr_wynik.vector3.y < 0) nr_wynik.vector3.y = -nr_wynik.vector3.y;
           if (nr_wynik.vector3.z < 0) nr_wynik.vector3.z = -nr_wynik.vector3.z;
        }

        Pozycja nr_wynik1 = nr3 * x;
        Pozycja nr_wynik2 = nr1 + nr2;

        Debug.Log("Ró¿nica pozycji w formacie wektora: " + nr_wynik.vector3);
        Debug.Log("Suma pozycji w formacie wektora: " + nr_wynik2.vector3);
        Debug.Log("Mno¿enie wekrora przez skalar x: " + nr_wynik1.vector3);
    }

}