using UnityEngine;
using UnityEngine.UI;

public class WorkerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite _secondFrame;
    [SerializeField] private Image _viewSprite;
    [SerializeField] private ParticleSystem _muzzle;

    private Sprite _currectSprite;

    private void Start()
    {
        _currectSprite = _viewSprite.sprite;
    }

    public void SetDefaultFrame()
    {
        _viewSprite.sprite = _currectSprite;
    }

    public void SetSecondFrame()
    {
        _muzzle.Play();
        _viewSprite.sprite = _secondFrame;
    }
}
