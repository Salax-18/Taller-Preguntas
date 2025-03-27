using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using System.IO;
using System;
using TMPro;

public class GameControllerPreguntas : MonoBehaviour
{
    List<PreguntasMultiples> listaPM;
    string lineaLeida;

    public TextMeshProUGUI txtPregunta;   

    // Start is called before the first frame update
    void Start()
    {
        listaPM = new List<PreguntasMultiples>();
        leerPreguntasMultiples();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mostrarPregunta()
    {
        txtPregunta.text = listaPM


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
