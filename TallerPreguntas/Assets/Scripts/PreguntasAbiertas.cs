using System;

internal class PreguntasAbiertas
{
    private string versiculo;
    private string dificultad;

    public PreguntasAbiertas(string pregunta, string respuestaCorrecta, string versiculo, string dificultad)
    {
        Pregunta = pregunta;
        RespuestaCorrecta = respuestaCorrecta;
        this.versiculo = versiculo;
        this.dificultad = dificultad;
    }

    public static bool TotalPFaciles { get; internal set; }
    public static bool TotalPDificiles { get; internal set; }
    public string Pregunta { get; internal set; }
    public string RespuestaCorrecta { get; internal set; }

    internal void SeleccionarPreguntasAbiertas(bool v)
    {
        throw new NotImplementedException();
    }
}