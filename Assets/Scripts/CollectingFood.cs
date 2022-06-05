using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingFood : MonoBehaviour
{
    private bool _isFull;
    public float _extraTime = 0f;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Carrot" && !_isFull)
        {
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Pea" && !_isFull)
        {
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Meat" && !_isFull)
        {
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(8);
        }
        else if(Col.gameObject.tag == "Treat")
        {
            Destroy(Col.gameObject.transform.parent.gameObject);
            _extraTime = 10.0f;
        }
    }

    public void SetIsFull(bool isFull)
    {
        _isFull = isFull;
    }

    public void SetExtraTimeZero()
    {
        _extraTime = 0f;
    }

    public float GetExtraTime()
    {
        return _extraTime;
    }

    void Update()
    {
        
    }
}
