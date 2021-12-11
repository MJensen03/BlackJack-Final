using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Player
{

    private bool _isTurn = false;


    public bool isTurn { set { _isTurn = true; } } 
    public AI() {

    }

    void Start()
    {

    }
    override public int calculateHand()
    {
        int handVal = 0;
        if (!_isTurn)
            return (int)hand[1].rank;
        else
        {
            for (int i = 0; i < handTop; i++)
            {
                // Debug.Log("Hand Top: " + _handTop);
                // Debug.Log("I: " + i);
                if (hand[i].rank == Card.rank_t.ace)
                {
                    handVal += 11;
                    continue;
                }

                else if (hand[i].rank == Card.rank_t.jack || hand[i].rank == Card.rank_t.queen || hand[i].rank == Card.rank_t.king)
                {
                    handVal += 10;
                    continue;
                }

                handVal += (int)hand[i].rank;
            }
        }

       


        return handVal;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
