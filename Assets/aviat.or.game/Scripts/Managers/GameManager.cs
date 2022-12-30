using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject PlayerRef { get; set; }
    private GameObject GroundRef { get; set; }


    private GameObject PlayerPrefab { get; set; }
    private GameObject GroundPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    private void Awake()
    {
        PlayerPrefab = Resources.Load<GameObject>("player");
        GroundPrefab = Resources.Load<GameObject>("ground");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void DestroyOld()
    {
        Destroy(PlayerRef);
        Destroy(GroundRef);
    }

    public void StartGame()
    {
        DestroyOld();

        PlayerRef = Instantiate(PlayerPrefab, EnvironmentRef);
        GroundRef = Instantiate(GroundPrefab, EnvironmentRef);
    }
}