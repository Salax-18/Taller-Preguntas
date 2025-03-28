using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using System.IO;
using System;
using TMPro;

public class GameControllerPM : MonoBehaviour
{
    List<PreguntasMultiples> listaPM;
    string lineaLeida;

    public TextMeshProUGUI txtPregunta;
    public TextMeshProUGUI txtRespuesta1;
    public TextMeshProUGUI txtRespuesta2;
    public TextMeshProUGUI txtRespuesta3;
    public TextMeshProUGUI txtRespuesta4;
    string respuesta;

    //Se usa para llevar el control de la pregunta actual
    private int currentIndex = 0;

    public static bool TotalPFaciles { get; internal set; }
    public static bool TotalPDificiles { get; internal set; }




    // Start is called before the first frame update
    void Start()
    {
        listaPM = new List<PreguntasMultiples>();
        leerPreguntasMultiples();
        mostrarPregunta();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mostrarPregunta()
    {
        if (currentIndex < listaPM.Count)
        {
            txtPregunta.text = listaPM[6].Pregunta;
            txtRespuesta1.text = listaPM[6].Respuesta1;
            txtRespuesta2.text = listaPM[6].Respuesta2;
            txtRespuesta3.text = listaPM[6].Respuesta3;
            txtRespuesta4.text = listaPM[6].Respuesta4;
            respuesta = listaPM[6].RespuestaCorrecta;
        }
        else
        {
            Debug.Log("Se terminaron las preguntas");
        }
    }

    public void respuesta1()
    {
        if (txtRespuesta1.Equals(respuesta))
        {
            Debug.Log("Respuesta 1 Correcta!");
            currentIndex++;
            mostrarPregunta();
        }
        else
        {
            Debug.Log("Respuesta 1 Incorrecta");
        }
    }

    public void respuesta2()
    {
        if (txtRespuesta2.Equals(respuesta))
        {
            Debug.Log("Respuesta 2 Correcta!");
            currentIndex++;
            mostrarPregunta();
        }
        else
        {
            Debug.Log("Respuesta  2 Incorrecta");
        }
    }
            

             public void respuesta3()
    {
        if (txtRespuesta3.Equals(respuesta))
        {
            Debug.Log("Respuesta 3 Correcta!");
            currentIndex++;
            mostrarPregunta();
        }
        else
        {
            Debug.Log("Respuesta 3 Incorrecta");
        }
    }

    public void respuesta4()
    {
        if (txtRespuesta4.Equals(respuesta))
        {
            Debug.Log("Respuesta 4 Correcta!");
            currentIndex++;
            mostrarPregunta();
        }
        else
        {
            Debug.Log("Respuesta 4 Incorrecta");
        }
    }




    #region Leer Preguntas
    public void leerPreguntasMultiples()
    {
        try
        {
            StreamReader sr1 = new StreamReader("Assets/Resources/Files/ArchivoPreguntasM.txt");
            while ((lineaLeida = sr1.ReadLine()) != null)
            {
                string[] lineapartida = lineaLeida.Split("-");
                string pregunta = lineapartida[0];
                string respuesta1 = lineapartida[1];
                string respuesta2 = lineapartida[2];
                string respuesta3 = lineapartida[3];
                string respuesta4 = lineapartida[4];
                string respuestaCorrecta = lineapartida[5];
                string versiculo = lineapartida[6];
                string dicultad = lineapartida[7];

                PreguntasMultiples objPM = new PreguntasMultiples(pregunta, respuesta1, respuesta2,
                    respuesta3, respuesta4, respuestaCorrecta, versiculo, dicultad);

                listaPM.Add(objPM);

            }
            Debug.Log("Tamaño de la lista preguntas multiple" + listaPM.Count);
        }
        catch (Exception e)
        {
            Debug.Log("ERROR " + e.ToString());
        }
    }

    #endregion

}
