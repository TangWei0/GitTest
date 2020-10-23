namespace HashTool.Condition
{
    public static class ConditionFactory
    {
        public static ConditionBase Get()
        {
            if (Conditions.Condition == 0)
                return new CreatCondition();
            else
                return new AnalysisCondition();
        }
    }
}
