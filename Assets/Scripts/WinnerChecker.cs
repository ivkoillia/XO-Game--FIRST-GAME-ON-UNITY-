using UnityEngine;

public class WinnerChecker : MonoBehaviour
{
    public static WinnerChecker Instance { get; private set; }

    private void Awake()
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

    private void OnEnable()
    {
        GameEvents.OnMoveComplited += CheckForWinner;
    }

    private void OnDisable()
    {
        GameEvents.OnMoveComplited -= CheckForWinner;
    }

    private void CheckForWinner()
    {
        Cell[] cells = CellsManager.Instance.cells;
        if (cells == null || cells.Length < 9) return;

        // 1. Проверяем строки и столбцы (3 строки + 3 столбца = 6 линий)
        for (int i = 0; i < 3; i++)
        {
            // Строка i (индексы: i*3, i*3+1, i*3+2)
            if (IsLineWinning(cells[i * 3], cells[i * 3 + 1], cells[i * 3 + 2], out CellStatement rowWinner))
            {
                WinDetected(rowWinner);
                return;
            }

            // Столбец i (индексы: i, i+3, i+6)
            if (IsLineWinning(cells[i], cells[i + 3], cells[i + 6], out CellStatement colWinner))
            {
                WinDetected(colWinner);
                return;
            }
        }

        // 2. Главная диагональ (0, 4, 8)
        if (IsLineWinning(cells[0], cells[4], cells[8], out CellStatement mainDiagWinner))
        {
            WinDetected(mainDiagWinner);
            return;
        }

        // 3. Побочная диагональ (2, 4, 6)
        if (IsLineWinning(cells[2], cells[4], cells[6], out CellStatement subDiagWinner))
        {
            WinDetected(subDiagWinner);
            return;
        }

        // 4. (Опционально) Проверка на ничью, если задействованы все клетки
    }

    private bool IsLineWinning(Cell c1, Cell c2, Cell c3, out CellStatement winner)
    {
        winner = c1.cellStatement;

        if (winner == CellStatement.Nothing)
            return false;

        return winner == c2.cellStatement && winner == c3.cellStatement;
    }

    private void WinDetected(CellStatement winnerCellStatement)
    {
        if (winnerCellStatement == CellStatement.Nothing) return;

        GameEvents.TriggerGameOver(winnerCellStatement);
    }
}