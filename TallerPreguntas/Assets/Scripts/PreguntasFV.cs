internal class PreguntasFV
{
    private string versiculo;
    private string dificultad;

    public PreguntasFV(string pregunta, string respuestaCorrecta, string versiculo, string dificultad)
    {
        Pregunta = pregunta;
        RespuestaCorrecta = respuestaCorrecta;
        this.versiculo = versiculo;
        this.dificultad = dificultad;
    }

    public string Pregunta { get; internal set; }
    public string RespuestaCorrecta { get; internal set; }
}