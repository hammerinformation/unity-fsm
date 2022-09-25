using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FSM
{

    private GameObject Actor { get; set; }
    private List<State> stateList = new List<State>();
    public State currentState = null;
    private bool isStarted = false;

    public FSM(GameObject Actor)
    {
        this.Actor = Actor;
    }


    public void StartFSM()
    {
        isStarted = true;

        foreach (var item in stateList)
        {
            item.OnStart();
        }

    }
    public void StopFSM()
    {


    }
    public void ChangeState(State state)
    {
        this.currentState.OnExit();
        this.currentState = state;
        this.currentState.OnEnter();

    }
    public void Update()
    {
        if (currentState != null && isStarted)
        {
            currentState.OnUpdate();
            currentState.Check();
        }

    }
    public void SetFirstState(State state)
    {
        this.currentState = state;
        this.currentState.OnEnter();
    }
    public FSM AddState(State state)
    {
        state.Actor = this.Actor;
        state.FSM = this;
        if (stateList.Contains(state) == false)
        {
            state.stateName = state.GetType().ToString();

            foreach (var item in stateList)
            {
                if (item.stateName == state.stateName)
                {
                    return null;

                }
            }
            stateList.Add(state);

        }
        return this;
    }
    public FSM AddTransition(State from, State to, List<Transition> transitionList)
    {
        foreach (var item in transitionList)
        {
            item.Actor = this.Actor;
        }

        from.dictionary.Add(to, transitionList);

        return this;
    }
    

}




