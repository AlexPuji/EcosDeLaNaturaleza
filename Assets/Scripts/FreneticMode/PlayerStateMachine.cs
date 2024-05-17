using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private State currentState;

    void Start()
    {
        // Inicializa el estado inicial
        currentState = new IdleState(this);
    }

    void Update()
    {
        // Actualiza el estado actual
        currentState.UpdateState();
    }

    // Método para cambiar de estado
    public void ChangeState(State newState)
    {
        currentState = newState;
    }
}

public abstract class State
{
    protected PlayerStateMachine player;

    public State(PlayerStateMachine player)
    {
        this.player = player;
    }

    public abstract void UpdateState();
}

public class IdleState : State
{
    public IdleState(PlayerStateMachine player) : base(player) { }

    public override void UpdateState()
    {
        // Lógica para el estado de estar quieto
        Debug.Log("Idle State");

        // Ejemplo: Cambia al estado de correr si se presiona alguna tecla de movimiento
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            player.ChangeState(new RunningState(player));
        }
        // Ejemplo: Cambia al estado de ataque si se presiona el botón izquierdo del mouse
        else if (Input.GetMouseButtonDown(0))
        {
            player.ChangeState(new AttackingState(player));
        }
    }
}

public class RunningState : State
{
    public RunningState(PlayerStateMachine player) : base(player) { }

    public override void UpdateState()
    {
        // Lógica para el estado de correr
        Debug.Log("Running State");

        // Ejemplo: Cambia al estado de estar quieto si no se presiona ninguna tecla de movimiento
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            player.ChangeState(new IdleState(player));
        }
        // Ejemplo: Cambia al estado de ataque si se presiona el botón izquierdo del mouse
        else if (Input.GetMouseButtonDown(0))
        {
            player.ChangeState(new AttackingState(player));
        }
    }
}

public class AttackingState : State
{
    public AttackingState(PlayerStateMachine player) : base(player) { }

    public override void UpdateState()
    {
        // Lógica para el estado de ataque
        Debug.Log("Attacking State");

        // Ejemplo: Cambia al estado de estar quieto si se suelta el botón izquierdo del mouse
        if (Input.GetMouseButtonUp(0))
        {
            player.ChangeState(new IdleState(player));
        }
    }
}
