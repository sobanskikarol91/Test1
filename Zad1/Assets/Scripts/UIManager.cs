using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panelUI;
    [SerializeField] Button startBTN;


    public void ShowEditPanel()
    {
        panelUI.SetActive(true);
        startBTN.interactable = false;
    }

    public void HideEditPanel()
    {
        panelUI.SetActive(false);
    }

    public void ActiveStartBTN()
    {
        startBTN.interactable = true;
    }
}
