using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    private Card[] deck = new Card[52];
    public Transform card;
    // private int offset = 1;
    internal int deckTop = 0;
    // Start is called before the first frame update
    void Awake()
    {
        initDeck();
        shuffleDeck();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
    //Draw Card Function
    
    public Card draw(float xOffset, float yOffset)
    {
        Transform newCard;
        newCard = Instantiate(card, new Vector3(-2 * (xOffset), -15 * (yOffset), 0), Quaternion.identity);
        Card cCard = newCard.GetComponent<Card>();
        cCard.suit = deck[deckTop].suit;
        cCard.rank = deck[deckTop].rank;
        cCard.GetComponent<Animator>().SetBool("isFlip", true);

        deckTop++;
        return cCard;

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
