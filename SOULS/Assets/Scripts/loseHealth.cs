using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseHealth : MonoBehaviour
{
    public makeDeck deckScript; //setting reference to deck script
    public GameObject spriteHP; //for holding the HP sprite of the hit card
    public Material updatedHPMaterial;

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GetComponent<makeDeck>(); //pulling deck script to reference variable
    }

    public void getsAttackedBy(Card hitCard, Card attackingCard){ //takes in two card objects and lowers the health of the hit card based on the attacking card's attack stat   

        spriteHP = hitCard.transform.GetChild(9).gameObject; //HP sprite is 9th index child object of card
       
        HPtoLose = attackingCard.attack; //get attack of attackingCard
        currentHP = hitCard.health;//get current health of hitCard
        newHealth = currentHP - HPtoLose;//calculate new health

        if(newHealth <= 0){ //if health <= 0, update sprite to 0 and kill card
            updatedHPMaterial = numbers.Load<Material>("newZero"); //get material for zero sprite
            spriteHP.GetComponent<SpriteRenderer>().material = updatedHPMaterial; //update HP sprite to zero
            Destroy(hitCard); //kill card
            
        } else { //else, update hp sprite and card hp to new health
            switch(newHealth) 
            { //fetch proper material for new health
            case 1:
                updatedHPMaterial = numbers.Load<Material>("newOne"); 
                break;
            case 2:
                updatedHPMaterial = numbers.Load<Material>("newTwo");
                break;
            case 3:
                updatedHPMaterial = numbers.Load<Material>("newThree");
                break;
            case 4:
                updatedHPMaterial = numbers.Load<Material>("newFour");
                break;
            case 5:
                updatedHPMaterial = numbers.Load<Material>("newFive");
                break;
            case 6:
                updatedHPMaterial = numbers.Load<Material>("newSix");
                break;
            default: //if health not a possible value
                Debug.Log("Error: newHealth out of bounds"); //log error
                break;
            }
            spriteHP.GetComponent<SpriteRenderer>().material = updatedHPMaterial; //update HP sprite
        }
    }

}
