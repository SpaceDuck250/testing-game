using System.Collections.Generic;

public class StateTransitions
{
    IStates transitionstate;

    List<IConditions> conditions;

    public bool ShouldTransition(EnemyContext context)
    {
        foreach (var condition in conditions)
        {
            if (!condition.isMet(context))
            {
                return false;
            }
        }
        return true;
    }
}
