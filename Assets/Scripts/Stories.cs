using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stories : MonoBehaviour
{



    // Templete { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    // Templete round 5 { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self"};

    private string[] cardRound1 = new string[13] { "You are in a casino.", "2", "You are in an amusement park.", "4", "5", "6", "7", "8", "9", "10", "You are in a movie theatre.", "Q", "K" };
    private string[] cardRound2 = new string[13] { "A", "You are a doctor in your late thirties.", "3", "4", "5", "6", "You are an NCSU student.", "8", "9", "You are a lift operator.", "J", "Q", "K" };
    private string[] cardRound3S1 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };
    private string[] cardRound3S2 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };
    private string[] cardRound3S3 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };


    public string GetStory(int value, int round)
    {
        if(round == 1)
        {
            return cardRound1[value];
        }
        if (round == 2)
        {
            return cardRound1[value];
        }
        return "stories";
    }
}
