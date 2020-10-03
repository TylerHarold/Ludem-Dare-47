using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    // Parents of Puzzles
    private GameObject puzzle_KeycodeParent;

    public int GenerateKeycode()
    {
        return Random.Range(100000, 999999);
    }
}
