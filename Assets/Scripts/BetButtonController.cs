using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BetButtonController : MonoBehaviour,
  IPointerClickHandler
{
  public float AnimationDuration = 0.75f;

  public int ShadowOffset = 7;

  private bool CanClick = true;

  void Update()
  {

  }

  public void OnPointerClick(PointerEventData eventData)
  {
    AnimateButton();
  }

  private void AnimateButton()
  {
    if (!CanClick) return;

    var sequence = DOTween.Sequence();

    var x = transform.position.x;
    var y = transform.position.y;
    var z = 0;

    sequence.AppendCallback(() => CanClick = false);
    sequence.Append(transform.DOMove(new Vector3(x + ShadowOffset, y - ShadowOffset, z), AnimationDuration));
    sequence.Append(transform.DOMove(new Vector3(x, y, z), AnimationDuration));
    sequence.AppendCallback(() => AnimateBoard());
    sequence.AppendCallback(() => CanClick = true);
  }

  private void AnimateBoard()
  {

  }
}
