Smells:

Long Method: el m�todo update es muy largo, deber�a dividirse
Feature envy: Al validar c�mo deber�an funcionar los �tems seg�n su nombre, est� pasando esto. Cada �tem deber�a
tener en s� mismo un m�todo que baje su calidad.
Lazy Class: �tem es una clase Lazy. Pero no se puede modificar, as� que no se puede corregir esto
Data Class: �tem tambi�n es solamente una �tem class


Refactoring:
En mi dise�o de soluci�n, la soluci�n principal fue evitar el Feature Envy. Para lograrlo, lo ideal ser�a que
la clase �tem tuviera un m�todo UpdateQuality y otro llamado UpdateSellIn. Como no puedo agregarlos por la
restricci�n a tocar la clase 'Item', agregu� unas clases intermedias: IInventoryItem, todas las clases que
implementan esta interfaz e ItemManager, que vendr�a a ser quien maneja los diferentes IInventoryItem. Cada clase
que implemente la interfaz mencionada se encargar� de actualizarse a s� misma.
La otra idea con esto era lograr invertir la cadena de dependencia. Al hacer �sto, la clase "Inventory" qued�
totalmente independiente. Cualquier arreglo, habr�a que modificar las clases ItemManager y todas aquellas que
implementan IInventoryItem.
Sospecho probablemente que �sta no era la soluci�n esperada, porque al aplicar �ste refactoring, se solucionaron
todos los problemas sin necesidad de aplicar otros refactors.