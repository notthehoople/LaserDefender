using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // Cached References
    Text healthText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Move this to getting updated whent the score changes instead of every frame
        healthText.text = player.GetHealth().ToString();
    }
}
