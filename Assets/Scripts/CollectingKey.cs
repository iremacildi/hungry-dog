using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingKey : MonoBehaviour
{
    public bool hasTheKey;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource keyAndGateAudioSource;
    bool isGateOpen;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "ChestOpen")
        {
            keyAndGateAudioSource.Play();
            hasTheKey = true;
            Destroy(GameObject.Find("Key"));
            GetComponentInParent<PlayerMove>().SetKeyCollected(hasTheKey);
        }
        else if(Col.gameObject.tag == "Gate" && hasTheKey && !isGateOpen)
        {
            keyAndGateAudioSource.Play();
            isGateOpen = true;
            leftDoor.transform.Rotate(0, 90, 0);
            rightDoor.transform.Rotate(0, -90, 0);    
            GetComponentInParent<PlayerMove>().SetIsWin(true);
        }
    }

    void Update()
    {
        
    }
}
