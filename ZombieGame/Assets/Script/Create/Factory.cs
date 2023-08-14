using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UnitType
{
    WARZOMBIE,
    PARASITEZOMBIE,
    ZOMBIEGIRL
}

public class Factory : MonoBehaviour
{
    [SerializeField] Transform[] createPoint; 

    public GameObject CreateUnit(UnitType type)
    {
        GameObject unit = null;

        switch (type) 
        {
            case UnitType.WARZOMBIE : unit = Instantiate
                    (
                        Resources.Load<GameObject>("Warzombie"),
                        createPoint[Random.Range(0, 3)]
                    );
                break;
            case UnitType.PARASITEZOMBIE : unit = Instantiate
                    (
                        Resources.Load<GameObject>("ParasiteZombie"),
                        createPoint[Random.Range(0, 3)]
                    );
                break;
            case UnitType.ZOMBIEGIRL : unit = Instantiate
                    (
                        Resources.Load<GameObject>("Zombiegirl"),
                        createPoint[Random.Range(0, 3)]
                    );
                break;



        }

        return unit;
    }

}
