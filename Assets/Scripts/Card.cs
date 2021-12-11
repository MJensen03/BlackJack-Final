using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Animator animator;
    public enum suit_t
    {
        hearts,
        diamonds,
        clubs,
        spades
    };

    public enum rank_t
    {
        ace = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        jack = 11,
        queen = 12,
        king = 13
    }


    private suit_t _suit;
    private rank_t _rank;

    public rank_t rank
    {
        set
        {
            _rank = value;
        }
        get
        {
            return _rank;
        }
    }

    public suit_t suit
    {
        set
        {
            _suit = value;
        }
        get
        {
            return _suit;
        }
    }

    private string toSring(suit_t s)
    {
        switch(s)
        {
            case suit_t.clubs:
                return "clubs";
            case suit_t.diamonds:
                return "Diamonds";
            case suit_t.hearts:
                return "Hearts";
            case suit_t.spades:
                return "Spades";
            default:
                return "N/A";
        }
    }

    Card() { }
    public Card(int suite, int r)
    {
        _suit = (suit_t)suite;
        _rank = (rank_t)r;
    }

    // Update is called once per frame

    private void Start()
    {
        // Debug.Log("Card Suit: " + (int)_suit + " Card Rank: " + _rank);
        animator = GetComponent<Animator>();
        // animator.SetBool("isFlip", true);
        animator.SetInteger("Suit", (int)_suit);
        animator.SetFloat("Card", (float)_rank);
    }


}
