using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using System.IO;
using TMPro;

public class GameControllerPA : MonoBehaviour
{
    List<PreguntasAbiertas> listaPA;
    string lineaLeida;

    public TextMeshProUGUI txtPregunta;
    public TMP_InputField inputRespuesta;
    string respuestaCorrecta;

    void Start()
    {
        listaPA = new List<PreguntasAbiertas>();
        leerPreguntasAbiertas();
    }

    void Update()
    {

    }

    public void mostrarPregunta()
    {
        int index = UnityEngine.Random.Range(0, listaPA.Count);
        txtPregunta.text = listaPA[index].Pregunta;
        respuestaCorrecta = listaPA[index].RespuestaCorrecta;
        inputRespuesta.text = "";
    }

    public void verificarRespuesta()
    {
        if (inputRespuesta.text.Trim().ToLower() == respuestaCorrecta.ToLower())
        {
            Debug.Log("¡Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
        }
    }

    #region Leer Preguntas
    public void leerPreguntasAbiertas()
    {
        try
        {
            StreamReader sr = new StreamReader("Assets/Resources/Files/ArchivoPreguntasAbiertas.txt");
            while ((lineaLeida = sr.ReadLine()) != null)
            {
                string[] lineapartida = lineaLeida.Split("-");
                string pregunta = lineapartida[0];
                string respuestaCorrecta = lineapartida[1];
                string versiculo = lineapartida[2];
                string dificultad = lineapartida[3];

                PreguntasAbiertas objPA = new PreguntasAbiertas(pregunta, respuestaCorrecta, versiculo, dificultad);
                listaPA.Add(objPA);
            }
            Debug.Log("Tamaño de la lista preguntas abiertas: " + listaPA.Count);
        }
        catch (Exception e)
        {
            Debug.Log("ERROR: " + e.ToString());
        }
    }
    #endregion
}
