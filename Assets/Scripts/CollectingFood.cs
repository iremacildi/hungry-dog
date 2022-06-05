using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectingFood : MonoBehaviour
{
    private bool _isFull;
    public float _extraTime = 0f;
    public AudioSource foodAudioSource;
    public AudioSource extratimeAudioSource;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Carrot" && !_isFull)
        {
            foodAudioSource.Play();
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Pea" && !_isFull)
        {
            foodAudioSource.Play();
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(2);
        }
        else if(Col.gameObject.tag == "Meat" && !_isFull)
        {
            foodAudioSource.Play();
            Destroy(Col.gameObject.transform.parent.gameObject);
            GetComponentInParent<Hunger>().ModifyHunger(8);
        }
        else if(Col.gameObject.tag == "Treat")
        {
            extratimeAudioSource.Play();
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
