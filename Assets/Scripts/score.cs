using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public float record;

    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    void Update()
    {
        scoreText.text = " Score = " + (int)scoreAmount;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

        if(!player)
        {
            pointIncreasedPerSecond = 0f;
        }

    }
}
