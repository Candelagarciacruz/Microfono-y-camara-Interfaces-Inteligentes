# Microfono-y-camara-Interfaces-Inteligentes

Esta práctica explora el uso de componentes de entrada y salida multimedia en **Unity3D** utilizando el paquete `UnityEngine`. El proyecto se organiza en **dos escenas independientes**: una primera escena centrada en la reproducción de efectos sonoros ante eventos de interacción (utilizando la escena de los guerreros realizada en una práctica anterior) y una segunda escena ubicada en un espacio abierto con una pantalla central y altavoces, donde se integra la captura de audio en directo mediante el **micrófono** (`Microphone`) y la proyección de vídeo e imágenes fijas a través de la **cámara web** (`WebCamTexture`).

---

## Funcionalidades implementadas

En la **escena de los guerreros (`Microfono`)**, se ha dotado de respuesta sonora a la interacción con los objetivos incorporando un componente `AudioSource` con un `AudioClip` asignado en el recolector (`HumanoidsObserve.cs`), de modo que cada vez que el personaje alcanza un escudo (`EscudoT1` o `EscudoT2`) y suma puntos se dispara la reproducción del efecto de sonido correspondiente (`audioSource.Play()`).

Por su parte, en la **escena de la pantalla y los altavoces (`Altavoces`)**, se han implementado tanto la entrada de audio como la de vídeo. Para el micrófono, el script `Recorder.cs` —asociado al `AudioSource` de los altavoces (`Speakers`)— verifica previamente los dispositivos de entrada disponibles (`Microphone.devices`) para evitar excepciones, inicia la captura de audio mediante `Microphone.Start(...)` y permite reproducir el sonido captado en tiempo real al pulsar la tecla `R`, así como detener la reproducción y finalizar la grabación con `Microphone.End(...)` al pulsar `T`. Para la cámara web, el script `TV.cs` —asociado al televisor central (`TV LED 30"`)— detecta las cámaras conectadas (`WebCamTexture.devices`) e imprime por consola el nombre del dispositivo seleccionado (`Debug.Log`). Durante la ejecución, al pulsar la tecla `S` se asigna la señal de la cámara a la propiedad `mainTexture` del material de la pantalla y se inicia la transmisión en directo (`Play()`), pudiendo detenerse en cualquier momento con la tecla `P` (`Stop()`). Finalmente, mientras la cámara está activa, el usuario puede capturar fotogramas aislados pulsando la tecla `X`, momento en el que se extrae el bloque de píxeles del *frame* actual hacia una textura `Texture2D` y se almacena de forma secuencial en disco en formato `.png` dentro de la carpeta `Assets/Capturas/`.

---

## Controles durante la ejecución

| Tecla | Acción | Escena / Script |
| :---: | :--- | :--- |
| **`R`** | Reproduce por los altavoces el sonido captado por el micrófono | `Altavoces` (`Recorder.cs`) |
| **`T`** | Detiene la reproducción y finaliza la captura del micrófono | `Altavoces` (`Recorder.cs`) |
| **`S`** | Enciende la cámara web y proyecta la imagen en el televisor central | `Altavoces` (`TV.cs`) |
| **`P`** | Detiene la captura de vídeo de la cámara | `Altavoces` (`TV.cs`) |
| **`X`** | Toma una captura de pantalla y la guarda como `.png` en `Assets/Capturas/` | `Altavoces` (`TV.cs`) |

---

## Estructura del proyecto

* **Escenas (`Assets/Scenes/`):**
  * **`Microfono`**: Escena de los guerreros y escudos con respuesta sonora al alcanzar objetivos.
  * **`Altavoces`**: Escena en espacio abierto equipada con televisor central (`TV LED 30"`) y altavoces (`Speakers`) para pruebas de micrófono y webcam.
* **Scripts (`Assets/Scripts/`):**
  * **`Ejercicio3/HumanoidsObserve.cs`**: Controla el comportamiento del personaje hacia los escudos y dispara la reproducción del `AudioSource` al alcanzarlos.
  * **`Altavoces/Recorder.cs`**: Gestiona la detección y el inicio del micrófono por defecto, la asignación del `AudioClip` al `AudioSource` de los altavoces y los controles de reproducción y parada.
  * **`Altavoces/TV.cs`**: Gestiona la `WebCamTexture` sobre el `Renderer` de la pantalla del televisor, muestra el nombre de la cámara en consola y exporta las capturas a archivos PNG secuenciales (`foto_1.png`, `foto_2.png`, etc.).
* **Recursos (`Assets/Capturas/`):** Directorio donde se almacenan automáticamente las instantáneas `.png` capturadas desde la cámara web.

---

## Demostración

> *Nota: Si reproduces los vídeos directamente desde GitHub, activa el icono del altavoz en la esquina inferior derecha del reproductor para escuchar el audio.*

### 1. Escena de los guerreros (Sonido al alcanzar objetivos)
*(Arrastra aquí tu archivo `.mp4` de la escena `Microfono` al editar el README en GitHub)*

### 2. Escena de pantalla y altavoces (Micrófono y Cámara Web)
*(Arrastra aquí tu archivo `.mp4` de la escena `Altavoces` al editar el README en GitHub)*
