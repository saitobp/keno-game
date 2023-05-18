using System.Collections.Generic;
using UnityEngine;

public class GlobalStateController : MonoBehaviour
{
  // Singleton pattern
  public static GlobalStateController Instance { get; private set; }

  // List of selected items
  public List<int> UserSelection { get; private set; } = new List<int>();

  // The maximum number of items that can be selected
  public int MaxSelection { get; private set; } = 10;

  // Setup the singleton pattern
  void Awake()
  {
    // Ensure that there is only one instance of this class
    if (Instance == null)
    {
      // If not, set the instance to this
      Instance = this;
    }

    if (Instance != null)
    {
      // If there is, destroy this instance
      Destroy(gameObject);
    }
  }

  // Add an item to the user selection
  public void AddToUserSelection(int id)
  {
    UserSelection.Add(id);
  }

  // Remove an item from the user selection
  public void RemoveFromUserSelection(int id)
  {
    UserSelection.Remove(id);
  }
}
