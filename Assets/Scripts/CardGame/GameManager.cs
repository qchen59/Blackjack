using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game Buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Text popUp;
    public Button confirm;
    
    public Camera mainCamera;
    public Camera NarrativeCam;

    public int round = 1;
    public int cardValue = 0;

    public bool playerWin = false;
    public bool dealerWin = false;

    private int standClicks = 0;

    // Access the player and dealer's script
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // public Text to access and update - hud
    public Text scoreText;
    public Text dealerScoreText;
    public Text mainText;
    public Text standBtnText;

    // Card hiding dealer's 2nd card
    public GameObject hideCard;
    
    // Cards
    public Sprite[] playerCards;
    public Sprite[] dealerCards;

    public GameObject narrative;
    public GameObject roundOb;
    void Start()
    {
        // Add on click listeners to the buttons
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());

        // Adjust buttons visibility
        dealBtn.gameObject.SetActive(true);
        hitBtn.gameObject.SetActive(false);
        standBtn.gameObject.SetActive(false);


        confirm.onClick.AddListener(confirmClicked);
        


    }


    private void confirmClicked()
    {
        
        narrative.GetComponent<StoryLines>().round = roundOb.GetComponent<RoundNumber>().getRound();
        narrative.GetComponent<StoryLines>().cardValue = this.cardValue;
        //narrative.GetComponent<StoryLines>().dealWin = this.dealerWin;
        //narrative.GetComponent<StoryLines>().playerWin = this.playerWin;
        mainCamera.gameObject.SetActive(false);
        NarrativeCam.gameObject.SetActive(true);
        confirm.gameObject.SetActive(false);
        narrative.GetComponent<StoryLines>().newRound();
    }


    private void DealClicked()
    {
        // Reset round, hide text, prep for new hand
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // Hide deal hand score at start of deal
        dealerScoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // Update the scores displayed
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
        // Place card back on dealer card, hide card
        hideCard.GetComponent<Renderer>().enabled = true;
        // Adjust buttons visibility
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";

        popUp.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);

    }

    private void HitClicked()
    {
        // Check that there is still room on the table
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // Check for winnner and loser, hand is over
    void RoundOver()
    {
        // Booleans (true/false) for bust and blackjack/21
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;
        // If stand has been clicked less than twice, no 21s or busts, quit function
        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        // All bust
        if (playerBust && dealerBust)
        {
            dealerWin = true;
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            confirm.gameObject.SetActive(true);
            mainText.text = "All Bust";
            playerScript.RandomSelect();
        }
        // if player busts, dealer didnt, or if dealer has more points, dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            dealerWin = true;
            confirm.gameObject.SetActive(true);

            mainText.text = "Dealer wins! Dealer will select a card for you.";


            playerScript.RandomSelect();
        }
        // if dealer busts, player didnt, or player has more points, player wins
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            //playerScript.updateStatus();
            playerWin = true;
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            //confirm.gameObject.SetActive(true);
            //print("Is player win? " + playerWin);
            narrative.GetComponent<StoryLines>().setPlayWin();
            //print("Is player win? After " + playerWin);
            mainText.text = "You win! Please select a card.";

        }
        //Check for tie, return bets
        else if (playerScript.handValue == dealerScript.handValue)
        {
            dealerWin = true;
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            mainText.text = "Push";
            confirm.gameObject.SetActive(true);
            playerScript.RandomSelect();
        }
        else
        {
            roundOver = false;
        }
        // Set ui up for next move / hand / turn
        if (dealerWin)
        {
            roundOb.GetComponent<RoundNumber>().roundUp();
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            standClicks = 0;
        }else
        if (playerWin)
        {

            roundOb.GetComponent<RoundNumber>().roundUp();

            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            standClicks = 0;
        }else
        if (roundOver)
        {
            roundOb.GetComponent<RoundNumber>().roundUp();
            narrative.GetComponent<StoryLines>().resetPlayWin();
            //print("the round" + round);
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            standClicks = 0;
        }
    }

}
