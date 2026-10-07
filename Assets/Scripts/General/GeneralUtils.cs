using UnityEngine;
using UnityEngine.SceneManagement;


class GeneralUtils : MonoBehaviour
{

    public static void ResetCurrentSessionData()
    {
        SessionDate.CurrentScorePlayer1 = 0;
        SessionDate.CurrentScorePlayer2 = 0;
        SessionDate.currentStartPlayerMove = PlayerMove.X;
    }

    public static void RestartCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static string GetCellStatementString(CellStatement cellStatement)
    {
        switch (cellStatement)
        {
            case CellStatement.X:
                return "X";
            case CellStatement.O:
                return "O";
            default:
                return "";
        }
    }

    public static CellStatement GetCellStatementFromPlayerMove(PlayerMove playerMove)
    {
        switch (playerMove)
        {
            case PlayerMove.X:
                return CellStatement.X;
            case PlayerMove.O:
                return CellStatement.O;
            default:
                throw new System.ArgumentException("Invalid PlayerMove value");
        }
    }

    public static PlayerMove GetPlayerMoveFromCellStatement(CellStatement cellStatement)
    {
        switch (cellStatement)
        {
            case CellStatement.X:
                return PlayerMove.X;
            case CellStatement.O:
                return PlayerMove.O;
            default:
                throw new System.ArgumentException("Invalid CellStatement value");
        }
    }
}