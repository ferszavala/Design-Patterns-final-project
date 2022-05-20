# Design Patterns final project
## Descripción del proyecto:
Crear una aplicación Windows que se encargue de la administración y control de pedidos para tiendas de
autoservicio.
La aplicación será capaz de levantar pedidos en diferentes tiendas, para ello, una vez que llegue a la tienda y lea un QR para saber su nombre y Id, deberá capturar el producto, y la cantidad. Al momento de guardar el pedido, la aplicación generará una imagen QR, que reemplazará a la leída anteriormente, que llevará almacenado en formato Json la siguiente información:
- Id tienda
- Nombre Tienda
- Lista de productos a surtir en la próxima visita: Id producto, nombre, precio y cantidad

Y este mismo proceso de toma de pedidos se repetirá para cada tienda.

Al día siguiente que se requiera tomar la ruta para surtir los pedidos, el proceso será el siguiente:
- Leer las imágenes de pedidos levantados, en cada tienda.
- Simular la ruta de entrega (punto explicado más adelante)
- Generar la ruta para visitar las tiendas. Esta lógica estará dada por: la tienda que involucre la mayor ganancia, deberá ser visitada primero, y así sucesivamente, dejando al final la tienda que genere menos dinero.
- Por cada tienda que se visite se surtirá el pedido y al mismo tiempo se levantará el pedido del día siguiente, al generarlo, de acuerdo al proceso anterior, se generará una nueva imagen QR que será utilizada para formar la ruta del día siguiente.

### Simulación de Ruta de Entrega
Un punto importante es que antes de generar la ruta de entregas, será necesario verificar el número de camiones repartidores necesarios para cumplir con la demanda de los pedidos.
Habrá un máximo de 5 camiones repartidores:
- 3 camiones de refrescos. Cada camión contará con 120 refrescos por surtir. 
- 3 camiones de pan fresco. Cada camión contará con 270 piezas de pan por surtir. 
- 3 camiones de verdura congelada. Cada camión cuenta con 95 bolsas de 1 Kg de verdura congelada.

La aplicación deberá simular la ruta de entregas, antes de que los repartidores salgan.
Para ello el usuario, elegirá los camiones a salir a ruta (mínimo 1) y ejecutará la simulación. Si el resultadoes: *No se cumple con la demanda de producto.*

El usuario agregará un camión más a la simulación en runtime, y volverá a ejecutar la simulación, y así sucesivamente, hasta dar con el resultado: _Se cumple con la demanda y sobran X productos_. Donde X representa el número de productos sobrantes, luego de terminar la ruta.

### La aplicación deberá contener una bitácora, la cual esté registrando los eventos de:
- Comienzo de simulación
- Agregar camión repartidor
- Fin de simulación
- Crear pedido
- Agregar producto
- Finalizar pedido
- Creación de imagen.

La bitácora es de tres tipos:
- En archivo de texto txt
- A Grid en pantalla
- A textbox multilinea

El tipo de bitácora podrá ser seleccionado en runtime, en una pantalla o menú de configuración. El tipo puede ser los tres tipos al mismo tiempo. E inclusive varias veces el mismo tipo. 
_Ejemplos:_

_- Si el usuario selecciona bitácora de tipo: Archivo de texto. La bitácora solo se mostrará en un archivo de texto._

_- Si el usuario selecciona tres veces el archivo de texto. Al abrir el archivo, la bitácora mostrará tres líneas por cada evento que registró._

_- Si el usuario selecciona: archivo de texto y textbox, la salida de la bitácora deberá ser tanto en archivo como en el textbox._

La aplicación deberá consumir un API que codifique y decodifique las imágenes QR y las convierta en la información anteriormente mencionada. API: 2
La aplicación deberá aplicar de manera correcta al menos tres patrones de diseño, uno por cada tipo de patrones que existen (creacional, estructural y de comportamiento).

## Descripción de los patrones de diseño implementados.
__Singleton__

_Se usa al necesitar:_

1.	Una clase que se ocupa en todo el programa (es decir, que se debe de acceder a ella desde cualquier otra clase)
2.	Una sola instancia (creada por la clase)
3.	La no inicialización desde un inicio en el programa

_Diagrama UML_

