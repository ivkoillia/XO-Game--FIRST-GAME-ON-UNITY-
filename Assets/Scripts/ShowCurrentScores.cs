using UnityEngine;
using TMPro;



class ShowCurrentScores : MonoBehaviour
{
    private TextMeshProUGUI currentScoresText;

    void Awake()
    {
        currentScoresText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateCurrentScoresText();
    }

    void UpdateCurrentScoresText()
    {
        currentScoresText.text = $"Player 1: {SessionDate.CurrentScorePlayer1} | Player 2: {SessionDate.CurrentScorePlayer2}";
    }
}