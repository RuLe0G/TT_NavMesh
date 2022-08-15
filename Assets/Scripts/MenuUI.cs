using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public void menuStart()
    {
        LoadLvl.StartLoad(E_Scenes.Game);
    }

    public void menuExit()
    { 
        Application.Quit();
    }
    
}
