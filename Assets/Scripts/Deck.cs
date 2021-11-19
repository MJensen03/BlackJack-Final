using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    internal Card[] deck = new Card[52];
    public Transform card;
    public Human player1;
    private int offset = 1;
    internal int deckTop = 0;
    // Start is called before the first frame update
    void Start()
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
    void OnMouseDown()
    {
        
        Transform newCard;
        if (player1.handSize == 1)
        {
            newCard = Instantiate(card, new Vector3(-2, -5, 0), Quaternion.identity);
            Card cCard = newCard.GetComponent<Card>();
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

    }


    private void initDeck()
    {
        int i = 0; ;
        for(int r = 0; r < 4; r++)
        {
            for(int s = 1; s < 14; s++)
            {
                deck[i] = new Card(r, s);
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
