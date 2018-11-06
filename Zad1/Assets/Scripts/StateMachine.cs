public class StateMachine
{
    IState currentState;

    public StateMachine(IState state)
    {
        currentState = state;
    }

    public void ChangeState(IState state)
    {
        currentState.Exit();
        currentState = state;
        state.Enter();
    }

    public void Execute()
    {
        currentState.Execute();
    }
}
