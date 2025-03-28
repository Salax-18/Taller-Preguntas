using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using System.IO;
using TMPro;

public class GameControllerPFV : MonoBehaviour
{
    List<PreguntasFV> listaPFV;
    string lineaLeida;

    public TextMeshProUGUI txtPregunta;
    public TextMeshProUGUI txtVerdadero;
    public TextMeshProUGUI txtFalso;
    string respuestaCorrecta;

    public static bool TotalPFaciles { get; internal set; }
    public static bool TotalPDificiles { get; internal set; }

    void Start()
    {
        listaPFV = new List<PreguntasFV>();
        leerPreguntasFalsoVerdadero();
    }

    void Update()
    {

    }

    public void mostrarPregunta()
    {
        int index = UnityEngine.Random.Range(0, listaPFV.Count);
        txtPregunta.text = listaPFV[index].Pregunta;
        txtVerdadero.text = "Verdadero";
        txtFalso.text = "Falso";
        respuestaCorrecta = listaPFV[index].RespuestaCorrecta;
    }

    public void responder(bool esVerdadero)
    {
        if ((esVerdadero && respuestaCorrecta == "Verdadero") || (!esVerdadero && respuestaCorrecta == "Falso"))
        {
            Debug.Log("¡Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
        }
    }

    #region Leer Preguntas
    public void leerPreguntasFalsoVerdadero()
    {
        try
        {
            StreamReader sr = new StreamReader("Assets/Resources/Files/ArchivoPreguntasFalso_Verdadero.txt");
            while ((lineaLeida = sr.ReadLine()) != null)
            {
                string[] lineapartida = lineaLeida.Split("-");
                string pregunta = lineapartida[0];
                string respuestaCorrecta = lineapartida[1];
                string versiculo = lineapartida[2];
                string dificultad = lineapartida[3];

                PreguntasFV objPFV = new PreguntasFV(pregunta, respuestaCorrecta, versiculo, dificultad);
                listaPFV.Add(objPFV);
            }
            Debug.Log("Tamaño de la lista preguntas FV: " + listaPFV.Count);
        }
        catch (Exception e)
        {
            Debug.Log("ERROR: " + e.ToString());
        }
    }
    #endregion
}
