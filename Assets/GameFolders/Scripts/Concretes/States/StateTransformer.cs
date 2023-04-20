using Project3.Abstract.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.States
{
    public class StateTransformer
    {
        // sadece cunstroctorda atanabilir demek
        public IState From { get; }
        public IState To { get; }
        public System.Func<bool> Condition { get; }

        public StateTransformer(IState from, IState to, System.Func<bool> condition)
        {
            From = from; 
            To = to;
            Condition = condition;
        }
    }
}
