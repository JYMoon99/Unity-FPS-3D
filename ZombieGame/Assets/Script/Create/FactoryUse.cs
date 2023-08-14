using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryUse : MonoBehaviour
{
    [SerializeField] Factory factory;

    WaitForSeconds wait = new WaitForSeconds(10);

    void Start()
    {
        StartCoroutine(CreateZombie());
    }


    private IEnumerator CreateZombie()
    {
        while (true)
        {
            factory.CreateUnit((UnitType)Random.Range(0, 3));

            yield return wait;
        }

    }

}
