using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private bool outlined = false, moving = false;
    private Hexagon currentHexagon;
    Vector3 hexagonVector, lookAtCorrection= new Vector3(0,1,0);
    private float speed = 0.01f, factor;
    Outline outline;
    //Ataque
    public float atackRange;
    public float atackDelay;
    public int atackDamage;
    private bool isAtacking = false;
    Enemy atackTarget;
    //Outline
    [SerializeField] GameObject robotModel;

    public bool Movendo
    {
        get { return moving; }
    }
    private void Start()
    {
        outline = robotModel.GetComponent<Outline>();
        outline.OutlineColor = Color.white;
        //outline.enabled = false;
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
        atackTarget.TakeDamage(atackDamage);
        if (atackTarget.lifePoints <= 0)
        {
            atackTarget.Die();
        }
    }
    private IEnumerator AtackEnemyTarget()
    {
        isAtacking = true;

        while (atackTarget.lifePoints > 0 && !moving)
        {
            transform.LookAt(atackTarget.transform.position + lookAtCorrection);
            Action();
            yield return new WaitForSeconds(atackDelay);
        }

        isAtacking = false;
    }

    public void Move(Hexagon target)
    {
        Debug.Log("estou indo");
        factor = 0;
        //Remover check de null quando implementar StartGame
        if(currentHexagon != null)
        {
        currentHexagon.Ocupado = false;
        }
        hexagonVector = target.transform.position + lookAtCorrection;
        currentHexagon = target;
        currentHexagon.Ocupado = true;
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
