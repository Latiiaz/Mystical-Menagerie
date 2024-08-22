using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//Creature Stats: Indicate relationship with player, Where to find them, Time that they spawn, Passive buffs, Prefers wild berries/ShinyMinerals!! (Can only be accessed at the spirit altar)
public class CreatureStats : MonoBehaviour
{
    [SerializeField] public Image relationshipBarFill;
    [SerializeField] public float currentCreatureRelationship;
    [SerializeField] public float maxCreatureRelationship;

    [SerializeField] TextMeshProUGUI habitat; //Habitat, TimeAwake, Type of passive buff can be combined into txt file
    [SerializeField] TextMeshProUGUI timeAwake;
    [SerializeField] TextMeshProUGUI passiveBuffs;
    [SerializeField] TextMeshProUGUI characterName;

    [SerializeField] bool prefWildBerry = false;
    [SerializeField] bool prefShinyMinerals = false;

    [SerializeField] private CreatureStatsSO creatureStatsSO;
    [SerializeField] private PlayerInventory playerInventory;

    public bool isActive;
    public GameObject characterBox;

    //Maybe add date met, (Nickname) Creature Name



    // Start is called before the first frame update
    void Start()
    {
        if (characterBox != null)
        {
            characterBox.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRelationshipBar();
        CreatureFact(creatureStatsSO);

        if (characterBox == null)
        {
            bool isActive = characterBox.activeSelf; 
            characterBox.SetActive(!isActive); 
        }

    }

    public virtual void ReceiveOffering(float amount)
    {
        if (playerInventory.wildBerryCount <= 0)
        {
            Debug.Log("womp womp no more food");
        }
        else
        {
            currentCreatureRelationship += amount;
            if (currentCreatureRelationship > maxCreatureRelationship)
            {
                currentCreatureRelationship = maxCreatureRelationship;
                Debug.Log("Maximum capacity reached");
            }
            UpdateRelationshipBar();
        }
        
    }

    public void UpdateRelationshipBar()
    {
        float newRS = (currentCreatureRelationship - 100) * -1; // Change colors when higher overall %
        float fillAmount = newRS / maxCreatureRelationship;
        relationshipBarFill.fillAmount = fillAmount;
    }

    public void CreatureFact(CreatureStatsSO creatureStatsSO)
    {
        characterName.text = creatureStatsSO.creatureNickName + string.Format(" ({0})", creatureStatsSO.creatureName);
        habitat.text = creatureStatsSO.habitat;
        timeAwake.text = creatureStatsSO.timeAwake;
        passiveBuffs.text = creatureStatsSO.passiveBuffs;
    }

    
}
