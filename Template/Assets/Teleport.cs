using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Configuración del Destino")]
    [Tooltip("Arrastra aquí el objeto vacío (Empty) que marca el destino")]
    public Transform puntoDeDestino;

    private void OnTriggerEnter(Collider other)
    {
        // Usamos la misma lógica de detección que nos funcionó antes
        bool esSpatialPlayer = other.name.Contains("Editor Local Avatar") || 
                               other.transform.root.name.Contains("Editor Local Avatar") ||
                               other.CompareTag("Player");

        if (esSpatialPlayer)
        {
            // IMPORTANTE: Buscamos la RAÍZ del jugador (el padre de todos los padres)
            // Esto asegura que movamos el avatar completo, la cámara y los scripts de Spatial
            Transform raizDelJugador = other.transform.root;

            // Teletransportamos la raíz a la posición y rotación del destino
            raizDelJugador.position = puntoDeDestino.position;
            raizDelJugador.rotation = puntoDeDestino.rotation;

            Debug.Log("Jugador teletransportado internamente a: " + puntoDeDestino.name);
            
            // Opcional: Forzar a Unity a actualizar la posición física para evitar tirones
            Physics.SyncTransforms();
        }
    }
}