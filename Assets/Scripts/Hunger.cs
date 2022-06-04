using System;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    private int maxHunger = 100;
    private int currentHunger;
    public event Action<float> OnHungerPctChanged = delegate { };

    private void OnEnable() 
    {
        currentHunger = maxHunger;
    }

    public void ModifyHunger(int amount)
    {
        currentHunger += amount;

        float currentHungerPct = (float)currentHunger / (float)maxHunger;
        OnHungerPctChanged(currentHungerPct);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            ModifyHunger(-10);
        }
    }
}
