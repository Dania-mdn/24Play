using System;

public class EventManager
{
    public static event Action<HeroStackController> NewGameobjectStack;
    public static event Action Stack;
    public static event Action EndGame;
    public static event Action NewTrackGround;
    public static void DoStack(HeroStackController MainCube)
    {
        NewGameobjectStack?.Invoke(MainCube);
    }
    public static void DoStackComplite()
    {
        Stack?.Invoke();
    }
    public static void DoEndGame()
    {
        EndGame?.Invoke();
    }
    public static void DoNewTrackGround()
    {
        NewTrackGround?.Invoke();
    }
}