![image](https://user-images.githubusercontent.com/72468795/169571413-b1eb7285-5982-494e-82c9-76b04b692039.png)

_Dentro del proyecto se utiliza para:_

Generación de los códigos QR, debido a que los códigos son objetos que se generan desde distintos puntos (ejemplo: creación de tienda desde cero con datos manuales y carga de tienda ya existente con código QR, el cual solo se necesita que exista cuando le mandamos llamar a la instancia, no desde que comienza el programa.

![image](https://user-images.githubusercontent.com/72468795/169571717-8790d541-6284-490e-8353-88a841df8584.png)

Generación de bitácoras, en colaboración con un patrón de diseño estructural (adapter, explicado posteriormente).
Lo anterior debido a que no me interesa crear las bitácoras desde el principio, pero si necesito acceder a ellas desde casi todas las demás clases del proyecto (ya que debe de ir registrando todos los eventos en el mismo). 

![image](https://user-images.githubusercontent.com/72468795/169571795-b1fd5e18-3058-408c-b97e-59938f1aff83.png)

Generación de tiendas, se crea la instancia de tiendas para que solo se le llame cuando se necesita crear o volver a registrar una tienda, a través de esta instancia se crea posteriormente una lista de tipo Store en la clase en la que añadimos tiendas visitadas con anterioridad o bien aquellas que son nuevos registros

![image](https://user-images.githubusercontent.com/72468795/169571865-1347e8a2-ea20-474f-8b74-60fe6dbbe94d.png)

__Adapter__

_Se usa al necesitar:_
- Convertir una interfaz de una clase a otra
- Envolver una clase existente con una nueva interfaz
- Introducir un componente heredado en un nuevo sistema

_Diagrama UML_

![image](https://user-images.githubusercontent.com/72468795/169572258-3c370a8f-338f-4e80-8123-6d557c30ea86.png)

_Dentro del proyecto se utiliza para:_

Generación de las bitácoras, se usan oficialmente tres Adapter, uno para cada tipo de bitácora, con lo cual se garantiza que sin importar cual sea el tipo de archivo en el que queramos reflejar nuestro reporte con la información requerida (Grid, TextBox o Archivo descargable TXT) 

Target en donde se definen los métodos que se necesitan para todos los tipos de bitácoras

![image](https://user-images.githubusercontent.com/72468795/169572372-ce2e35f4-c630-4d7e-995d-fccee8162f4f.png)

Adapter para el archivo en formato Grid

![image](https://user-images.githubusercontent.com/72468795/169572435-175832b6-9068-43ca-8a18-9bfe70a89cbb.png)

Adaptee para el archivo en formato Grid en donde se define exactamente cómo debe de acomodar la información y de donde toma la clase para abrir el formulario

![image](https://user-images.githubusercontent.com/72468795/169572677-2d22ddd4-e846-4f14-acdc-f47a3c4f0da1.png)

Adapter para el archivo en formato TextBox

![image](https://user-images.githubusercontent.com/72468795/169572729-5739586c-96db-46c7-a9af-5dd94fff2d20.png)

Adaptee para el archivo en formato TextBox en donde se define exactamente cómo debe de acomodar la información y de donde toma la clase para abrir el formulario

![image](https://user-images.githubusercontent.com/72468795/169572838-249d3489-6d4b-4bea-88c8-357c4699ee70.png)

Adapter para el archivo en formato TXT

![image](https://user-images.githubusercontent.com/72468795/169572902-888f8c27-f2da-47ff-aea9-d01b9c93cd0e.png)

Adaptee para el archivo en formato Txt en donde se define exactamente cómo debe de acomodar la información y de donde toma la clase para abrir el formulario

![image](https://user-images.githubusercontent.com/72468795/169572975-ff247d8e-4896-42dc-8549-31e2d2cbe352.png)

__Iterator__

_Se usa cuando:_

- Se tiene una colección de elementos
- Necesitas un acceso secuencial para cada elemento del inicio al final de la lista
- Necesitas esconder la representación de la colección

_Diagrama UML_

![image](https://user-images.githubusercontent.com/72468795/169573169-5b57e2b9-5bb4-43c4-acbe-ddb07e7c4a1d.png)

_Dentro del proyecto se utiliza para:_

Poder ordenar, añadir e invertir elementos de la lista de ganancia de cada una de las tiendas dependiendo de los productos que pide, para que posteriormente se pueda mostrar el orden de la ruta.

![image](https://user-images.githubusercontent.com/72468795/169573252-b8f1b12d-9977-47c5-8282-88de028b7230.png)

![image](https://user-images.githubusercontent.com/72468795/169573273-26035760-3235-4982-a9eb-d959312576d9.png)

![image](https://user-images.githubusercontent.com/72468795/169573294-22bf2d5b-8809-409a-bbbf-77bb237baf4d.png)

![image](https://user-images.githubusercontent.com/72468795/169573325-b87e025e-8982-4b17-811a-4089474dca7c.png)

Implementado en la clase Simulation en donde se determina el orden de la simulación y posible ruta (si no se hiciera con el patrón iterator, tendríamos que aplicar las líneas que aparecen comentadas en color verde, con el iterador podríamos usarlo para cualquier lista, no solo “ganancia”:

![image](https://user-images.githubusercontent.com/72468795/169573368-89befd17-7d29-45ae-a6d1-f9f247a2aa3d.png)

## Aclaraciones generales
![image](https://user-images.githubusercontent.com/72468795/169573404-1a7e5c38-7ac4-4d73-81e4-e64416b19dc5.png)

El programa es capaz de abrir más de una bitácora del mismo tipo, siempre y cuando se seleccione los tipos de archivo que deseamos (en las checkbox) y demos clic en “Guardar”, cerramos la ventana y volvemos a realizar el proceso (solo en caso de que deseemos dos o más bitácoras DEL MISMO TIPO)
La generación del archivo de texto de la bitácora, en caso de ser elegido se guardará en la carpeta de descargas automáticamente con el nombre “debug”.

![image](https://user-images.githubusercontent.com/72468795/169573463-cc8c3630-c97d-4fe1-9b72-bb5d2b7bfab2.png)

Para dar de alta a la simulación y la ruta una tienda que ya se había atendido previamente, basta con presionar el botón “Agregar tienda con QR”, automáticamente abrirá el explorador de archivos para seleccionar un código QR que tenga las características almacenadas, dentro del proyecto se incluyen algunos para realizar pruebas, con los nombres: “test1” y “test2”
En caso de crear una tienda desde cero, debemos de presionar el botón “Suscribir una nueva tienda”, pedirá los datos obligatorios y generará el código QR, el cual se almacenará en la carpeta de descargas.

_Nota: las rutas de acceso se encuentran en el archivo “RegisterStore” y “GenerateTxtReport”_



