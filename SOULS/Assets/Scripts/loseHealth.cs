using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseHealth : MonoBehaviour
{
    public makeDeck deckScript; //setting reference to deck script
    public GameObject spriteHP; //for holding the HP sprite of the hit card
    public Material updatedHPMaterial;
    public cardTracker cardTracker;

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GetComponent<makeDeck>(); //pulling deck script to reference variable
        cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>();
        //Material[] mats = Resources.LoadAll<Material>("Materials/numbers");
        //Debug.Log("Materials" + mats);
    }

    //takes in two card objects and lowers the health of the hit card based on the attacking card's attack stat
    public bool getsAttackedBy(GameObject hitCard, GameObject attackingCard){ //returns true if hitCard dies
        Card hurtCard = cardTracker.getScriptable(hitCard); //Get reference card's scriptable first
        Card aggroCard = cardTracker.getScriptable(attackingCard);
        spriteHP = hitCard.gameObject.transform.GetChild(10).gameObject; //HP sprite is 10th index child object of card
       
        int HPtoLose = aggroCard.attack; //get attack of attackingCard
        int currentHP = hurtCard.health;//get current health of hitCard
        int newHealth = currentHP - HPtoLose;//calculate new health
        Debug.Log("Updated health: " + newHealth);

        if(newHealth <= 0){ //if health <= 0, update sprite to 0 and kill card
            hurtCard.health = 0; //updating card's health stat
            updatedHPMaterial = Resources.Load<Material>("newZero"); //get material for zero sprite
            spriteHP.GetComponent<MeshRenderer>().material = updatedHPMaterial; //update HP sprite to zero
            Destroy(hitCard); //kill card object
            return true;
        } else { //else, update hp sprite and card hp to new health
            switch(newHealth) 
            { //fetch proper material for new health
            case 1:
                updatedHPMaterial = Resources.Load<Material>("newOne"); 
                break;
            case 2:
                updatedHPMaterial = Resources.Load<Material>("newTwo");
                break;
            case 3:
                updatedHPMaterial = Resources.Load<Material>("newThree");
                break;
            case 4:
                updatedHPMaterial = Resources.Load<Material>("newFour");
                break;
            case 5:
                updatedHPMaterial = Resources.Load<Material>("newFive");
                break;
            case 6:
                updatedHPMaterial = Resources.Load<Material>("newSix");
                break;
            default: //if health not a possible value
                Debug.Log("Error: newHealth out of bounds"); //log error
                break;
            }
            spriteHP.GetComponent<MeshRenderer>().material = updatedHPMaterial; //update HP sprite
            hurtCard.health = newHealth; //updating health stat in card
            return false;
        }
    }

}
