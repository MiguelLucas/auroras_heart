using UnityEngine;
using System;
using RAIN.Action;
using RAIN.Representation;
using RAIN.Navigation;

[RAINAction("Choose Wander Position")]
public class ChooseWanderPosition : RAINAction
{
    public Expression wanderDistance = new Expression();
    public Expression stayOnGraph = new Expression();
    public Expression wanderTargetVariable = new Expression();
    public Expression retainDirection = new Expression();
    public Expression stepDistance = new Expression();

    private Vector3 lastDirection = new Vector3();
    private Vector3 stepDirection = new Vector3();
    private int stepCount = 0;

    private float _defaultWanderDistance = 10f;
    private float defaultRetainDirection = 0.5f;
    private float defaultStepDistance = 0.5f; 

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        if (!wanderTargetVariable.IsVariable)
            throw new Exception("The Choose Wander Position node requires a valid Wander Target Variable");

        Vector3 tDestination = ai.Kinematic.Position;
        if (stepCount == 0)
        {
            float tWanderDistance = 0f;
            float tRetainDirection = 0f;
            float tStepDistance = 0;

            if (wanderDistance.IsValid)
                tWanderDistance = wanderDistance.Evaluate<float>(ai.DeltaTime, ai.WorkingMemory);
            if (tWanderDistance <= 0f)
                tWanderDistance = _defaultWanderDistance;

            if (retainDirection.IsValid)
                tRetainDirection = retainDirection.Evaluate<float>(ai.DeltaTime, ai.WorkingMemory);
            if (tRetainDirection <= 0)
                tRetainDirection = defaultRetainDirection;

            if (stepDistance.IsValid)
                tStepDistance = stepDistance.Evaluate<float>(ai.DeltaTime, ai.WorkingMemory);
            if (tStepDistance <= 0)
                tStepDistance = defaultStepDistance;

            Vector3 tDirection = Vector3.zero;
            if (UnityEngine.Random.Range(0f, 1f) < tRetainDirection)
                tDirection = lastDirection;
            else
            {
                tDirection.Set(UnityEngine.Random.Range(-1f, 1f), 0f, UnityEngine.Random.Range(-1f, 1f));
                lastDirection = tDirection;
            }

            tDirection *= tWanderDistance;

            float tempSteps = tDirection.magnitude / tStepDistance;
            if (tempSteps > 1.0)
            {
                stepCount = (int)tempSteps;
                tDestination += tDirection - Vector3.ClampMagnitude(tDirection, stepCount);
                stepDirection = Vector3.ClampMagnitude(tDirection, tStepDistance);
                if ((tempSteps % 1) == 0)
                    stepCount--;
            }
            else tDirection += tDirection;
        }
        else
        {
            stepCount--;
            tDestination += stepDirection;
        }
        if (stayOnGraph.IsValid && (stayOnGraph.Evaluate<bool>(ai.DeltaTime, ai.WorkingMemory)))
        {
            if (NavigationManager.Instance.GraphsForPoint(tDestination, ai.Motor.MaxHeightOffset, NavigationManager.GraphType.Navmesh,
                ((BasicNavigator)ai.Navigator).GraphTags).Count == 0)
            {
                return ActionResult.FAILURE;
            }
        }

        ai.WorkingMemory.SetItem<Vector3>(wanderTargetVariable.VariableName, tDestination);

        return ActionResult.SUCCESS;
    }
}