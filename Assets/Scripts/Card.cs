using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
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
        King = 13
    }


    public suit_t suit;
    public rank_t rank;
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
    public Card(int s, int r)
    {
        suit = (suit_t)s;
        rank = (rank_t)r;
        // Debug.Log((int)suit + " " + rank);
    }

    public Sprite[] spriteArray;
    void Start()
    {

    }

    // Update is called once per frame


    
    void Update()
    {
        
    }



    public void updateSprite(int cardVal, int suite)
    {



    }
}
