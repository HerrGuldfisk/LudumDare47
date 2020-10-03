using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(Controller controller);
    public abstract void Update(Controller controller);
    
    //Add more methods that you want to be able to use in the states here
}
