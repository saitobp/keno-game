using System;
using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardButtonController : MonoBehaviour
{
  public int id;

  public bool IsSelected = false;

  [Space(8)]
  [Header("Click Animation")]
  public float ClickAnimationDuration = 0.075f;

  private GameObject UserSelection;

  void Awake()
  {
    UserSelection = GameObject.Find("User Selection");
  }

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
    ClickAnimation();

    var userSelectionValue = GlobalStateController.Instance.UserSelection.Count;
    var maxSelectionValue = GlobalStateController.Instance.MaxSelection;

    // If the user selection is at the maximum, do not allow any more selections
    if (userSelectionValue >= maxSelectionValue)
    {
      return;
    }

    if (IsSelected && GlobalStateController.Instance.UserSelection.Contains(id))
    {
      IsSelected = false;
      GlobalStateController.Instance.RemoveFromUserSelection(id);
      gameObject.GetComponent<Image>().color = new(0.8784f, 0.4784f, 0.3725f, 1.0f);
    }

    else
    {
      IsSelected = true;
      GlobalStateController.Instance.AddToUserSelection(id);
      gameObject.GetComponent<Image>().color = new(0.5059f, 0.6980f, 0.6039f, 1.0f);
    }

    UpdateUserSelection();
  }

  private int ExtractValueFromBrackets(string input)
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

  private void UpdateUserSelection()
  {
    var userSelectionText = UserSelection.GetComponent<TextMeshProUGUI>();
    var userSelectionValue = GlobalStateController.Instance.UserSelection.Count;
    var maxSelectionValue = GlobalStateController.Instance.MaxSelection;

    userSelectionText.text = $"Selected: {userSelectionValue} of {maxSelectionValue}";
  }

  private void ClickAnimation()
  {
    var sequence = DOTween.Sequence();

    sequence.Append(transform.DOScale(0.9f, ClickAnimationDuration));
    sequence.Append(transform.DOScale(1.1f, ClickAnimationDuration));
    sequence.Append(transform.DOScale(1.0f, ClickAnimationDuration));
    sequence.SetEase(Ease.Linear);
  }
}
