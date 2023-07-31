using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Robot[] robots;
    [SerializeField] Hexagon[] hexagons;
    Hexagon hexagon;
    private Robot robotHovered, robotSelected, robot;
    private Camera mainCamera;
    private float timeNextHover, delayNextHover = 0.034f;
    Ray ray;
    RaycastHit hit;
    private void Start()
    {
        mainCamera = Camera.main;
        robots[0].Move(hexagons[14]);
        robots[1].Move(hexagons[20]);
        robots[2].Move(hexagons[21]);
    }

    private void Update()
    {
        UpdateRayCastOnClick();
        if (Time.time > timeNextHover)
        {
            OutlineRobotInCursor();
            timeNextHover = Time.time + delayNextHover;
        }
        ClickHexagon();
        ClickRobot();
    }
    private void UpdateRayCastOnClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
        }
    }
    private void ClickRobot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            robot = WhichRobot(hit.collider.name);
            // Verifique se o objeto atingido pelo raio � um rob�
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

                // Ative o brilho nos hex�gonos vazios
                foreach (Hexagon hexagono in hexagons)
                {
                    hexagono.StartOutline();
                }
            }
        }
        // Execute o clique apenas se houver um rob� selecionado
    }
    private void ClickHexagon()
    {
        if (Input.GetMouseButtonDown(1))
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
                // Verifique se o objeto atingido pelo raio � um hex�gono brilhante
                if (hexagon != null && hexagon.IsOutlined())
                {
                    // Mova o rob� para o centro do hex�gono selecionado
                    robotSelected.Move(hexagon);
                    // Desselecione o rob� e pare o brilho nos hex�gonos
                    robotSelected.UndoSelectRobot();
                    robotSelected = null;
                    foreach (Hexagon hexagono in hexagons)
                    {
                        hexagono.StopOutline();
                    }
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
            // Se o objeto atingido pelo raio � um rob�
            if (robot != null)
            {
                // Se o rob� n�o � o mesmo que estava sendo brilhado anteriormente
                if (robot != robotHovered)
                {
                    // Desliga o brilho do rob� anterior
                    if (robotHovered != null)
                    {
                        robotHovered.StopOutline();
                    }
                    robotHovered = robot;
                    // Ativa o brilho no rob� atual
                    robotHovered.StartOutline(); // Chame aqui a fun��o que ativa o brilho
                }
            }
            else
            {
                // Se nenhum rob� estiver sob o cursor, desliga o brilho do rob� anterior
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
        // Extrai o n�mero do nome do hex�gono
        string number = HexName.Replace("Hexagon.", "");

        // Converte o n�mero para inteiro
        int index = int.Parse(number);

        // Retorna o �ndice do hex�gono
        return index;
    }
}
