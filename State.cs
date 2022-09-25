using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public abstract class State
{
    public string stateName;
    public GameObject Actor { get; set; }
    public FSM FSM { get; set; }

    public Dictionary<State, List<Transition>> dictionary = new Dictionary<State, List<Transition>>();


    public void Check()
    {
        bool b = false;
        int index = 0;
        for (int i = 0; i < dictionary.Count; i++)
        {
            var transitionList = dictionary.ElementAt(i).Value;

            foreach (var item in transitionList)
            {
                if (item.Condition())
                {
                    b = true;
                }
                if (item.Condition() == false)
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                index = i;
                break;
            }

        }

        if (b)
        {

            FSM.ChangeState(dictionary.ElementAt(index).Key);
        }
    }
    public int Get()
    {
        return dictionary.ElementAt(0).Value.Count;
    }
    public State()
    {

        this.stateName = this.GetType().ToString();
    }
    public State(string stateName)
    {
        this.stateName = stateName;
    }

    public void OnStart() { }
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
