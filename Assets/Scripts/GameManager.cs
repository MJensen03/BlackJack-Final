using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int offset = 2;
    public Deck deck;
    public GameObject draw;
    public GameObject stand;
    public GameObject bust;
    public GameObject blackJack;
    public GameObject reload;
    public GameObject aiBust;
    public GameObject aiBlackJack;
    public GameObject lose;
    public GameObject win;



    public Human player1;
    public AI ai;

    public Text playerScore;
    public Text aiScore;
    private bool aiTurn = false;
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            player1.addCard(deck.draw(i, 1));
            // Debug.Log("What..");
            ai.addCard(deck.draw(i, -1));

        }

        if (player1.calculateHand() == 21)
        {
            blackJack.SetActive(true);
            endGame();
        }
        // Debug.Log(ai.hand[1].GetComponent<Animator>().GetBool("isFlip"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiTurn)
            ai.hand[0].GetComponent<Animator>().SetBool("isFlip", false);
        else
        {
            ai.hand[0].GetComponent<Animator>().SetBool("isFlip", true);
            if(ai.calculateHand() == 21 && ai.handTop < 3)
            {
                aiBlackJack.SetActive(true);
                endGame();
            }
            // Thread.Sleep(2000);
            hit();
        }

        aiScore.text = ai.calculateHand().ToString();
        playerScore.text = player1.calculateHand().ToString();


    }


    private void endGame()
    {
        if(player1.calculateHand() >= ai.calculateHand() && player1.calculateHand() <= 21 || ai.calculateHand() > 21)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
        reload.SetActive(true);
    }

    private void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void endTurn()
    {
        if (aiTurn)
        {
            // isEndGame = true;
            return;
        }
        offset = 2;
        ai.isTurn = true;
        aiTurn = true;
        draw.GetComponent<Button>().interactable = false;
        stand.GetComponent<Button>().interactable = false;
    }

    private void hit()
    {

        if (!aiTurn && player1.handTop < 6 && player1.calculateHand() < 21)
        { 
            player1.addCard(deck.draw(offset, 1 / 1.5f));
            // StartCoroutine(deck.drawCard(player1, player1.handTop - 1 , offset, 1 / 1.5f));

            offset--;
            if (player1.calculateHand() > 21)
            {
                bust.SetActive(true);
                endTurn();
            }
        }


        if (aiTurn && ai.handTop < 6 && ai.calculateHand() < 21)
        {
            if (ai.calculateHand() >= 17)
            {
                endGame();
            }else if(ai.calculateHand() <= 16){
                ai.addCard(deck.draw(offset, -1 / 1.5f));
                offset--;
            }

            if (ai.calculateHand() > 21)
            {
                aiBust.SetActive(true);
                endGame();
            }

        }


    }
}
