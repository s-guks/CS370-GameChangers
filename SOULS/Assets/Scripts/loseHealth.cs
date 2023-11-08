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
        //Material[] mats = Resources.LoadAll<Material>("Materials/numbers");
        //Debug.Log("Materials" + mats);
    }

    public void getsAttackedBy(Card hitCard, Card attackingCard){ //takes in two card objects and lowers the health of the hit card based on the attacking card's attack stat   

        //spriteHP = hitCard.gameObject.transform.GetChild(9).gameObject; //HP sprite is 9th index child object of card
        //spriteHP = hitCard.FindWithTag("healthSprite");
       
        int HPtoLose = attackingCard.attack; //get attack of attackingCard
        int currentHP = hitCard.health;//get current health of hitCard
        int newHealth = currentHP - HPtoLose;//calculate new health

        if(newHealth <= 0){ //if health <= 0, update sprite to 0 and kill card
            updatedHPMaterial = Resources.Load<Material>("newZero"); //get material for zero sprite
            spriteHP.GetComponent<SpriteRenderer>().material = updatedHPMaterial; //update HP sprite to zero
            Destroy(hitCard); //kill card
            
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
            spriteHP.GetComponent<SpriteRenderer>().material = updatedHPMaterial; //update HP sprite
        }
    }

}
