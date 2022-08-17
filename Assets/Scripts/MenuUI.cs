using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public void MenuStart()
    {
        LoadLvl.StartLoad(E_Scenes.Game);
    }

    public void MenuExit()
    { 
        Application.Quit();
    }
    
}
