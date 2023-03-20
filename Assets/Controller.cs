using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static System.Random rnd = new System.Random(); //generates a random number
    public int random = 1; //the inital value

    List<int> listOfCards = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }; //list of indexs, used in the fronts card list (for displaying card fronts)
    List<int> listOfFinishedCards = new List<int> {}; //list of indexs, for cards already matched

    //used for matching and flipping
    int cardsup = 0; // counter of how many cards are currently flipped (and shwoing the front)
    int cardOne = -1; //value of the first fipped card
    int cardTwo = -2; //value of second flipped card

    GameObject card;

    int endGameflag = 0; //flag to see if the game has finished

    public display other; //script

    private void Awake() //when game starts set up the card object
    {
        card = GameObject.Find("card");
    }

    void Start()//on startup
    {

        //set the initial card postion
        float x = -2;
        float y = 3f;
        //picks the face of the first orginal card
        random = rnd.Next(0, (listOfCards.Count)); //get a radnom number between 0, and the number of cards in listOfCards
        card.GetComponent<card>().indexCard = listOfCards[random]; //geta card front using the randomly generated index
        listOfCards.Remove(listOfCards[random]); //remove this card option as it has been picked
       
        for (int i = 0; i < 15; i++) //generate 15 other cards
        {

            var tempCard = Instantiate(card, new Vector3(
                x, y, 0), Quaternion.identity); //new card
            x += 4; //move to next column
            if (x >= 10) //once row is filled, move back to column one and go to a new row
            {
                x = -6;
                y -= 2;
            }

            //pick a random front for the card, then assign it to the card
            random = rnd.Next(0, (listOfCards.Count));
            tempCard.GetComponent<card>().indexCard = listOfCards[random];
            listOfCards.Remove(listOfCards[random]);


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (endGameflag == 1)//checks to see if the game is finished
        {
            display.gameText(); //display the end game text
        }
    }

    //add a card to the pool of cards face up
    public void AddFace(int index)
    {
        if(cardOne < 0) //if there is no value assigned to the first card holder
        {
            //assign firstcard holder a card
            cardOne = index;
            cardsup += 1; //increase the current amount of flipped up cards
        }else if(cardTwo < 0)
        {
            //assing secondcard holder to a card
            cardTwo = index;
            cardsup += 1;
        }


    }
    //remove a card from the pool of cards showing there front
    public void RemoveFace(int index)
    {
        if(cardOne == index)  //if cardOne has the card up
        {
            //reset cardOne
            cardOne = -1;
            cardsup -= 1;
        }else if (cardTwo == index) //if cardtwo has the card up
        {
            //reset cardTwo
            cardTwo = -1;
            cardsup -= 1;
        }
    }

    public bool isMatching() //checks the 2 cards with front showing, to see if they are the same
    {
        if (cardOne == cardTwo) //if the 2 holders match
        {
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            listOfFinishedCards.Add(cardOne);//add this card to the list of cards already matched
            if(listOfFinishedCards.Count >7) { endGameflag= 1; } //if all the cards have been matched

            //reset
            cardOne = -1;
            cardTwo = -2;
            cardsup = 0;

            return true; //stops this card from being flipped
            
        }else { return false; }//this card can be flipped
    }
    //checks to see if this card front has already been matched
    public bool isAlreadyMatched(int index)
    {
        if (listOfFinishedCards.Contains(index) == true)
        {
            return true;
        }
        else { return false; }
    }
  
    public bool cardsDisplayed() //checks if 2 or more cards are flipped
    {
        if (cardsup >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   
}




