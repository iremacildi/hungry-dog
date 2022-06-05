using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingFood : MonoBehaviour
{
    public int hungerLevel;
    private bool _isFull;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Carrot" && !_isFull)
        {
            hungerLevel = hungerLevel + 2;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        if(Col.gameObject.tag == "Pea" && !_isFull)
        {
            hungerLevel = hungerLevel + 2;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Meat" && !_isFull)
        {
            hungerLevel = hungerLevel + 8;
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(8);
        }
    }

    public void SetIsFull(bool isFull)
    {
        _isFull = isFull;
    }

    void Update()
    {
        
    }
}
