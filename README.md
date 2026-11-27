# Microfono-y-camara-Interfaces-Inteligentes

Esta práctica explora el uso de componentes de entrada y salida multimedia en **Unity3D** utilizando el paquete `UnityEngine`. El proyecto se organiza en **dos escenas independientes**: una primera escena centrada en la reproducción de efectos sonoros ante eventos de interacción (utilizando la escena de los guerreros realizada en una práctica anterior) y una segunda escena ubicada en un espacio abierto con una pantalla central y altavoces, donde se integra la captura de audio en directo mediante el **micrófono** (`Microphone`) y la proyección de vídeo e imágenes fijas a través de la **cámara web** (`WebCamTexture`).

---

## Escena de los guerreros (`Microfono`)

Se ha dotado de respuesta sonora a la interacción con los objetivos incorporando un componente `AudioSource` con un `AudioClip` asignado al script asociado al guerrero (`HumanoidsObserve.cs`), de modo que cada vez que el personaje alcanza un escudo (`EscudoT1` o `EscudoT2`) y suma puntos se dispara la reproducción del efecto de sonido correspondiente (`audioSource.Play()`). A continuación se ve su ejecución, donde se escucha el sonido katana cada vez que el guerrero interactúa con los escudos:

https://github.com/user-attachments/assets/95b5d369-30a4-4055-9c7d-2283b8cb2d5d

## Escena de la pantalla y los altavoces

Por su parte, en la otra escena, se han implementado tanto la entrada de audio como la de vídeo. Para el micrófono, el script `Recorder.cs` (asociado al `AudioSource` de los altavoces) verifica previamente los dispositivos de entrada disponibles (`Microphone.devices`) para evitar excepciones, inicia la captura de audio mediante `Microphone.Start(...)` y permite reproducir el sonido captado en tiempo real al pulsar la tecla `R`, así como detener la reproducción y finalizar la grabación con `Microphone.End(...)` al pulsar `T`. Se observa su ejecución:

https://github.com/user-attachments/assets/05305b98-54a5-417d-89ba-0b6df7ad9cc1

Para la cámara web, el script `TV.cs` (asociado al televisor central) detecta las cámaras conectadas (`WebCamTexture.devices`) e imprime por consola el nombre del dispositivo seleccionado (`Debug.Log`). Durante la ejecución, al pulsar la tecla `S` se asigna la señal de la cámara a la propiedad `mainTexture` del material de la pantalla y se inicia la transmisión en directo (`Play()`), pudiendo detenerse en cualquier momento con la tecla `P` (`Stop()`). Finalmente, mientras la cámara está activa, el usuario puede capturar fotogramas aislados pulsando la tecla `X`, momento en el que se extrae el bloque de píxeles del *frame* actual hacia una textura `Texture2D` y se almacena de forma secuencial en disco en formato `.png` dentro de la carpeta `Assets/Capturas/`. Se puede ver su ejecución a continuación:

https://github.com/user-attachments/assets/8a77315a-cf32-4821-9116-ff3f9139c717

## Controles durante la ejecución

| Tecla | Acción | Escena / Script |
| :---: | :--- | :--- |
| **`R`** | Reproduce por los altavoces el sonido captado por el micrófono | `Altavoces` (`Recorder.cs`) |
| **`T`** | Detiene la reproducción y finaliza la captura del micrófono | `Altavoces` (`Recorder.cs`) |
| **`S`** | Enciende la cámara web y proyecta la imagen en el televisor central | `Altavoces` (`TV.cs`) |
| **`P`** | Detiene la captura de vídeo de la cámara | `Altavoces` (`TV.cs`) |
| **`X`** | Toma una captura de pantalla y la guarda como `.png` en `Assets/Capturas/` | `Altavoces` (`TV.cs`) |

*Candela García Cruz*
