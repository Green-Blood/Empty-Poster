using System;
using UnityEngine;

namespace Infrastructure
{
    public abstract class State
    {
        
    }
    public sealed class StateMachine
    {
        public GameState GameState { get; private set; }
        public Action OnStateChanged;

        public void NextState()
        {
            GameState++;
            Debug.Log("Next game state " + GameState);
        }
    }
}