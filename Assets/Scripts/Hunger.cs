using System;
using UnityEngine;
using TMPro;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    private int maxHungerValue = 100;
    [SerializeField]
    private TextMeshProUGUI currentHunger;
    [SerializeField]
    private TextMeshProUGUI seperator;
    [SerializeField]
    private TextMeshProUGUI maxHunger;
    private int currentHungerValue;
    private GameObject chestOpen;
    private GameObject chestClose;
    public event Action<float> OnHungerPctChanged = delegate { };
    private float flashHunger;
    private float flashDuration = 1f;
    private bool isFull;

    private void OnEnable() 
    {
        chestOpen = GameObject.Find("Chest_Open");
        chestOpen.SetActive(false);
        chestClose = GameObject.Find("Chest_Close");
        chestClose.SetActive(true);
        currentHungerValue = 0;
        maxHunger.text = maxHungerValue.ToString();
    }

    public void ModifyHunger(int amount)
    {
        if(!isFull)
        {
            currentHungerValue += amount;

            float currentHungerPct = (float)currentHungerValue / (float)maxHungerValue;
            OnHungerPctChanged(currentHungerPct);
            UpdateHungerDisplay();
        }        

        if(currentHungerValue >= maxHungerValue){
            currentHungerValue = maxHungerValue;
            isFull = true;
            GetComponentInParent<CollectingFood>().SetIsFull(true);
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
        }
    }

    private void UpdateHungerDisplay()
    {
        currentHunger.text = currentHungerValue.ToString();
    }

    private void Flash()
    {
        if(currentHungerValue != maxHungerValue){
            currentHungerValue = maxHungerValue;
            UpdateHungerDisplay();
        }

        if(flashHunger <= 0){
            flashHunger = flashDuration;
        }
        else if(flashHunger >= flashDuration / 2){
            flashHunger -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else{
            flashHunger -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled){
        currentHunger.enabled = enabled;
        seperator.enabled = enabled;
        maxHunger.enabled = enabled;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            ModifyHunger(+10);
        }

        if(currentHungerValue >= maxHungerValue){
            Flash();
        }
    }
}
