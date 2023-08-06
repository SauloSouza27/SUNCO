using SunCo.Scripts.Vfx;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private bool outlined = false, moving = false;
    private Hexagon currentHexagon;
    Vector3 hexagonVector;
    private float speed = 0.01f, factor;
    Outline outline;

    //Atack
    public float atackRange;
    public float atackDelay;
    public int atackDamage;
    private bool isAtacking = false;
    Enemy atackTarget;
    public Enemy AtackTarget
    {
        get { return atackTarget; }
    }

    //Outline
    [SerializeField] GameObject robotFBX;

    //Weapon
    [SerializeField] bool singleTarget;
    [SerializeField] Weapon weapon;

    //Animator
    private Animator animator;

    public bool Movendo
    {
        get { return moving; }
    }
    private void Start()
    {
        animator = robotFBX.GetComponent<Animator>();
        outline = robotFBX.GetComponent<Outline>();
        outline.OutlineColor = Color.white;
        outline.enabled = false;
    }
    private void Update()
    {
        if(moving)
        {
            UpdatePosition();           
        }
        if (!moving && !isAtacking)
        {
            CheckForEnemies();
        }
        if (isAtacking && atackTarget != null )
        {
            transform.LookAt(atackTarget.transform.position);
        }
    }
    private void CheckForEnemies()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, atackRange);

        foreach (Collider enemy in enemies)
        {
            //adicionar mais ifs conforme preferência de ataque do robot
            // Verifica se o objeto detectado é um inimigo
            if (enemy.CompareTag("Enemy"))
            {
                atackTarget = enemy.GetComponent<Enemy>();
                StartCoroutine(AtackEnemyTarget());
                break;
            }
        }
    }
    public virtual void Action()
    {
        weapon.SpawnBullet();
        /*
        if (atackTarget != null && singleTarget)
        {
            atackTarget.TakeDamage(atackDamage);
            
            if (atackTarget.lifePoints <= 0)
            {
                atackTarget.Die();
            }
            
        }
        */
    }
    private IEnumerator AtackEnemyTarget()
    {
        isAtacking = true;

        while (atackTarget != null && atackTarget.lifePoints > 0 && !moving)
        {
            if(Vector3.Distance(atackTarget.transform.position,transform.position) > atackRange + 0.5f)
            {
                break;
            }
            transform.LookAt(atackTarget.transform.position);
            animator.SetTrigger("Shoot");
            yield return new WaitForSeconds(atackDelay);
        }

        isAtacking = false;
    }

    public void Move(Hexagon target)
    {
        Debug.Log("estou indo");
        factor = 0;
        if(currentHexagon != null)
        {
        currentHexagon.Ocuppied = false;
        }
        hexagonVector = target.transform.position;
        currentHexagon = target;
        currentHexagon.Ocuppied = true;
        moving = true;
    }
    private void UpdatePosition()
    {
        factor += (Time.deltaTime * speed)/ Vector3.Distance(hexagonVector, transform.position);
        transform.position = Vector3.Lerp(transform.position, hexagonVector, factor);
        if (Vector3.Distance(hexagonVector, transform.position) < 0.1f)
        {
            moving = false;
            transform.position = hexagonVector;
        }
    }

    public void SelectRobot()
    {
        outline.enabled = false;
        outline.OutlineColor = Color.green;
        Debug.Log("Robô selecionado: " + gameObject.name);
        StartOutline();
    }
    public void UndoSelectRobot()
    {
        outline.enabled = false;
        outline.OutlineColor = Color.white;
        Debug.Log("Robô desselecionado: " + gameObject.name);
        StopOutline();
    }

    public void StartOutline()
    {       
        outlined = true;
        outline.enabled = true;           
    }
    public void StopOutline()
    {       
        outlined = false;
        outline.enabled = false;       
    }
    public bool IsOutlined()
    {
        return outlined;
    }
}
