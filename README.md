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

### Como actualizar tu rama despues de hacer el fork
Los pasos a detallar se encuentran en este enlace: http://community.logicalbricks.com/node/217

Primero se detallaran las pasos que hay que seguir solo por primera vez.

Primero se debe hacer la clonacion del proyecto para iniciar a trabajar
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


### Acuerdos del Grupo
1. Como lenguaje de programación se ha quedado en Visual .Net  C# 2012.
2. Como Base de Datos se quedo en SQL Server 2012.
3. Se esta quedando con un modelo de tres capas (presentacion, negocio, acceso a datos)

