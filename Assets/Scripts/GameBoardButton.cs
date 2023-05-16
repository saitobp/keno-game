using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameBoardButton : MonoBehaviour
{
    public int id;

    public GameObject gameBoard;

    // Start is called before the first frame update
    void Start()
    {
        id = ExtractValueFromBrackets(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log($"Click: {id}");
    }

    private static int ExtractValueFromBrackets(string input)
    {
        var regex = new Regex(@"\[(\d+)\]");
        var match = regex.Match(input);

        if (match.Success)
        {
            var valueString = match.Groups[1].Value;

            if (int.TryParse(valueString, out int value))
            {
                return value;
            }
        }

        throw new ArgumentException("Invalid input format.");
    }
}
