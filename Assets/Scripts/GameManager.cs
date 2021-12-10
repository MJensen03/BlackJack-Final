using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int offset = 2;
    public Deck deck;
    public GameObject Draw;
    public GameObject Stand;
    public Player player1;
    public Player ai;

    public Text playerScore;
    public GameObject bust;
    public GameObject blackJack;
    private bool aiTurn = false;
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            player1.addCard(deck.draw(i, 1));
            ai.addCard(deck.draw(i, -1));
        }

        if (player1.calculateHand() == 21)
            blackJack.SetActive(true);
        // Debug.Log(ai.hand[1].GetComponent<Animator>().GetBool("isFlip"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiTurn)
            ai.hand[0].GetComponent<Animator>().SetBool("isFlip", false);
        else
            ai.hand[0].GetComponent<Animator>().SetBool("isFlip", true) ;


        playerScore.text = player1.calculateHand().ToString();










    }


    public void hit()
    {

        if (!aiTurn && player1.handTop < 6 && player1.calculateHand() < 21)
        { 
            player1.addCard(deck.draw(offset, 1 / 1.5f));
            offset--;
        }
        if (player1.calculateHand() > 21)
        {
            bust.SetActive(true);

        }


    }
}
