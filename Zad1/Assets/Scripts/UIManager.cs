using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panelUI;
    [SerializeField] Button startBTN;

    private void Start()
    {
        ShowPanel();
    }

    public void ShowPanel()
    {
        panelUI.SetActive(true);
        startBTN.interactable = false;
    }

    public void HidePanel()
    {
        panelUI.SetActive(false);
    }

    public void ActiveStartBTN()
    {
        startBTN.interactable = true;
    }
}
