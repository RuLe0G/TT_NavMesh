using UnityEngine;
/// <summary>
/// ����� �������� ������������� ����
/// </summary>
public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    /// <summary>
    /// ������� ������������� ����
    /// </summary>
    public void ShowMenu()
    {
        menu.SetActive(true);
    }
    /// <summary>
    /// ������ ������������� ����
    /// </summary>
    public void Resume()
    {
        menu.SetActive(false);
    }
    /// <summary>
    /// ��������� ������� �� ����� �������� ����
    /// </summary>
    public void MainMenu()
    {
        LoadLvl.StartLoad(E_Scenes.Menu);
    }

}
