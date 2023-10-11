using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract : MonoBehaviour
{
    [HideInInspector]
    public MoveBox MoveBox;
    [HideInInspector]
    public Rigidbody Rigidbody;

    public Material Material; 

    public abstract void Modyfi1();
    public abstract void Modyfi2();

    public void MaterialChange()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = Material;
    }
}
