# Manual Técnico
*1. Introducción:*

*2. Descripción del proyecto:*

El proyecto realizado es llamado Eternal Battle este es un juego hecho con el motor Unity Engine y actualmente hosteado en la página de distribución de juegos itch.io. para jugarlo solamente debemos dirigirnos a la siguiente página:
https://poolextremo.itch.io/la-batalla-eterna

El juego es un Bullet Heaven, en está clase de juegos el jugador controla a un personaje en un escenario infinito, en estos juegos el objetivo es sobrevivir la mayor cantidad de tiempo, mientras una gran cantidad de enemigos aparecen en el escenario mientras mas tiempo pase los enemigos se hacen mas resistentes mas rápidos, aunque no debemos preocuparnos por que el player mientras mas enemigos elimine sube de nivel y recibe monedas esto permitirá al player adaptarse a la dificultad que incrementa con el tiempo.

*3.	Roles / integrantes*

Devin Douglas Amurrio Lizarazu – Developer / QA / Team Leader
Jhon Pool Magne Rojas – Developer / QA / Git Master

*4.	Arquitectura del software:*



*5.	Requisitos del sistema:*



*6.	Instalación y configuración:*

Si lo que se quiere es simplemente ingresar al juego (hacerlo correr) y no modificar o hostear el código fuente lo único que se debe hacer es entrar al siguiente link:
https://poolextremo.itch.io/la-batalla-eterna
el juego es gratis no se necesita descargar, se juega desde el navegador ya está hosteado y cualquier persona puede jugarlo.

Para poder obtener el código fuente del juego y poder modificarlo debemos seguir los siguientes pasos:
Primero nos dirigimos al siguiente repositorio:
https://github.com/poolextremo/Proyecto_Sistemas_3/tree/Develop
en ese repositorio tenemos que ubicarnos en la rama de Develop, esta rama es la que contiene el código fuente del juego integrado, podemos clonar la rama del repositorio, pero más fácil es descargar el código en forma de zip.

![1](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/ebcab09c-722c-474d-9b71-fe02ce96fe11)


![2](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/f605009d-5d39-40cd-801a-683c2594ddb8)


Una vez descargado el proyecto nos dirigimos en la ubicación en la que se descargó y descomprimimos el archivo zip que descargamos este es el proyecto que abriremos una vez que hayamos descargado Unity.

![3](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/485d7075-baba-428e-90b7-f3abae768d78)


Ahora procedemos a descargar Unity Hub, este nos permite administrar diferentes versiones de Unity, proyectos, paquetes etc. Además de que facilitara el instalar el editor de Unity, para descargarlo iremos al siguiente sitio web:
https://unity.com/download

![4](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/1e41f4dd-38de-4268-bd88-ae4b7025973f)


Una vez descargado instalar Unity Hub no es nada complicado, es una instalacion de siempre, cuando Unity Hub sea instalado lo abrimos este se vera asi:

![5](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/a596d993-3ee8-4e18-8315-eb7de6ed08ed)


Ahora lo que necesitamos es instalar el editor de Unity, para eso nos dirigimos a la pestaña de installs, aquí se muestra todos los editores que tenemos, proseguimos haciendo click en el botón azul Install Editor 

![6](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/72fcd358-ba07-4050-b542-6cc604cf35ad)


Se nos abre una ventana aquí nos dirigimos a la seccion de archive y damos click en el vinculo que dice download archive

![7](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/f52e2f9f-f396-4e85-abd1-d691afb0d239)


El vínculo nos lleva al archive de editores de Unity, el proyecto funciona con el editor Unity 2022.3.6 por lo tanto descargaremos ese

![8](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/3ba76c0d-2db2-4648-95dc-952182523817)


Una vez instalado el editor podemos volver a la pestaña de projects, ahora haremos click soble el boton open y elegimos la opcion Add project from disk

![9](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/32871b93-06a6-4287-a707-9abf780cca29)


Se nos abre el explorador de archivos, buscamos el proyecto que descomprimimos y lo seleccionamos

![10](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/e2d58f7f-f2a4-4dc0-880e-fb17cba631a7)


