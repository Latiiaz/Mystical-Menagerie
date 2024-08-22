using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpiritStatsSystem : MonoBehaviour
{
    [SerializeField] public Image affectionBarFill;
    [SerializeField] public float maxAffection;
    [SerializeField] public float currentAffection;

    [SerializeField] public Image hungerBarFill;
    [SerializeField] public float maxHunger;
    [SerializeField] public float currentHunger;

    [SerializeField] public TextMeshProUGUI friendshipText;
    [SerializeField] public float friendshipLevel;

    private int affinityLossOverTime = 5;
    private int hungerLossOverTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentAffection = maxAffection;
        currentHunger = maxHunger;

        //if (currentAffection > 0)
        //{
        //    StartCoroutine(EverySecond());
        //    AffinityLoss();
        //}
        //if (currentHunger > 0)
        //{
        //    StartCoroutine(EverySecond());
        //    HungerLoss();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();


        if (currentAffection > 0)
        {
            StartCoroutine(EverySecond());
            AffinityLoss();
        }
        if (currentHunger > 0)
        {
            StartCoroutine(EverySecond());
            HungerLoss();
        }
    }

    void UpdateStats()
    {
        float affinityFillAmount = currentAffection / maxAffection;
        affectionBarFill.fillAmount = affinityFillAmount;

        float hungerFillAmount = currentHunger / maxHunger;
        hungerBarFill.fillAmount = hungerFillAmount;
    }

    //public string GetName()
    //{
    //    return animalName;
    //}

    //public int GetAge()
    //{
    //    return animalAge;
    //}

    IEnumerator EverySecond()
    {
        yield return new WaitForSeconds(1);
    }

    void AffinityLoss()
    {
        currentAffection -= affinityLossOverTime;
    }
    void HungerLoss()
    {
        currentHunger -= hungerLossOverTime;
    }

    public void Play(int amount)
    {
        currentAffection += amount;
        if (currentAffection > maxAffection)
        {
            currentAffection = maxAffection;
        }
    }

    public void Feed(int amount)
    {
        currentHunger += amount;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }

    public void DisplayHappiness()
    {
        friendshipText.text = string.Format("{0}/5", friendshipLevel);
    }
}
