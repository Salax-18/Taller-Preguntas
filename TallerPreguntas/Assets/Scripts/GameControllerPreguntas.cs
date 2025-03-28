using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GameControllerPreguntas : MonoBehaviour
{

    public List<GameObject> ListaControllers;
    GameObject controllSelected;

    public GameObject PreguntasA;
    public GameObject PreguntasM;
    public GameObject PreguntasFV;

    public GameObject btnFaciles, btnDificiles;

    public bool FacilesA, FacilesM, FacilesFV;
    public bool DificilesA, DificilesM, DificilesFV;

    // Start is called before the first frame update

    private void Start()
    {

    }

    //

    private void Update()
    {

    }

    public void SeleccionarPreguntasFaciles()
    {
        System.Random random = new System.Random();
        int numero = random.Next(0, ListaControllers.Count);
        Debug.Log("Num" + numero);
        controllSelected = ListaControllers[numero];

        // Selección de preguntas abiertas
        if (controllSelected.GetComponent<PreguntasAbiertas>() != null)
        {
            MostrarPreguntasA();
        }

        // Selección de preguntas  opción múltiple
        if (controllSelected.GetComponent<GameControllerPM>() != null)
        {
            MostrarPreguntasM();
        }

        // Selección de preguntas falso y verdadero
        if (controllSelected.GetComponent<GameControllerPFV>() != null)
        {
            MostrarPreguntasFV();
        }
    }

    //  mostrar preguntas abiertas
    private void MostrarPreguntasA()
    {
        PreguntasFV.SetActive(false);
        PreguntasM.SetActive(false);
        PreguntasAbiertas controllerPreguntasA = controllSelected.GetComponent<PreguntasAbiertas>();
        controllerPreguntasA.SeleccionarPreguntasAbiertas(true);
        PreguntasA.SetActive(true);
        Debug.Log("Tipo: GameControllerPreguntasA");

        if (PreguntasAbiertas.TotalPFaciles)
        {
            FacilesA = true;
        }
        if (PreguntasAbiertas.TotalPDificiles)
        {
            DificilesA = true;
        }

    }

    //  mostrar preguntas de opción múltiple
    private void MostrarPreguntasM()
    {
        PreguntasA.SetActive(false);
        PreguntasFV.SetActive(false);
        GameControllerPM controllerPM = controllSelected.GetComponent<GameControllerPM>();
        controllerPM.mostrarPregunta();
        PreguntasM.SetActive(true);
        Debug.Log("Tipo: GameControllerPM");

        if (GameControllerPM.TotalPFaciles)
        {
            FacilesA = true;
        }
        if (GameControllerPM.TotalPDificiles)
        {
            DificilesA = true;
        }
    }

    // mostrar preguntas de falso y verdadero
    private void MostrarPreguntasFV()
    {
        PreguntasA.SetActive(false);
        PreguntasM.SetActive(false);
        GameControllerPFV controllerFV = controllSelected.GetComponent<GameControllerPFV>();
        controllerFV.mostrarPregunta();
        PreguntasFV.SetActive(true);
        Debug.Log("Tipo: GameControllerPreguntasFV");


        if (GameControllerPFV.TotalPFaciles)
        {
            FacilesA = true;
        }
        if (GameControllerPFV.TotalPDificiles)
        {
            DificilesA = true;
        }
    }
}



        

    