using UnityEngine;
using UnityEngine.UI;



class ResetButton : MonoBehaviour
{
    private Button resetButton;

    void Awake()
    {
        resetButton = GetComponent<Button>();
    }

    void Start()
    {
        resetButton.onClick.AddListener(OnResetButtonClick);
    }

    private void OnResetButtonClick()
    {
        GeneralUtils.RestartCurrentScene();
    }

    void OnDestroy()
    {
        resetButton.onClick.RemoveListener(OnResetButtonClick);
    }
}