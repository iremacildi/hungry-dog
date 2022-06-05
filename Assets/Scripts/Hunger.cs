using System;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    private int maxHunger = 100;
    private int currentHunger;
    private GameObject chestOpen;
    private GameObject chestClose;
    public event Action<float> OnHungerPctChanged = delegate { };

    private void OnEnable() 
    {
        chestOpen = GameObject.Find("Chest_Open");
        chestClose = GameObject.Find("Chest_Close");
        chestClose.SetActive(true);
        currentHunger = 0;
    }

    public void ModifyHunger(int amount)
    {
        currentHunger += amount;

        float currentHungerPct = (float)currentHunger / (float)maxHunger;
        OnHungerPctChanged(currentHungerPct);

        if(currentHunger >= 100){
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            ModifyHunger(+10);
        }
    }
}
