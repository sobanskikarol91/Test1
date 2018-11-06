using UnityEngine;
using System.Collections.Generic;

/*
Zad 0.
	Zadanie powinno być zrobione jako osobny projekt. Należy w opcjach edytora ustawić zapisywanie informacji o assetach w plikach meta (Edit -> Project Settings -> Editor, Version Control -> Visible Meta Files). Należy wysłać jedynie spakowane (unitypackage, zip, rar) foldery Assets oraz ProjectSettings, każdego projektu.

Zad 1.
	Należy stworzyć prostą scenę, na której postać (dowolny asset - może być cube, albo inny darmowy asset z Asset Store)     porusza się pomiędzy punktami.

	Po odpaleniu gry znajdujemy się w trybie edycji, w którym przez kliknięcie lewym 
przyciskiem myszki, będzie dodawany punkt we wskazanym miejscu. 

	Gra ta powinna posiadać przycisk "Start", który przenosi nas do trybu animacji.
	W trybie animacji postać znajduje się w miejscu pierwszego punktu. Gdy trzymamy wciśnięty przycisk     spacji postać płynnie przyśpiesza, gdy go puścimy postać płynnie zwalnia, aż do zerowej prędkości. 
	Na zakończenie animacji usuwamy wszystkie punkty i wracamy do edytora. 
*/

public class GameManager : Singleton<GameManager>
{
    public UIManager uiManager;

    [SerializeField] Transform Player;
    [SerializeField] GameObject pointPrefab;

    List<Transform> pointsTrans = new List<Transform>();
    AnimationMode animationMode;
    EditMode editMode;
    StateMachine stateMachine;


    void Start()
    {
        editMode = new EditMode(pointPrefab, ref pointsTrans);
        animationMode = new AnimationMode(ref Player, ref pointsTrans);
        stateMachine = new StateMachine(editMode);
    }

    void Update()
    {
        stateMachine.Execute();
    }

    public void ChangeToAnimation()
    {
        stateMachine.ChangeState(animationMode);
    }

    public void ChangeToEdit()
    {
        stateMachine.ChangeState(editMode);
    }
}
/*
 * usunac niepotrzebne bibliteki
 * 
 */
