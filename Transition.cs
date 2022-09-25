using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition
{
    public GameObject Actor { get; set; }

    public abstract bool Condition();
    
}


