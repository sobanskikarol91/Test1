using UnityEngine;
using System.Collections.Generic;

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
