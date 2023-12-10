using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    private int puntos;
    public Text puntuacion;
    void Start()
    {
        UpdatePoints(0);
    }
    public void UpdatePoints(int puntaje_del_enemigo)
    {
        puntos = puntos + puntaje_del_enemigo;
        puntuacion.text = "Puntos: " + puntos;
    }
}
