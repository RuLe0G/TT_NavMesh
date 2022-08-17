using UnityEngine;
/// <summary>
/// Класс менеджер меню
/// </summary>
public class MenuUI : MonoBehaviour
{
    /// <summary>
    /// Выполнить переход на сцену игры
    /// </summary>
    public void MenuStart()
    {
        LoadLvl.StartLoad(E_Scenes.Game);
    }
    /// <summary>
    /// Выйти из приложения
    /// </summary>
    public void MenuExit()
    {
        Application.Quit();
    }

}
