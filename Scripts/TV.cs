using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string savePath;

    int captureCounter = 1;

    void Start() {
        tvMaterial = GetComponent<Renderer>().material;
        savePath = Application.dataPath + "/Capturas/foto_";

        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0) {
            Debug.Log("Nombre de la cámara: " + devices[0].name);
            webcamTexture = new WebCamTexture(devices[0].name);
        }
        else {
            Debug.Log("No se ha encontrado ninguna cámara.");
        }
    }

    void Update() {
        if (webcamTexture == null) { return; }

        if (Input.GetKeyDown(KeyCode.S)) {
            tvMaterial.mainTexture = webcamTexture;
            webcamTexture.Play();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("Cámara parada al pulsar P.");
            webcamTexture.Stop();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            if (webcamTexture.isPlaying) {
                Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
                snapshot.SetPixels(webcamTexture.GetPixels());
                snapshot.Apply();
                System.IO.File.WriteAllBytes(savePath + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
                Debug.Log("Foto guardada en: " + savePath + captureCounter.ToString() + ".png");
                captureCounter++;
            }
        }
    }
}
