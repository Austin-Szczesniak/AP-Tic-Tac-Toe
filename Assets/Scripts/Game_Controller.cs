using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

 
/// <summary>
///  THINGS I WANT TO DO
/// - Add cats game for mini square
/// - Fix the draw game bug
/// - Add themes
/// - Add ads
/// - Add instruction menu
/// - Add Themes menu
/// - Fix broken square (Bottom Left Big- bottom right mini)
/// </summary>

public class Game_Controller : MonoBehaviour
{
    // CONSTS
    const int MAX_MOVES = 81;

    // Scoring
    public Text[] scoreText;

    // End Game
    public GameObject gameOverPanel;
    public Text gameOverText;

    // Square choosing
    public GameObject[] hiddenPanels;
    public GameObject[] ownershipPanel;
    public Text[] ownershipText;
    public Text turnText;

    // Buttons
    public Text[] topLeftButtons;
    public Text[] topMidButtons;
    public Text[] topRightButtons;
    public Text[] midLeftButtons;
    public Text[] midMidButtons;
    public Text[] midRightButtons;
    public Text[] botLeftButtons;
    public Text[] botMidButtons;
    public Text[] botRightButtons;

    // Private parts (*_*)
    private int xScore;
    private int yScore;
    private int moveCount;
    private string playerSide;

    // Xx______METHODS______xX

    // Called at game start, sets up the game for first run
    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
        //Start Score is -1
        xScore = -1;
        yScore = -1;
        AddScore("X");
        AddScore("Y");

        gameOverPanel.SetActive(false);
        gameOverText.text = "";

