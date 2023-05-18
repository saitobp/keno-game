using TMPro;
using UnityEngine;

public class DebugPanelController : MonoBehaviour
{
  public TextMeshProUGUI FpsText;

  // Frequency of the Fps update
  private float pollingTime = 0.1f;

  private float time;

  private int frameCount;

  void Update()
  {
    time += Time.deltaTime;
    frameCount++;

    if (time >= pollingTime)
    {
      var fps = Mathf.RoundToInt(frameCount / time);

      FpsText.text = $"FPS: {fps}";
      time -= pollingTime;
      frameCount = 0;
    }
  }
}
