using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefAndOut : MonoBehaviour
{
    public int refScore = 0;
    void Start()
    {
        ModifyScoreRef(ref refScore);
        Debug.Log("refScore: " + refScore);

        ModifyScoreOut(out int outScore);
        Debug.Log("outScore: " + outScore);
        
    }
    public int ModifyScoreRef(ref int score)
    {
        score += 10;
        return score;
    }

    public int ModifyScoreOut(out int outScore)
    {
        outScore = 10;

        return outScore;
    }
}