        for (int i = 0; i < ownershipPanel.Length; i++)
        {
            ownershipPanel[i].SetActive(false);
        }
        for (int i = 0; i < hiddenPanels.Length; i++)
        {
            hiddenPanels[i].SetActive(true);
        }
        hiddenPanels[4].SetActive(false);

    }

    // Lets the buttons be clicked
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            topLeftButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            topMidButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            topRightButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);

            midLeftButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            midMidButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            midRightButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);

            botLeftButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            botMidButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
            botRightButtons[i].GetComponentInParent<Grid_Space>().SetGameControllerReference(this);
        }
    }

    // Returns whose turn it is
    public string GetPlayerSide()
    {
        return playerSide;
    }

    // Super large amount of if statements, I suggest not opening this
    public void EndTurn()
    {
        // Check Top Left
        // ROWS
        if (topLeftButtons[0].text == playerSide && topLeftButtons[1].text == playerSide && topLeftButtons[2].text == playerSide)
        {
            OwnSquare(0);
        }
        else if (topLeftButtons[3].text == playerSide && topLeftButtons[4].text == playerSide && topLeftButtons[5].text == playerSide)
        {
            OwnSquare(0);
        }
        else if (topLeftButtons[6].text == playerSide && topLeftButtons[7].text == playerSide && topLeftButtons[8].text == playerSide)
        {
            OwnSquare(0);
        }
        // COLUMNS
        else if (topLeftButtons[0].text == playerSide && topLeftButtons[3].text == playerSide && topLeftButtons[6].text == playerSide)
        {
            OwnSquare(0);
        }
        else if (topLeftButtons[1].text == playerSide && topLeftButtons[4].text == playerSide && topLeftButtons[7].text == playerSide)
        {
            OwnSquare(0);
        }
        else if (topLeftButtons[2].text == playerSide && topLeftButtons[5].text == playerSide && topLeftButtons[8].text == playerSide)
        {
            OwnSquare(0);
        }
        // DIAGONALS
        else if (topLeftButtons[0].text == playerSide && topLeftButtons[4].text == playerSide && topLeftButtons[8].text == playerSide)
        {
            OwnSquare(0);
        }
        else if (topLeftButtons[2].text == playerSide && topLeftButtons[4].text == playerSide && topLeftButtons[6].text == playerSide)
        {
            OwnSquare(0);
        }
        // Check Top Middle
        // ROWS
        if (topMidButtons[0].text == playerSide && topMidButtons[1].text == playerSide && topMidButtons[2].text == playerSide)
        {
            OwnSquare(1);
        }
        else if (topMidButtons[3].text == playerSide && topMidButtons[4].text == playerSide && topMidButtons[5].text == playerSide)
        {
            OwnSquare(1);
        }
        else if (topMidButtons[6].text == playerSide && topMidButtons[7].text == playerSide && topMidButtons[8].text == playerSide)
        {
            OwnSquare(1);
        }
        // COLUMNS
        else if (topMidButtons[0].text == playerSide && topMidButtons[3].text == playerSide && topMidButtons[6].text == playerSide)
        {
            OwnSquare(1);
        }
        else if (topMidButtons[1].text == playerSide && topMidButtons[4].text == playerSide && topMidButtons[7].text == playerSide)
        {
            OwnSquare(1);
        }
        else if (topMidButtons[2].text == playerSide && topMidButtons[5].text == playerSide && topMidButtons[8].text == playerSide)
        {
            OwnSquare(1);
        }
        // DIAGONALS
        else if (topMidButtons[0].text == playerSide && topMidButtons[4].text == playerSide && topMidButtons[8].text == playerSide)
        {
            OwnSquare(1);
        }
        else if (topMidButtons[2].text == playerSide && topMidButtons[4].text == playerSide && topMidButtons[6].text == playerSide)
        {
            OwnSquare(1);
        }
        // Check Top Right
        // ROWS
        if (topRightButtons[0].text == playerSide && topRightButtons[1].text == playerSide && topRightButtons[2].text == playerSide)
        {
            OwnSquare(2);
        }
        else if (topRightButtons[3].text == playerSide && topRightButtons[4].text == playerSide && topRightButtons[5].text == playerSide)
        {
            OwnSquare(2);
        }
        else if (topRightButtons[6].text == playerSide && topRightButtons[7].text == playerSide && topRightButtons[8].text == playerSide)
        {
            OwnSquare(2);
        }
        // COLUMNS
        else if (topRightButtons[0].text == playerSide && topRightButtons[3].text == playerSide && topRightButtons[6].text == playerSide)
        {
            OwnSquare(2);
        }
        else if (topRightButtons[1].text == playerSide && topRightButtons[4].text == playerSide && topRightButtons[7].text == playerSide)
        {
            OwnSquare(2);
        }
        else if (topRightButtons[2].text == playerSide && topRightButtons[5].text == playerSide && topRightButtons[8].text == playerSide)
        {
            OwnSquare(2);
        }
        // DIAGONALS
        else if (topRightButtons[0].text == playerSide && topRightButtons[4].text == playerSide && topRightButtons[8].text == playerSide)
        {
            OwnSquare(2);
        }
        else if (topRightButtons[2].text == playerSide && topRightButtons[4].text == playerSide && topRightButtons[6].text == playerSide)
        {
            OwnSquare(2);
        }
        // Check Middle Left
        // ROWS
        if (midLeftButtons[0].text == playerSide && midLeftButtons[1].text == playerSide && midLeftButtons[2].text == playerSide)
        {
            OwnSquare(3);
        }
        else if (midLeftButtons[3].text == playerSide && midLeftButtons[4].text == playerSide && midLeftButtons[5].text == playerSide)
        {
            OwnSquare(3);
        }
        else if (midLeftButtons[6].text == playerSide && midLeftButtons[7].text == playerSide && midLeftButtons[8].text == playerSide)
        {
            OwnSquare(3);
        }
        // COLUMNS
        else if (midLeftButtons[0].text == playerSide && midLeftButtons[3].text == playerSide && midLeftButtons[6].text == playerSide)
        {
            OwnSquare(3);
        }
        else if (midLeftButtons[1].text == playerSide && midLeftButtons[4].text == playerSide && midLeftButtons[7].text == playerSide)
        {
            OwnSquare(3);
        }
        else if (midLeftButtons[2].text == playerSide && midLeftButtons[5].text == playerSide && midLeftButtons[8].text == playerSide)
        {
            OwnSquare(3);
        }
        // DIAGONALS
        else if (midLeftButtons[0].text == playerSide && midLeftButtons[4].text == playerSide && midLeftButtons[8].text == playerSide)
        {
            OwnSquare(3);
        }
        else if (midLeftButtons[2].text == playerSide && midLeftButtons[4].text == playerSide && midLeftButtons[6].text == playerSide)
        {
            OwnSquare(3);
        }
        // Check Middle Middle
        // ROWS
        if (midMidButtons[0].text == playerSide && midMidButtons[1].text == playerSide && midMidButtons[2].text == playerSide)
        {
            OwnSquare(4);
        }
        else if (midMidButtons[3].text == playerSide && midMidButtons[4].text == playerSide && midMidButtons[5].text == playerSide)
        {
            OwnSquare(4);
        }
        else if (midMidButtons[6].text == playerSide && midMidButtons[7].text == playerSide && midMidButtons[8].text == playerSide)
        {
            OwnSquare(4);
        }
        // COLUMNS
        else if (midMidButtons[0].text == playerSide && midMidButtons[3].text == playerSide && midMidButtons[6].text == playerSide)
        {
            OwnSquare(4);
        }
        else if (midMidButtons[1].text == playerSide && midMidButtons[4].text == playerSide && midMidButtons[7].text == playerSide)
        {
            OwnSquare(4);
        }
        else if (midMidButtons[2].text == playerSide && midMidButtons[5].text == playerSide && midMidButtons[8].text == playerSide)
        {
            OwnSquare(4);
        }
        // DIAGONALS
        else if (midMidButtons[0].text == playerSide && midMidButtons[4].text == playerSide && midMidButtons[8].text == playerSide)
        {
            OwnSquare(4);
        }
        else if (midMidButtons[2].text == playerSide && midMidButtons[4].text == playerSide && midMidButtons[6].text == playerSide)
        {
            OwnSquare(4);
        }
        // Check Middle Right
        // ROWS
        if (midRightButtons[0].text == playerSide && midRightButtons[1].text == playerSide && midRightButtons[2].text == playerSide)
        {
            OwnSquare(5);
        }
        else if (midRightButtons[3].text == playerSide && midRightButtons[4].text == playerSide && midRightButtons[5].text == playerSide)
        {
            OwnSquare(5);
        }
        else if (midRightButtons[6].text == playerSide && midRightButtons[7].text == playerSide && midRightButtons[8].text == playerSide)
        {
            OwnSquare(5);
        }
        // COLUMNS
        else if (midRightButtons[0].text == playerSide && midRightButtons[3].text == playerSide && midRightButtons[6].text == playerSide)
        {
            OwnSquare(5);
        }
        else if (midRightButtons[1].text == playerSide && midRightButtons[4].text == playerSide && midRightButtons[7].text == playerSide)
        {
            OwnSquare(5);
        }
        else if (midRightButtons[2].text == playerSide && midRightButtons[5].text == playerSide && midRightButtons[8].text == playerSide)
        {
            OwnSquare(5);
        }
        // DIAGONALS
        else if (midRightButtons[0].text == playerSide && midRightButtons[4].text == playerSide && midRightButtons[8].text == playerSide)
        {
            OwnSquare(5);
        }
        else if (midRightButtons[2].text == playerSide && midRightButtons[4].text == playerSide && midRightButtons[6].text == playerSide)
        {
            OwnSquare(5);
        }
        // Check Bottom Left
        // ROWS
        if (botLeftButtons[0].text == playerSide && botLeftButtons[1].text == playerSide && botLeftButtons[2].text == playerSide)
        {
            OwnSquare(6);
        }
        else if (botLeftButtons[3].text == playerSide && botLeftButtons[4].text == playerSide && botLeftButtons[5].text == playerSide)
        {
            OwnSquare(6);
        }
        else if (botLeftButtons[6].text == playerSide && botLeftButtons[7].text == playerSide && botLeftButtons[8].text == playerSide)
        {
            OwnSquare(6);
        }
        // COLUMNS
        else if (botLeftButtons[0].text == playerSide && botLeftButtons[3].text == playerSide && botLeftButtons[6].text == playerSide)
        {
            OwnSquare(6);
        }
        else if (botLeftButtons[1].text == playerSide && botLeftButtons[4].text == playerSide && botLeftButtons[7].text == playerSide)
        {
            OwnSquare(6);
        }
        else if (botLeftButtons[2].text == playerSide && botLeftButtons[5].text == playerSide && botLeftButtons[8].text == playerSide)
        {
            OwnSquare(6);
        }
        // DIAGONALS
        else if (botLeftButtons[0].text == playerSide && botLeftButtons[4].text == playerSide && botLeftButtons[8].text == playerSide)
        {
            OwnSquare(6);
        }
        else if (botLeftButtons[2].text == playerSide && botLeftButtons[4].text == playerSide && botLeftButtons[6].text == playerSide)
        {
            OwnSquare(6);
        }
        // Check Bottom Middle
        // ROWS
        if (botMidButtons[0].text == playerSide && botMidButtons[1].text == playerSide && botMidButtons[2].text == playerSide)
        {
            OwnSquare(7);
        }
        else if (botMidButtons[3].text == playerSide && botMidButtons[4].text == playerSide && botMidButtons[5].text == playerSide)
        {
            OwnSquare(7);
        }
        else if (botMidButtons[6].text == playerSide && botMidButtons[7].text == playerSide && botMidButtons[8].text == playerSide)
        {
            OwnSquare(7);
        }
        // COLUMNS
        else if (botMidButtons[0].text == playerSide && botMidButtons[3].text == playerSide && botMidButtons[6].text == playerSide)
        {
            OwnSquare(7);
        }
        else if (botMidButtons[1].text == playerSide && botMidButtons[4].text == playerSide && botMidButtons[7].text == playerSide)
        {
            OwnSquare(7);
        }
        else if (botMidButtons[2].text == playerSide && botMidButtons[5].text == playerSide && botMidButtons[8].text == playerSide)
        {
            OwnSquare(7);
        }
        // DIAGONALS
        else if (botMidButtons[0].text == playerSide && botMidButtons[4].text == playerSide && botMidButtons[8].text == playerSide)
        {
            OwnSquare(7);
        }
        else if (botMidButtons[2].text == playerSide && botMidButtons[4].text == playerSide && botMidButtons[6].text == playerSide)
        {
            OwnSquare(7);
        }
        // Check Bottom Right
        // ROWS
        if (botRightButtons[0].text == playerSide && botRightButtons[1].text == playerSide && botRightButtons[2].text == playerSide)
        {
            OwnSquare(8);
        }
        else if (botRightButtons[3].text == playerSide && botRightButtons[4].text == playerSide && botRightButtons[5].text == playerSide)
        {
            OwnSquare(8);
        }
        else if (botRightButtons[6].text == playerSide && botRightButtons[7].text == playerSide && botRightButtons[8].text == playerSide)
        {
            OwnSquare(8);
        }
        // COLUMNS
        else if (botRightButtons[0].text == playerSide && botRightButtons[3].text == playerSide && botRightButtons[6].text == playerSide)
        {
            OwnSquare(8);
        }
        else if (botRightButtons[1].text == playerSide && botRightButtons[4].text == playerSide && botRightButtons[7].text == playerSide)
        {
            OwnSquare(8);
        }
        else if (botRightButtons[2].text == playerSide && botRightButtons[5].text == playerSide && botRightButtons[8].text == playerSide)
        {
            OwnSquare(8);
        }
        // DIAGONALS
        else if (botRightButtons[0].text == playerSide && botRightButtons[4].text == playerSide && botRightButtons[8].text == playerSide)
        {
            OwnSquare(8);
        }
        else if (botRightButtons[2].text == playerSide && botRightButtons[4].text == playerSide && botRightButtons[6].text == playerSide)
        {
            OwnSquare(8);
        }   

        ChangeSides();
        CheckDraw();

        // Hide non available sides
        for (int i = 0; i < MAX_MOVES; i++)
        {
            //topLeftButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); } );
            //topMidButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
            //topRightButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });

            //midLeftButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
            //midMidButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
            //midRightButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });

            //botLeftButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
            //botMidButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
            //botRightButtons[i].GetComponentInParent<Button>().onClick.AddListener(delegate { ChangeSquare(i); });
        }
    }

    // Flips sides
    void ChangeSides()
    {
        EndGame();
        playerSide = (playerSide == "X") ? "O" : "X";
        turnText.text = playerSide;
    }

    // Decides Which square is playable
    public void ChangeSquare(int square)
    { 
       if (ownershipText[square].text == "X" || ownershipText[square].text == "O")
        {
            for (int i = 0; i < hiddenPanels.Length; i++)
            {
                hiddenPanels[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < hiddenPanels.Length; i++)
            {
                hiddenPanels[i].SetActive(true);
            }

            hiddenPanels[square].SetActive(false);
        }
    }

    // Gives ownership to squares
    void OwnSquare(int square)
    {
        ownershipPanel[square].SetActive(true);
        ownershipText[square].text = playerSide;
    }

    // checks to see if max moves have been played
    void CheckDraw()
    {
        if (moveCount >= MAX_MOVES)
        {
            playerSide = "Nobody";
            EndGame();
        }
    }

    // Allows for rapid reset of boards
    void SetBoardSetting(bool toggle)
    {
        for (int i = 0; i < 9; i++)
        {
            topLeftButtons[i].GetComponentInParent<Button>().interactable = toggle;
            topMidButtons[i].GetComponentInParent<Button>().interactable = toggle;
            topRightButtons[i].GetComponentInParent<Button>().interactable = toggle;

            midLeftButtons[i].GetComponentInParent<Button>().interactable = toggle;
            midMidButtons[i].GetComponentInParent<Button>().interactable = toggle;
            midRightButtons[i].GetComponentInParent<Button>().interactable = toggle;

            botLeftButtons[i].GetComponentInParent<Button>().interactable = toggle;
            botMidButtons[i].GetComponentInParent<Button>().interactable = toggle;
            botRightButtons[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    // Checks big squares for a win
    void EndGame()
    {
        // Check Big Squares
        // ROWS
        if (ownershipText[0].text == playerSide && ownershipText[1].text == playerSide && ownershipText[2].text == playerSide)
        {
            setWinText();    
        }
        else if (ownershipText[3].text == playerSide && ownershipText[4].text == playerSide && ownershipText[5].text == playerSide)
        {
            setWinText();
        }
        else if (ownershipText[6].text == playerSide && ownershipText[7].text == playerSide && ownershipText[8].text == playerSide)
        {
            setWinText();
        }
        // COLUMNS
        else if (ownershipText[0].text == playerSide && ownershipText[3].text == playerSide && ownershipText[6].text == playerSide)
        {
            setWinText();
        }
        else if (ownershipText[1].text == playerSide && ownershipText[4].text == playerSide && ownershipText[7].text == playerSide)
        {
            setWinText();
        }
        else if (ownershipText[2].text == playerSide && ownershipText[5].text == playerSide && ownershipText[8].text == playerSide)
        {
            setWinText();
        }
        // DIAGONALS
        else if (ownershipText[0].text == playerSide && ownershipText[4].text == playerSide && ownershipText[8].text == playerSide)
        {
            setWinText();
        }
        else if (ownershipText[2].text == playerSide && ownershipText[4].text == playerSide && ownershipText[6].text == playerSide)
        {
            setWinText();
        }
    }

    // Declares a winner
    void setWinText()
    {
        AddScore(playerSide);
        gameOverPanel.SetActive(true);
        gameOverText.text = playerSide + " WINS";
    }

    // Adds score to winner
    void AddScore(string winner)
    {
        if (winner == "X")
        {
            xScore++;
            scoreText[0].text = "X: " + xScore.ToString();
        }
        else
        {
            yScore++;
            scoreText[1].text = "O: " + yScore.ToString();
        }
    }

    // Xx_______CONTROLS_______xX
    // Restarts the game....
    public void RestartGame()
    {
        for (int i = 0; i < 9; i++)
        {
            topLeftButtons[i].text = "";
            topMidButtons[i].text = "";
            topRightButtons[i].text = "";

            midLeftButtons[i].text = "";
            midMidButtons[i].text = "";
            midRightButtons[i].text = "";

            botLeftButtons[i].text = "";
            botMidButtons[i].text = "";
            botRightButtons[i].text = "";

            ownershipText[i].text = "";
            ownershipPanel[i].SetActive(false);
        }

        for (int i = 0; i < hiddenPanels.Length; i++)
        {
            hiddenPanels[i].SetActive(true);
        }
        hiddenPanels[4].SetActive(false);

        gameOverPanel.SetActive(false);
        gameOverText.text = "";

        SetBoardSetting(true);
        playerSide = "X";
        moveCount = 0;
    }

    // Goes to title screen.....
    public void GoToTitle()
    {
        SceneManager.LoadScene("Scenes/Title");
    }

    // Exits the game..............................
    public void ExitGame()
    {
        Application.Quit();
    }
}