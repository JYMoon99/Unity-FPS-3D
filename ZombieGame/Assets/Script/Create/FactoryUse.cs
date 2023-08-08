using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryUse : MonoBehaviour
{
    [SerializeField] Factory factory;

    GameObject unit1 = null;

    void Start()
    {

        unit1 = factory.CreateUnit(UnitType.WarZombie);
        
    }


}
