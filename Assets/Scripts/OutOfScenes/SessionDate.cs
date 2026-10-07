using UnityEngine;

[CreateAssetMenu(fileName = "SessionDate", menuName = "Scriptable Objects/SessionDate")]
public class SessionDate : ScriptableObject
{
    public static PlayerMove currentStartPlayerMove = PlayerMove.X;
    public static uint CurrentScorePlayer1 = 0;
    public static uint CurrentScorePlayer2 = 0;

    public static void ResetScores()
    {
        CurrentScorePlayer1 = 0;
        CurrentScorePlayer2 = 0;
    }

    public static void ChangeCurrentStartPlayerMove()
    {
        currentStartPlayerMove = currentStartPlayerMove == PlayerMove.X ? PlayerMove.O : PlayerMove.X;
    }

    public static void AddScoreToPlayer(CellStatement winner)
    {
        if (winner == CellStatement.X && currentStartPlayerMove == PlayerMove.X)
        {
            CurrentScorePlayer1++;
        }
        else if (winner == CellStatement.O && currentStartPlayerMove == PlayerMove.O)
        {
            CurrentScorePlayer1++;
        }
        else if (winner == CellStatement.X && currentStartPlayerMove == PlayerMove.O)
        {
            CurrentScorePlayer2++;
        }
        else if (winner == CellStatement.O && currentStartPlayerMove == PlayerMove.X)
        {
            CurrentScorePlayer2++;
        }
    }
}
