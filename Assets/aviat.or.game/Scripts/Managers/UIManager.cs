using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] GameObject airplanes;
    [SerializeField] GameObject backgrounds;

    [Space(10)]
    [SerializeField] GameObject bet;
    [SerializeField] GameObject cashOut;
    [SerializeField] GameObject cancel;

    [Space(10)]
    [SerializeField] Text bidText;

    private void Awake()
    {
        Airplane.OnStartFly += () =>
        {
            bet.SetActive(false);
            cancel.SetActive(true);
        };

        Airplane.OnGrowing += () =>
        {
            cancel.SetActive(false);
            cashOut.SetActive(true);
        };

        Airplane.OnEndFly += () =>
        {
            cashOut.SetActive(false);
            cancel.SetActive(false);
            bet.SetActive(true);
        };
    }

    private void Start()
    {
        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void OpenShop(int id)
    {
        menu.SetActive(false);
        shop.SetActive(true);

        if (id == 0)
        {
            airplanes.SetActive(true);
            backgrounds.SetActive(false);
        }
        else if (id == 1)
        {
            airplanes.SetActive(false);
            backgrounds.SetActive(true);
        }
    }

    public void Menu()
    {
        Cancel();

        game.SetActive(false);
        shop.SetActive(false);
        menu.SetActive(true);
    }

    public void Game()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }

    public void SetBid(int dir)
    {
        GameManager.Instance.bidCount += dir;
        if (GameManager.Instance.bidCount < 0)
        {
            GameManager.Instance.bidCount = 0;
        }

        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void SetFixedBid(int bid)
    {
        GameManager.Instance.bidCount = bid;
        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void Cancel()
    {
        if (FindObjectOfType<Airplane>())
        {
            FindObjectOfType<Airplane>().ResetMe();
        }
    }
}