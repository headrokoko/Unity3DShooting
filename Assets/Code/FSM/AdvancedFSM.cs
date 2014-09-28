using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
/// @http://creativecommons.org/licenses/by-sa/3.0/
 
public enum Transition
{
    None = 0,
    SawPlayer,
    ReachPlayer,
    LostPlayer,
    NoHealth,
}
 
public enum FSMStateID
{
    None = 0,
    Patrolling,
    Chasing,
    Attacking,
    Dead,
}
 
public class AdvancedFSM : FSM 
{
    private List<FSMState> fsmStates;
 
    //  
    private FSMStateID currentStateID;
    public FSMStateID CurrentStateID { get { return currentStateID; } }
 
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }
 
    public AdvancedFSM()
    {
        fsmStates = new List<FSMState>();
    }
 
    //
    public void AddFSMState(FSMState fsmState)
    {
        // 
        if (fsmState == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }
 
        // 
        if (fsmStates.Count == 0)
        {
            fsmStates.Add(fsmState);
            currentState = fsmState;
            currentStateID = fsmState.ID;
            return;
        }
 
        // 
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState.ID)
            {
                Debug.LogError("FSM ERROR: 既に存在する状態をリストに追加しようとしています。");
                return;
            }
        }
 
        //　
        fsmStates.Add(fsmState);
    }
 
    /// 
    public void DeleteState(FSMStateID fsmState)
    {
        // 
        if (fsmState == FSMStateID.None)
        {
            Debug.LogError("FSM ERROR: 不正なIDです。");
            return;
        }
 
        // 
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState)
            {
                fsmStates.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: 指定された状態が存在しません。削除に失敗しました。");
    }
 
    //　
    public void PerformTransition(Transition trans)
    {
        // 
        if (trans == Transition.None)
        {
            Debug.LogError("FSM ERROR: Null遷移は不正です。");
            return;
        }
 
        // 
        FSMStateID id = currentState.GetOutputState(trans);
        if (id == FSMStateID.None)
        {
            Debug.LogError("FSM ERROR: 現在の状態はこの遷移が指定する状態を持ちません。");
            return;
        }
 
        // 
        currentStateID = id;
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == currentStateID)
            {
                currentState = state;
                break;
            }
        }
    }
}