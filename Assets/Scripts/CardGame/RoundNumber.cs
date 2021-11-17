using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundNumber : MonoBehaviour
{
    public int round = 0;
    public void roundUp()
    {
        round++;
    }

    public int getRound()
    {
        return this.round;
    }
}
