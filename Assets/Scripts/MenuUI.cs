using UnityEngine;
/// <summary>
/// ����� �������� ����
/// </summary>
public class MenuUI : MonoBehaviour
{
    /// <summary>
    /// ��������� ������� �� ����� ����
    /// </summary>
    public void MenuStart()
    {
        LoadLvl.StartLoad(E_Scenes.Game);
    }
    /// <summary>
    /// ����� �� ����������
    /// </summary>
    public void MenuExit()
    {
        Application.Quit();
    }

}
