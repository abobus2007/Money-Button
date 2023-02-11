using UnityEngine;
using TMPro;

public class ViewTextClickMechanickAniamtion : MonoBehaviour
{
    private bool _moving;
    private Vector2 _moveDirection;
    [SerializeField] private TMP_Text _countValue;
    [SerializeField] private Animator _animation;

    private void Start()
    {
        StopMotion();
    }

    private void Update()
    {
        if (_moving != true)
        {
            return;
        }

        transform.Translate(_moveDirection * Time.deltaTime);
    }

    public void StartMotion(float countAddMoney)
    {
        transform.localPosition = Vector2.zero;
        _countValue.text = "+" + ParametrView.ConvertToViewValue(countAddMoney);
        _moveDirection = new Vector2(0, 1.5f);
        _animation.Play("TextAnimation");
        _moving = true;
    }

    public void StopMotion()
    {
        _moving = false;
    }
}
