using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    private Vector2 Init { get => new Vector2(-447.9f, -317.2f); }
    private Vector2 Target { get => new Vector2(398, 301); }
    private Image Image { get; set; }
    private void Awake()
    {
        Image = GetComponent<Image>();

        Product.OnProductSelected += (type, id) =>
        {
            if(type == ProductType.Background)
            {
                return;
            }

            PlayerPrefsUtility.SetAirplaneSprite(id);

            Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
            Image.SetNativeSize();
        };

        GameManager.OnGameStarted += () =>
        {
            StartCoroutine(nameof(Fly));
        };
    }

    private void OnEnable()
    {
        Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
        Image.SetNativeSize();
    }

    private IEnumerator Fly()
    {
        float et = 0.0f;
        float duration = Random.Range(2.5f, 4.0f);

        while(et < duration)
        {
            transform.localPosition = Vector2.Lerp(Init, Target, et / duration);

            et += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = Target;

        float rv = Random.Range(5.0f, 10.0f);
        yield return new WaitForSeconds(rv);
        Image.enabled = false;
    }
}
