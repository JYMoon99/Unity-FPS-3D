using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteZombie : Zombie
{
    new void Start()
    {
        base.Start(); // base : 부모 클래스

        health = 120;
        attack = 7;

    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

}

