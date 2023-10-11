using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2Modyfi : Box1Modyfi
{
    public float AbstractModifierSpeed;

    private void Awake()
    {
        Modyfi1();
        MaterialChange();
    }

    public override void Modyfi1()
    {
        MoveBox = GetComponent<MoveBox>();
        MoveBox.speed += AbstractModifierSpeed;
    }
}
