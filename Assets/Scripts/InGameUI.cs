using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void ShowMenu()
    { 
        menu.SetActive(true);
    }

    public void Resume()
    {
        menu.SetActive(false);
    }

    public void MainMenu()
    {
        LoadLvl.StartLoad(E_Scenes.Menu);
    }

}
