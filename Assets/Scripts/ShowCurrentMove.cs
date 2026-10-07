using UnityEngine;
using TMPro;



class ShowCurrentMove : MonoBehaviour
{
    private TextMeshProUGUI currentMoveText;

    void Awake()
    {
        currentMoveText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        GameEvents.OnMoveComplited += UpdateCurrentMoveText;
        UpdateCurrentMoveText();
    }

    void UpdateCurrentMoveText()
    {
        currentMoveText.text = $"Current Move: {MovesManager.Instance.currentPlayerMove}";
    }

    void OnDestroy()
    {
        GameEvents.OnMoveComplited -= UpdateCurrentMoveText;
    }
}