Una vez hallamos seleccionado el proyecto este se iniciara (puede tardar un poco), cuando tern¡mine de abrirse se nos mostrara el proyecto este contiene todo el codigo fuente, diseños, configuraciones etc.

![11](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/962297bf-a484-4a59-8710-c5d8bbbc5823)


Para generar un archivo .exe (ejecutable) del juego que se pueda jugar sin conexión lo que debemos hacer es dirigirnos a la parte superior, hacer click sobre file y seleccionar la opcion de Build Settings.


![12](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/f41dac58-af4a-45b7-8db1-85678233b8d7)


Se nos abrirá la siguiente ventana y aquí simplemente damos click en el botón build que se encuentra en la parte inferior derecha


![32](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/521a48e6-52cc-4252-8f03-da1c190ca507)


Al hacer click se abrirá el explorador de archivos, ahora solo queda elegir donde queremos que se construya el ejecutable del juego


![20](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/20129686-e100-4154-aacc-40e4e056313e)

![33](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/8123fb30-c143-4b18-86a0-6fcecd19a971)


Resultado:

![34](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/a80333e2-60af-4813-862c-4cbebfcde19b)


*7.	PROCEDIMIENTO DE HOSTEADO / HOSTING (configuración)*

Ahora si lo que deseamos es hostear el proyecto en una página web lo más recomendable es hacerlo en la página de itch.io, esta página es una plataforma de hosteo, venta de videojuegos, se recomienda porque es fácil de usar además de que es gratis.
https://itch.io
Para empezar a hacer el hosteo en la plataforma de itch.io lo primero que debemos hacer el el proyecto es dirigirnos a la parte superior, hacer click sobre file y seleccionar la opcion de Build Settings

![12](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/8b433676-601a-4704-adbb-9f558fd92754)


Se nos abre la siguiente ventana aquí seleccionamos la opción de WebGL por que será hosteado de forma web (se podrá jugar desde el navegador), por defecto este módulo no está instalado en Unity por lo tanto procederemos a instalarlo, para hacerlo damos click sobre el botón Install with Unity Hub

![13](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/d8dae17e-c846-4b3d-955b-cfd11eb9d695)


Unity hub nos muestra la siguiente ventana, damos click en el boton azul Install

![14](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/c17ff43f-5773-47a6-b7c8-591b53a12af1)


Se empezará a instalar

![15](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/b3b05977-78a0-4d5f-8ee3-6f0c2a7413f9)


Se mostrara lo siguiente una vez que el modulo web se halla terminado de instalar, ahora cada vez que un modulo nuevo se instala debemos reiniciar el editor para que se vean los cambios, para reiniciarlo simplemente cerramos el proyecto y lo volvemos a abrir con Unity Hub.

![16](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/63cba988-b331-4346-938b-1b5e162a6fb7)


Ahora los cambios son visibles

![17](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/0cc707eb-e5d0-490f-9ab6-647ae47cb7ec)


Ahora anates de construit la Build para hostearlo debemos hacer una pequeña configuración, nos dirigimos al boton que se encuentra en la parte inferior izquierda (Player Settings)

![18](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/36dab4f1-8bc8-408c-b15c-cf0930a7c057)


Cuando hayamos hecho click se abrirá la siguiente ventana, aquí nos dirigimos a la sección de publishing settings, nos dirigimos a la parte que dice compresion format y seleccionamos la opción que dice Disabled, hacemos esto para que no ocurra ningún error al momento de hostear el juego

![19](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/e2c89a1b-bb36-4153-b4e1-a758a5a9e17b)


Una vez hecho eso salimos de esa ventana y damos click en el botón build, se nos abrirá el explorador de archivos, seleccionamos donde queremos construir el juego.

![20](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/9b6ec875-aff4-4141-a8d6-1273effb3725)


Una vez finalizada la construcción del modelo debemos comprimir el proyecto, hay que comprimirlo como zip

![21](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/e8b7e95b-4196-40b5-a132-1cb5a05a57e5)


Estos son todos los pasos para construir el proyecto, ahora procedemos con el hosteo del juego para eso no logueamos en itch.io, si no tenemos una cuenta debemos crear una:
https://itch.io/register

![22](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/a27cf752-d9ca-4f87-acfe-d005423432a6)


