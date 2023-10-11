using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3Modyfi : Box2Modyfi
{
    public float AbstractModifierMass;

    void Awake()
    {
        Modyfi1();
        Modyfi2();
        MaterialChange();
    }

    public override void Modyfi2()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.mass += AbstractModifierMass;
    }

}
