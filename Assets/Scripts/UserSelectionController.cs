using TMPro;
using UnityEngine;

public class UserSelectionController : MonoBehaviour
{
  void Start()
  {
    var userSelectionText = GetComponent<TextMeshProUGUI>();
    var userSelectionValue = GlobalStateController.Instance.UserSelection.Count;
    var maxSelectionValue = GlobalStateController.Instance.MaxSelection;

    userSelectionText.text = $"Selected: {userSelectionValue} of {maxSelectionValue}";
  }
}
