using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombiegirl : Zombie
{

    new void Start()
    {
        base.Start(); // base : 부모 클래스

        health = 50;
        attack = 20;

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
