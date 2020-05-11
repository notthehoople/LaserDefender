using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Cached References
    Text scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Move this to getting updated whent the score changes instead of every frame
        scoreText.text = gameSession.GetScore().ToString();
    }
}
