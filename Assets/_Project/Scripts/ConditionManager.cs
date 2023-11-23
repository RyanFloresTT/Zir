using System.Collections.Generic;
using System.Linq;
public class ConditionManager {
    private List<ICondition> conditions = new List<ICondition>();

    public void AddCondition(ICondition condition) {
        conditions.Add(condition);
    }

    public bool AreAllConditionsMet() {
        return conditions.All(condition => condition.IsMet());
    }
}
