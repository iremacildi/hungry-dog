using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Animator anim;
    private float relaxVal = 0;

    void Start()
    {
        StartCoroutine(changeEverySecond());
    }

    IEnumerator changeEverySecond() {
        while (true) {
            Debug.Log("Tick");
            relaxVal = Random.Range(0.0f, 4.0f);
            anim.SetFloat("RelaxValue",relaxVal);

            yield return new WaitForSeconds(15);
        }    
    }

    void Update()
    {

    }
}
