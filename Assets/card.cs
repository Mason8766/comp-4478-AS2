using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    //definitions of game objects
    GameObject cardcontroller;
    SpriteRenderer spriteRender;


    //card properties
    public Sprite[] fronts; //list of all the images for the front of the card
    public Sprite back; //the back face of the card
    public int indexCard;//determins which image from the fronts array, will be displayed

    public bool isMatched = false; //determins if the card should be able to flip


    public void OnMouseDown(){ //if clicked on
        if (isMatched == false && cardcontroller.GetComponent<Controller>().isAlreadyMatched(indexCard) == false) //Checks to see if this card is considered matched, and if this set of cards is already completed
        {
            if (spriteRender.sprite == back) //if the card is currently showing the back
            {

                if (cardcontroller.GetComponent<Controller>().cardsDisplayed() == false) //if there is less then 2 cards already turned over, flip card
                {
                    spriteRender.sprite = fronts[indexCard]; //set the cards sprite to be the cards front from list
                    cardcontroller.GetComponent<Controller>().AddFace(indexCard); //sends the cards data to the controller, to know which cards are flipped
                    isMatched = cardcontroller.GetComponent<Controller>().isMatching(); //checks to see if the other flipped card matches this one
                }

            }
            else //if the card is showing its front
            {
                spriteRender.sprite = back; //show the back of the card
                cardcontroller.GetComponent<Controller>().RemoveFace(indexCard); //remove this card from the current turned over cards
            }
        }
    }

    private void Awake(){//when programs starts
        //setup game objects
        cardcontroller = GameObject.Find("Controller");
        spriteRender = GetComponent<SpriteRenderer>();
    }













    // Start is called before the first frame update
   // void Start()
   // {
        
   // }

    // Update is called once per frame
   // void Update()
   // {
        
   // }
}
