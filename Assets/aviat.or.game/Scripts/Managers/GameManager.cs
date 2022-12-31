using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public static Action OnGameStarted { get; set; }

    public int bidCount;

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }
}