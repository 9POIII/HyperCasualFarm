using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int pointsToAdd;
    [SerializeField] private GameObject scoreChanger;
    public int PointsToAdd
    {
        get => pointsToAdd;
        set => pointsToAdd = value;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var iscoreController = IScoreController();

        if (collision.gameObject.CompareTag("Player"))
        {
            iscoreController.AddScore(PointsToAdd);
        }
    }
    
    private IScoreController IScoreController()
    {
        return scoreChanger.GetComponent<IScoreController>();
    }
}
