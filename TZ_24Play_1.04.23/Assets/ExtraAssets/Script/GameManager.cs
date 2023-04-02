using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _warpEffect;
    [SerializeField] private GameObject _tapToPlay;
    [SerializeField] private GameObject _EndGame;

    public static event Action StartGame;
    public static event Action EndGame;
    public static event Action<HeroStackController> InitializeHeroController;
    public static event Action NewTrackGround;
    private void Start()
    {
        _warpEffect.Stop();
    }
    public static void DoStartGame()
    {
        StartGame?.Invoke();
    }
    public static void DoEndGame()
    {
        EndGame?.Invoke();
    }
    public static void DoStack(HeroStackController MainCube)
    {
        InitializeHeroController?.Invoke(MainCube);
    }
    public static void DoNewTrackGround()
    {
        NewTrackGround?.Invoke();
    }
    public void StartGameMethod()
    {
        DoStartGame();
        _warpEffect.Play();
        _tapToPlay.SetActive(false);
    }
    public void EndGameMethod()
    {
        DoEndGame();
        _warpEffect.Stop();
        _EndGame.SetActive(true);
    }
}
