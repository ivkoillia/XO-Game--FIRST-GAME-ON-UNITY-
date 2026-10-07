using UnityEngine;


class WinHandler : MonoBehaviour
{
    public static WinHandler Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        GameEvents.OnGameOver += Win;
    }

    void Win( CellStatement winner )
    {
        if (winner == CellStatement.Nothing)
        {
            return;
        }
        else
        {
            Debug.Log($"Player {GeneralUtils.GetCellStatementString(winner)} won!");

            SessionDate.AddScoreToPlayer(winner);
        }

        SessionDate.ChangeCurrentStartPlayerMove();

        GeneralUtils.RestartCurrentScene();
    }

    void OnDestroy()
    {
        GameEvents.OnGameOver -= Win;
    }
}