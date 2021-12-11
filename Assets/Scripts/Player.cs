using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string _name;
    private int _handTop = 0 ;
    public Card[] hand = new Card[5];
    // Start is called before the first frame update

    public int handTop { get { return _handTop; } }
    public Player()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void addCard(Card card)
    {
        hand[_handTop] = card;
        _handTop++;
    }

    virtual public int calculateHand()
    {
        int handVal = 0;
        for(int i = 0; i < _handTop; i++)
        {
            // Debug.Log("Hand Top: " + _handTop);
            // Debug.Log("I: " + i);
            if (hand[i].rank == Card.rank_t.ace)
            {
                handVal += 11;
                if (handVal > 21)
                    handVal -= 10;
                continue;
            }
                
            else if (hand[i].rank == Card.rank_t.jack || hand[i].rank == Card.rank_t.queen || hand[i].rank == Card.rank_t.king)
            {
                handVal += 10;
                continue;
            }

            handVal += (int)hand[i].rank;
        }


        return handVal;

    }



}
