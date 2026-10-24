using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ContadorJuego : MonoBehaviour
{
    private Dictionary<string, int> conteo = new Dictionary<string, int>()
    {
        { "Moneda", 0 },
        { "banana", 0 },
        { "cerveza", 0 }
    };
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        Actualizar();
    }

    public void Sumar(string nombre)
    {
        if (conteo.ContainsKey(nombre))
        {
            conteo[nombre]++;
            Actualizar();
        }
    }

    void Actualizar()
    {
        List<string> partes = new List<string>();
        foreach (var par in conteo)
            partes.Add(par.Key + ": " + par.Value);
        textMesh.text = string.Join(" | ", partes);
    }
}