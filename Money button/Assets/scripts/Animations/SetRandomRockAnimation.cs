using UnityEngine;
using UnityEngine.UI;

public class SetRandomRockAnimation : MonoBehaviour
{
    [SerializeField] private Image _viewSprite;
    [SerializeField] private Sprite[] _randomsSkins;

    public void SetRandom()
    {
        _viewSprite.sprite = _randomsSkins[Random.Range(0, _randomsSkins.Length - 1)];
    }
}
