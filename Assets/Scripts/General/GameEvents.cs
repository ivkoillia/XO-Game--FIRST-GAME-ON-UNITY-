using System;

public static class GameEvents
{
    public static event Action<uint, uint> OnCellClicked;
    public static event Action OnCellStatementChanged;
    public static event Action OnMoveComplited;
    public static event Action<CellStatement> OnGameOver;

    public static void TriggerCellClicked(uint x, uint y)
    {
        OnCellClicked?.Invoke(x, y);
    }

    public static void TriggerCellStatementChanged()
    {
        OnCellStatementChanged?.Invoke();
    }

    public static void TriggerMoveComplited()
    {
        OnMoveComplited?.Invoke();
    }

    public static void TriggerGameOver(CellStatement winner)
    {
        OnGameOver?.Invoke(winner);
    }
}