using UnityEngine;
using UnityEngine.UI;
using System;

public class Cell : MonoBehaviour
{

    [ NonSerialized ] public uint x;
    [ NonSerialized ] public uint y;
    [SerializeField] private TMPro.TextMeshProUGUI cellText;
    [NonSerialized] public CellStatement cellStatement;

    private Button cellButton;

    void Awake()
    {
        cellStatement = CellStatement.Nothing;
        cellButton = GetComponent<Button>();
    }

    void Start()
    {
        cellButton.onClick.AddListener(OnButtonClick);
    }

    public void SetCellStatement(CellStatement statement)
    {
        cellStatement = statement;
        
        cellText.text = GeneralUtils.GetCellStatementString(cellStatement);
    }

    private void OnButtonClick()
    {
        if (cellStatement != CellStatement.Nothing)
        {
            return;
        }
        
        GameEvents.TriggerCellClicked(x, y);
    }

    void OnDestroy()
    {
        cellButton.onClick.RemoveListener(OnButtonClick);
    }
}
