# Plaza Vea Taller Proyecto 3
Proyecto academico grupal 2016

### Instalación de GitHub
Para instalar GitHub seguir los siguientes pasos dentro del enlace:

https://desktop.github.com/

### Participar en el Proyecto
Para colaborar en el proyecto deben primero hacer un fork del repositorio para ello deben seguir los pasos que mencionan este tutorial:

https://git-scm.com/book/es/v2/GitHub-Participando-en-Proyectos

Para poder realizar un Fork deben tener una cuenta en GitHub.

Si quieren trabajarlo junto a visual studio pueden seguir el proximo enlace.

https://www.visualstudio.com/en-us/get-started/code/gitquickstart

*En caso de no realizar este paso se da la probabilidad que haya conflictos al hacer el pull request. Si hay conflictos su commit SERA RECHAZADO*

Recuerden que para hacer un *pull request* los pasos son:
* Entrar a https://github.com/carloshs92/plaza-vea-taller-proyecto-3/ 
* Busca el boton "New pull request"
* Hacer click al enlace "compare across forks"
* En el base fork debe apuntar a la rama base *master*
* En el heade fork debe estar su rama con los cambios.

### Como actualizar una rama despues de hacer el fork
Los pasos a detallar se encuentran en este enlace: http://community.logicalbricks.com/node/217

Primero se detallaran las pasos que hay que seguir solo por primera vez.

Primero se debe hacer la clonacion del proyecto para iniciar a trabajar

*Si trabajan en windows escriban manualmente los comandos sino es posible que le salga el error "fatal: I don't handle protocol '​​https'"*

```sh
git clone https://github.com/tu_usuario/plaza-vea-taller-proyecto-3.git
cd plaza-vea-taller-proyecto-3
```

Lo que tenemos que hacer después es agregar el repositorio padre como un origen remoto.
```git
git remote add upstream https://github.com/carloshs92/plaza-vea-taller-proyecto-3.git
git fetch upstream
```

*Ahora si podemos actualizar nuestra rama aplicando las siguientes lineas de comando.*
```git
git fetch upstream
git merge upstream/master
```


### Quiero subir mis cambios a mi rama
Los pasos basicos son:
```git
git add ruta/de/archivo/a/subir
git commit -m 'mensaje del commit'
git push origin rama-a-la-cual-subiras-tus-cambios
```

### Acuerdos del Grupo
1. Como lenguaje de programación se ha quedado en Visual .Net  C# 2012.
2. Como Base de Datos se quedo en SQL Server 2012.
3. Se esta quedando con un modelo de tres capas (presentacion, negocio, acceso a datos)

