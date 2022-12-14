using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin.FSM
{
    public class StateMachine<T> where T : struct, IConvertible, IComparable, IFormattable
    {
        private Dictionary<T, State<T>> states;
        public T CurrentStateID;

        private State<T> CurrentState
        {
            get
            {
                return this.states[this.CurrentStateID];
            }
        }

        public StateMachine(State<T>[] states, T initialStateID)
        {
            this.Initialize(states, initialStateID);
        }

        /// <summary>
        /// 变更状态
        /// </summary>
        /// <param name="desiredStateID"></param>
        public void ChangeState(T desiredStateID)
        {
            // Can't exit and re-enter the same state
            if (desiredStateID.Equals(this.CurrentStateID))
            {
                return;
            }

            this.CurrentState.Exit();
            this.CurrentStateID = desiredStateID;
            this.CurrentState.Enter();
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            this.CurrentState.Update(deltaTime);
        }

        /// <summary>
        /// 初始化状态机
        /// </summary>
        /// <param name="states"></param>
        /// <param name="initialStateID"></param>
        private void Initialize(State<T>[] states, T initialStateID)
        {
            this.VerifyTIsEnum();
            this.VerifyStatesRepresentAllEntriesOfT(states);

            this.states = new Dictionary<T, State<T>>();
            foreach (var state in states)
            {
                this.states.Add(state.ID, state);
            }

            this.CurrentStateID = initialStateID;
            this.CurrentState.Enter();
        }

        /// <summary>
        /// 验证是否为枚举
        /// </summary>
        private void VerifyTIsEnum()
        {
            if (!typeof(T).IsEnum)
            {
                var message = string.Concat(
                    "StateMachine trying to initialize with an invalid generic type. " +
                    "Generic type (T) is not an Enum. Type: " + typeof(T).ToString());
                throw new System.ArgumentException(message);
            }
        }

        private void VerifyStatesRepresentAllEntriesOfT(State<T>[] states)
        {
            this.VerifyStatesArentMissing(states);
            this.VerifyNoStatesAreDuplicates(states);
        }

        private void VerifyStatesArentMissing(State<T>[] states)
        {
            return;
            var missingEntries = GetMissingIDs(states);
            if (missingEntries.Length > 0)
            {
                var message = string.Concat(
                    "StateMachine trying to initialize with an invalid set of states. " +
                    "Not enough states passed in. Missing states: ");
                foreach (var missingEntry in missingEntries)
                {
                    message = string.Concat(message, missingEntry.ToString());
                    if (!missingEntry.Equals(missingEntries[missingEntries.Length - 1]))
                    {
                        message = string.Concat(message, ", ");
                    }
                }

                throw new System.ArgumentException(message);
            }
        }

        private static T[] GetMissingIDs(State<T>[] states)
        {
            var foundTs = new List<T>();
            foreach (var state in states)
            {
                foundTs.Add(state.ID);
            }

            var entriesInT = Enum.GetValues(typeof(T));
            var missingTs = new List<T>();
            for (int i = 0; i < entriesInT.Length; i++)
            {
                var entry = (T)entriesInT.GetValue(i);
                if (!foundTs.Contains(entry))
                {
                    missingTs.Add(entry);
                }
            }

            return missingTs.ToArray();
        }

        private void VerifyNoStatesAreDuplicates(State<T>[] states)
        {
            var duplicateIDs = GetDuplicateIDs(states);
            if (duplicateIDs.Length > 0)
            {
                var message = string.Concat(
                    "StateMachine trying to initialize with an invalid set of states. " +
                    "Duplicate states passed in. Duplicate states: ");
                foreach (var duplicateEntry in duplicateIDs)
                {
                    message = string.Concat(message, duplicateEntry.ToString());
                    if (!duplicateEntry.Equals(duplicateIDs[duplicateIDs.Length - 1]))
                    {
                        message = string.Concat(message, ", ");
                    }
                }

                throw new System.ArgumentException(message);
            }
        }

        private static T[] GetDuplicateIDs(State<T>[] states)
        {
            var extraStates = new List<T>();
            foreach (var state in states)
            {
                extraStates.Add(state.ID);
            }

            var entriesInT = Enum.GetValues(typeof(T));
            for (int i = 0; i < entriesInT.Length; i++)
            {
                var entry = (T)entriesInT.GetValue(i);
                if (extraStates.Contains(entry))
                {
                    extraStates.Remove(entry);
                }
            }

            return extraStates.ToArray();
        }
    }
}