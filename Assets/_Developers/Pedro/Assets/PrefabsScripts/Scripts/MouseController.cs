using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    //Robots
    [SerializeField] GameObject robotSpace;
    [SerializeField] Robot[] robotsToBuy = new Robot[3];
    [SerializeField]private Robot[] robots = new Robot[3];
    public int robotCount;
    private Robot robotHovered, robotSelected, robot;
    //Hexagons
    [SerializeField] Hexagon[] hexagons;
    private Hexagon hexagon;

    private Camera mainCamera;
    private float timeNextHover, delayNextHover = 0.034f;
    private Ray ray;
    private RaycastHit hit;
    private void Start()
    {
        mainCamera = Camera.main;
        GameManager.instance.mouseController = this;
    }

    public void AddRobot(int robotType)
    {
        switch (robotCount)
        {
            case 0:
                robots[robotCount] = Instantiate(robotsToBuy[robotType], robotSpace.transform);
                robots[robotCount].name = "R1";
                robotCount++;
                break;
            case 1:
                robots[robotCount] = Instantiate(robotsToBuy[robotType], robotSpace.transform);
                robots[robotCount].name = "R2";
                robotCount++;
                break;
            case 2:
                robots[robotCount] = Instantiate(robotsToBuy[robotType], transform);
                robots[robotCount].name = "R3";
                robotCount++;
                break;
        }
    }
    private void Update()
    {
        UpdateRayCastOnClick();
        if (Time.time > timeNextHover)
        {
            OutlineRobotInCursor();
            timeNextHover = Time.time + delayNextHover;
        }
    }
    private void UpdateRayCastOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            ClickHexagon();
            ClickRobot();
        }
    }
    private void ClickRobot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            robot = WhichRobot(hit.collider.name);
            // Verifique se o objeto atingido pelo raio é um robô
            if (robotSelected != null)
            {
                robotSelected.UndoSelectRobot();
                robotSelected = null;
                foreach (Hexagon hexagono in hexagons)
                {
                    hexagono.StopOutline();
                }
            }
            if (robot != null)
            {
                robotSelected = robot;
                robotSelected.SelectRobot();

                // Ative o brilho nos hexágonos vazios
                foreach (Hexagon hexagono in hexagons)
                {
                    hexagono.StartOutline();
                }
            }          
        }
        // Execute o clique apenas se houver um robô selecionado
    }
    private void ClickHexagon()
    {
        //Verifica Se algum robo ira mover
        if (robotSelected != null && !robotSelected.Movendo)
        {
            if (hit.collider.CompareTag("Hexagon"))
            {
                hexagon = hexagons[ExtractIndexHexagon(hit.collider.name)];
            }
            else
            {
                hexagon = null;
            }
            // Verifique se o objeto atingido pelo raio é um hexágono brilhante
            if (hexagon != null && hexagon.IsOutlined())
            {
                // Mova o robô para o centro do hexágono selecionado
                robotSelected.Move(hexagon);
                // Desselecione o robô e pare o brilho nos hexágonos
                robotSelected.UndoSelectRobot();
                robotSelected = null;
                foreach (Hexagon hexagono in hexagons)
                {
                    hexagono.StopOutline();
                }
            }
        }
    }
    private void OutlineRobotInCursor()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (robotSelected == null && hit.collider != null)
        {
            robot = WhichRobot(hit.collider.name);
            // Se o objeto atingido pelo raio é um robô
            if (robot != null)
            {
                // Se o robô não é o mesmo que estava sendo brilhado anteriormente
                if (robot != robotHovered)
                {
                    // Desliga o brilho do robô anterior
                    if (robotHovered != null)
                    {
                        robotHovered.StopOutline();
                    }
                    robotHovered = robot;
                    // Ativa o brilho no robô atual
                    robotHovered.StartOutline(); // Chame aqui a função que ativa o brilho
                }
            }
            else
            {
                // Se nenhum robô estiver sob o cursor, desliga o brilho do robô anterior
                if (robotHovered != null)
                {
                    robotHovered.StopOutline();
                    robotHovered = null;
                }
            }
        }
    }
    private Robot WhichRobot(string name)
    {
        switch (name)
        {
            case "R1":
                return robots[0];
            case "R2":
                return robots[1];
            case "R3":
                return robots[2];
            default: return null;
        }

    }
    private int ExtractIndexHexagon(string HexName)
    {
        // Extrai o número do nome do hexágono
        string number = HexName.Replace("Hexagon.", "");

        // Converte o número para inteiro
        int index = int.Parse(number);

        // Retorna o índice do hexágono
        return index;
    }
}
