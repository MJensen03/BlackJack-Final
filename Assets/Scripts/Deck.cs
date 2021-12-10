using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    private Card[] deck = new Card[52];
    public Transform card;
    public Human player1;
    // private int offset = 1;
    internal int deckTop = 0;
    // Start is called before the first frame update
    void Awake()
    {
        initDeck();
        shuffleDeck();
        for(int i = 0; i < 52; i++)
        {
            Debug.Log(deck[i].rank + " " + deck[i].suit);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    //Draw Card Function
    public Card draw(float xOffset, float yOffset)
    {
        
        Transform newCard;
        newCard = Instantiate(card, new Vector3(-2*(xOffset), -15 * (yOffset), 0), Quaternion.identity);
        Card cCard = newCard.GetComponent<Card>();
        // Debug.Log(deck[deckTop]);
        cCard.suit = deck[deckTop].suit;
        cCard.rank = deck[deckTop].rank;
        cCard.GetComponent<Animator>().SetBool("isFlip", true);

        deckTop++;
        return cCard;

        /*
        if (player1.handSize == 1)
        {
            newCard = Instantiate(card, new Vector3(-2, -5, 0), Quaternion.identity);
            Card cCard = newCard.GetComponent<Card>();
            Debug.Log(deck[deckTop]);
            cCard.suit = deck[deckTop].suit;
            cCard.rank = deck[deckTop].rank;
            player1.handSize++;
            deckTop++;

        }
        else if(player1.handSize == 2)
        {
            newCard = Instantiate(card, new Vector3(2, -5, 0), Quaternion.identity);
            Card cCard = newCard.GetComponent<Card>();
            cCard.suit = deck[deckTop].suit;
            cCard.rank = deck[deckTop].rank;
            player1.handSize++;
            deckTop++;
        }
        else if(player1.handSize > 2 && player1.handSize < 6)
        {
            newCard = Instantiate(card, new Vector3(-4 * offset, -1, 0), Quaternion.identity);
            Card cCard = newCard.GetComponent<Card>();
            cCard.suit = deck[deckTop].suit;
            cCard.rank = deck[deckTop].rank;
            player1.handSize++;
            deckTop++;
            offset--;
        }
        */
    }


    private void initDeck()
    {
        int i = 0; ;
        for(int s = 0; s < 4; s++)
        {
            for(int r = 1; r < 14; r++)
            {
                deck[i] = new Card(s, r);
                i++;
            }
        }


    }


    private void shuffleDeck()
    {
        int end = 52;
        Card temp;
        for(int i = 0; i < end; i++)
        {
            int rand = Random.Range(0, end);
            temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }


}
