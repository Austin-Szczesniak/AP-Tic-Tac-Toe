using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grid_Space : MonoBehaviour {
    private Game_Controller gameController;

    public Button button;
    public Text buttonText;

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }

    public void SetGameControllerReference( Game_Controller controller)
    {
        gameController = controller;
    }
}
