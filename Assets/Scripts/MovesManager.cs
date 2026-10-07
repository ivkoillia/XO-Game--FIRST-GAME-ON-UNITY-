using UnityEngine;

public enum MovesManagerState
{
    WaitingForPlayerMove,
    CheckingForWin,
    GameOver
}

class MovesManager : MonoBehaviour
{
    public static MovesManager Instance { get; private set; }
    
    public PlayerMove currentPlayerMove { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentPlayerMove = SessionDate.currentStartPlayerMove;

        GameEvents.OnCellStatementChanged += ChangeCurrentPlayerMove;
    }

    void ChangeCurrentPlayerMove()
    {
        currentPlayerMove = currentPlayerMove == PlayerMove.X ? PlayerMove.O : PlayerMove.X;
    
        GameEvents.TriggerMoveComplited();
    }

    void OnDestroy()
    {
        GameEvents.OnCellStatementChanged -= ChangeCurrentPlayerMove;
    }
}