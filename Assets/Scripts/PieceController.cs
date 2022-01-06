using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    private Dice _dice;
    void Start()
    {
        _dice = FindObjectOfType<Dice>();
    }

    void Update()
    {
        
    }
}
