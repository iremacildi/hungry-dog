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
            //Col.gameObject.transform.parent.gameObject.SetActive(false);
            Destroy(Col.gameObject.transform.parent.gameObject);
        }
        if(Col.gameObject.tag == "Pea")
        {
            hungerLevel = hungerLevel + 2;
            //Col.gameObject.transform.parent.gameObject.SetActive(false);
            Destroy(Col.gameObject.transform.parent.gameObject);
        }
        else if(Col.gameObject.tag == "Meat")
        {
            hungerLevel = hungerLevel + 8;
            //Col.gameObject.transform.parent.gameObject.SetActive(false);
            Destroy(Col.gameObject.transform.parent.gameObject);
        }
    }

    void Update()
    {
        
    }
}
