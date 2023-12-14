using System.Collections.Generic;
using System.Linq;
public class ConditionManager {
    List<ICondition> conditions = new();

    public void AddCondition(ICondition condition) {
        conditions.Add(condition);
    }

    public bool AreAllConditionsMet() {
        return conditions.All(condition => condition.IsMet());
    }
}
