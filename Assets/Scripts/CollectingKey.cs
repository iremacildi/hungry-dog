using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingKey : MonoBehaviour
{
    public bool hasTheKey;
    public GameObject leftDoor;
    public GameObject rightDoor;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "ChestOpen")
        {
            hasTheKey = true;
            Destroy(GameObject.Find("Key"));
            GetComponentInParent<PlayerMove>().SetKeyCollected(hasTheKey);
        }
        else if(Col.gameObject.tag == "Gate" && hasTheKey)
        {
            leftDoor.transform.Rotate(0, 90, 0);
            rightDoor.transform.Rotate(0, -90, 0);            
        }
    }

    void Update()
    {
        
    }
}
