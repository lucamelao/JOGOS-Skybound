using UnityEngine;
using UnityEngine.UI;

public class AdsBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    private float _n;

    public void Init(int n)
    {
        _n = n;
    }

    public void UpdateBar(float n)
    {
        _image.fillAmount = n / _n;
    }
}