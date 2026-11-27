using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {
    private AudioSource audioSource;
    private string micDevice;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        // Comprobar si hay micrófonos disponibles
        if (Microphone.devices.Length > 0) {
            micDevice = Microphone.devices[0];
            Debug.Log("Micrófono detectado: " + micDevice);
        }
        else {
            Debug.Log("No se ha encontrado ningún micrófono.");
        }
    }

    void Update() {
        if (micDevice == null) { return; }

        // Pulsar la tecla R para reproducir lo captado por el micrófono
        if (Input.GetKeyDown(KeyCode.R)) {
            audioSource.clip = Microphone.Start(micDevice, true, 10, 44100);
            Debug.Log("Inicia la grabación.");
            while (!(Microphone.GetPosition(micDevice) > 0)) { }
            audioSource.Play();
        }

        // Pulsar la tecla T para parar el micrófono
        if (Input.GetKeyDown(KeyCode.T)) {
            audioSource.Stop();
            Microphone.End(micDevice);
            Debug.Log("Grabación detenida.");
        }
    }
}
