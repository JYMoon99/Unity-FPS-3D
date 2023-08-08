using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UnitType
{
    WarZombie
}

public class Factory : MonoBehaviour
{
    [SerializeField] Transform[] createPoint; 

    public GameObject CreateUnit(UnitType type)
    {
        GameObject unit = null;

        switch (type) 
        {
            case UnitType.WarZombie : unit = Instantiate
                    (
                        Resources.Load<GameObject>("Warzombie F Pedroso"),
                        createPoint[Random.Range(0, 3)]
                    );
                break;
        
        }

        return unit;
    }

}
