using UnityEngine;
/// <summary>
/// ������� ��������� ������
/// </summary>
public class LoadCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            LoadLvl.LoadCallback();
        }
    }
}
