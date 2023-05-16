using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // The button prefab
    public GameObject prefab;

    // The size of the board
    public int boardSize = 80;

    // The max number of selection
    public int maxSelection = 10;

    // The quantity of numbers selected
    public List<int> selection = new();

    // Updates the board using the prefab
    public void UpdateBoard()
    {
        // Get all the children element (if any)
        // and remove it before creating new ones
        int childCount = gameObject.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            var child = gameObject.transform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }

        // Instantiate a new button based on the prefab
        // and add it to the game object as a chilren element
        for (var i = 1; i <= boardSize; i++)
        {
            var button = Instantiate(prefab, transform);

            button.name = $"Game Board Button [{i}]";
        }
    }
}

[CustomEditor(typeof(GameBoard))]
public class GameBoardEditor: Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var gameBoard= (GameBoard)target;

        // Add an space between the public properties
        // of the script and the button
        GUILayout.Space(8);

        // Add the 'Update Board' button to the inspector
        if (GUILayout.Button("Update Board"))
        {
            gameBoard.UpdateBoard();
        }
    }
}