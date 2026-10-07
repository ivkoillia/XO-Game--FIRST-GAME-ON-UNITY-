using UnityEngine;
using UnityEngine.Diagnostics;



class CellsManager : MonoBehaviour
{
    public static CellsManager Instance { get; private set; }

    public Cell[] cells { get; private set; }

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

        cells = GetComponentsInChildren<Cell>();
    }

    void Start()
    {
        uint LineCounter = 0;

        for (uint i = 0; i < cells.Length; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                LineCounter++;
            }

            cells[i].x = i - (LineCounter * 3);
            cells[i].y = LineCounter;
        }

        GameEvents.OnCellClicked += ChangeCellStatement;
    }

    void ChangeCellStatement(uint x, uint y)
    {
        foreach (var cell in cells)
        {
            if (cell.x == x && cell.y == y)
            {
                cell.SetCellStatement( GeneralUtils.GetCellStatementFromPlayerMove(MovesManager.Instance.currentPlayerMove) );

                GameEvents.TriggerCellStatementChanged();

                break;
            }
        }
    }

    void OnDestroy()
    {
        GameEvents.OnCellClicked -= ChangeCellStatement;
    }
}