Una vez que hallamos ingresado a nuestra cuenta de itch.io hacemos click en la flecha que se encuentra al lado del nombre de nuestro perfil y seleccionamos la opción de Upload new Project

![23](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/13ed978a-d39c-4d8e-a342-741748b8d577)


Se nos abrirá una ventana donde podremos subir el proyecto lo primero que debemos hacer es colocar un título, luego nos vamos a la sección de Pricing y seleccionamos la opción de no Payments

![24](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/4b5fa299-d8c8-49e1-8fa4-49cb64aa37ba)


En la sección de Kind of project seleccionamos la opción de HTML esto nos permitirá subir el juego que construimos

![25](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/35116076-09cf-4c22-9847-3de92fbbcc32)


Ahora en la sección de Uploads hacemos click en el botón rosado Upload files, se nos abrirá el explorador de archivos, seleccionamos el proyecto que comprimimos como zip

![26](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/18abc59c-2d94-4ce9-b009-8abe94f330d4)

![27](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/9a6fd5a9-bce5-4836-8198-b2493353ab72)


Cuando se termine de subir el proyecto nos aparecerá dos checkbox marcamos el checkbox que dice This file will be played in the browser, al marcar esta opción se nos permitirá jugar el juego en el navegador 

![28](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/00a447da-1853-4251-b48d-e4680de3e8a1)


![29](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/6a287f79-6de4-4b29-8ae1-3087d614301d)


Finalmente damos click al botón rosado que se encuentra en el final “Save & view page” para subir el proyecto.

![30](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/93c2d8f0-9330-41cb-87d6-6836b35527fc)


Resultado:

![31](https://github.com/poolextremo/Proyecto_Sistemas_3/assets/111919106/20a84d0b-015c-4d52-a1c5-e9c10416f97c)


*8.	GIT:*

https://github.com/poolextremo/Proyecto_Sistemas_3

*9.	Personalización y configuración:*



*10.	Depuración y solución de problemas:*

Ejecutable
Falta de Bibliotecas o Archivos:
Error: "Missing Assembly Reference" o "Archivo no encontrado".
Solución: Asegúrate de que todas las bibliotecas y archivos necesarios estén presentes y referenciados correctamente en tu proyecto. Verifica las dependencias y vuelve a importar si es necesario.

Conflictos de Versiones de Unity:
Error: "Assembly not found" o "Incompatible Unity version".
Solución: Asegúrate de que estás utilizando una versión de Unity compatible con tu proyecto. Si tienes problemas de compatibilidad, actualiza tu proyecto a la versión correcta de Unity.

Problemas con el Hardware o Controladores Gráficos:
Error: "Graphics device not found" o "Shader not supported".
Solución: Actualiza los controladores de tu tarjeta gráfica. Asegúrate de que tu hardware sea compatible con las configuraciones de gráficos de tu proyecto en Unity.

Problemas de Licencia:
Error: "License not found" o "Unity Personal Edition".
Solución: Verifica tu licencia de Unity. Asegúrate de estar utilizando la licencia correcta y de que esté activa.

Problemas de Memoria:
Error: "Out of memory" o "Crash during build".
Solución: Aumenta la asignación de memoria en las configuraciones de Unity para la construcción. También asegúrate de cerrar otras aplicaciones para liberar memoria durante la construcción.

Web
Problemas con la caché del navegador:
Problema: Los navegadores pueden almacenar en caché archivos y recursos, lo que puede causar que las versiones más recientes no se carguen.
Solución: Desactiva la caché del navegador durante el desarrollo o cambia los nombres de los archivos para evitar que se almacenen en caché.

*11.	Glosario de términos:*



*12.	Referencias y recursos adicionales:*

https://github.com/poolextremo/Proyecto_Sistemas_3/tree/Develop

https://unity.com/download

https://itch.io/register

https://itch.io

https://poolextremo.itch.io/la-batalla-eterna

*13.	Herramientas de Implementación:*

Para utilizar el código fuente
•	C#
•	Unity Hub
•	Unity Editor 2022.3.6f1

Para Iniciar e juego ya implementado
•	Algún Navegador
•	Itch.io

*14.	Bibliografía*
