using UnityEngine;
using UnityEngine.UI;



class NewGameButton : MonoBehaviour
{
    private Button newGameButton;

    void Awake()
    {
        newGameButton = GetComponent<Button>();
    }

    void Start()
    {
        newGameButton.onClick.AddListener(OnNewGameButtonClick);
    }

    private void OnNewGameButtonClick()
    {
        GeneralUtils.RestartCurrentScene();
        GeneralUtils.ResetCurrentSessionData();
    }

    void OnDestroy()
    {
        newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
    }
}