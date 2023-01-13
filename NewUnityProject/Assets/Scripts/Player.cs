using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HeroEditor.Common;
using Assets.HeroEditor.Common.CharacterScripts;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed, attackCoolTime, curAttackCoolTime, attackSpeed = 1;
    Rigidbody2D rigid;
    public Character character;
    public InputField inputFieldAttackSpeed;
    public bool bAttack = true;
    public bool bSpace = false;
    private void Awake()
    {
        // anim = GetComponentInChildren<Animator>();
        character = GetComponent<Character>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        SetAttackSpeed(attackSpeed);
    }
    public void OnInputFieldChange(InputField inputField)
    {
        SetAttackSpeed(float.Parse(inputField.text));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bAttack == true)
            {
                bAttack = false;
                curAttackCoolTime = 0;
                character.Slash();
            }
        }

        if (bAttack==false)
        {
            if(curAttackCoolTime >= attackCoolTime)
            {
                curAttackCoolTime = attackCoolTime;
                bAttack = true;
            }
            else
            {
                curAttackCoolTime += Time.deltaTime;
            }
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        //1. 힘 
        //rigid.AddForce(inputVec);

        //2. 속도제어
        //rigid.velocity = inputVec;
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        //3. 위치이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            float scale = inputVec.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale, 1, 1);
        }

        if (inputVec.magnitude != 0)//  inputVec.x != 0 || inputVec.y != 0)
        {
            character.SetState(CharacterState.Run);
        }
        else
        {
            character.SetState(CharacterState.Idle);
        }
    }

    void SetAttackSpeed(float pAttackSpeed)
    {
        attackSpeed = pAttackSpeed;

        //쿨타임
        attackCoolTime = 0.5f / attackSpeed;

        if (attackSpeed > 1) character.Animator.SetFloat(("AttackSpeed"), attackSpeed);
        else character.Animator.SetFloat(("AttackSpeed"), 1);
    }
}
