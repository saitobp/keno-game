using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    // The game board script
    public GameBoard gameBoard;

    // The game object for the user selection
    public GameObject userSelection;

    // The text component for the user selection
    private TextMeshProUGUI userSelectionText;

    void Start()
    {
        userSelectionText = userSelection.GetComponent<TextMeshProUGUI>();

        userSelectionText.text = userSelectionText.text.Replace(
            oldValue: "{{maxSelection}}",
            newValue: gameBoard.maxSelection.ToString()
        );
    }

    // Update is called once per frame
    void Update()
    {
        userSelectionText.text = userSelectionText.text.Replace(
            oldValue: "{{selection}}",
            newValue: gameBoard.selection.Count.ToString()
        );
    }
}
