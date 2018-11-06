using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
	Należy stworzyć prostą scenę, na której cube porusza się pomiędzy punktami.
    Po odpaleniu gry znajdujemy się w trybie edycji, w którym przez kliknięcie lewym , przyciskiem myszki, 
    będzie dodawany punkt we wskazanym miejscu. 
    Gra ta powinna posiadać przycisk "Start", który przenosi nas do trybu animacji. 
    W trybie animacji postać znajduje się w miejscu pierwszego punktu. 
    Gdy trzymamy wciśnięty przycisk spacji postać płynnie przyśpiesza, gdy go puścimy postać płynnie zwalnia, aż do zerowej prędkości.  
*/

public class GameManager : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] GameObject pointPrefab;

    List<Transform> pointsTrans = new List<Transform>();

    IState currentState;
    AnimationMode animationMode;
    EditMode editMode;

    void Start()
    {
        editMode = new EditMode(pointPrefab, ref pointsTrans);
        animationMode = new AnimationMode(ref Player, ref pointsTrans);
        currentState = editMode;
    }

    void Update()
    {
        currentState.Execute();
    }

    public void ChangeToAnimation()
    {
        ChangeState(animationMode);
    }

    void ChangeState(IState state)
    {
        currentState = state;
        state.Enter();
    }

    /*
     * 
     *  */
}