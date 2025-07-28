
using System.Collections.Generic;

public interface IStates
{
    void Init(BaseEnemy baseenemy);

    void Act(EnemyContext context);

    List<StateTransitions> transitions { get; set; }


}
