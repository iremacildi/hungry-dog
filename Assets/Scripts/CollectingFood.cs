using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingFood : MonoBehaviour
{
    public int hungerLevel;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Carrot")
        {
            hungerLevel = hungerLevel + 2;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        if(Col.gameObject.tag == "Pea")
        {
            hungerLevel = hungerLevel + 2;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Meat")
        {
            hungerLevel = hungerLevel + 8;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(8);
        }
    }

    void Update()
    {
        
    }
}
