using UnityEngine;
using UnityEngine.UI;

public class AdsBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    private float _n;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Init(int n)
    {
        _n = n;
        gameObject.SetActive(true);
    }

    public void UpdateBar(float n)
    {
        _image.fillAmount = (_n - n) / _n;
    }
}
