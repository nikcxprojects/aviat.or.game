using System;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] ProductType

    public static Action<int, ProductType> OnBuyItem { get; set; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            OnBuyItem?.Invoke(price, )
        });
    }
}
