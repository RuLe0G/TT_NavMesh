using UnityEngine;
/// <summary>
/// Класс менеджер внутриигровго меню
/// </summary>
public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    /// <summary>
    /// Вывести внутриигровое меню
    /// </summary>
    public void ShowMenu()
    {
        menu.SetActive(true);
    }
    /// <summary>
    /// Убрать внутриигровое меню
    /// </summary>
    public void Resume()
    {
        menu.SetActive(false);
    }
    /// <summary>
    /// Выполнить переход на сцену главного меню
    /// </summary>
    public void MainMenu()
    {
        LoadLvl.StartLoad(E_Scenes.Menu);
    }

}
