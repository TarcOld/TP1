Smells:

Long Method: el método update es muy largo, debería dividirse
Feature envy: Al validar cómo deberían funcionar los ítems según su nombre, está pasando esto. Cada ítem debería
tener en sí mismo un método que baje su calidad.
Lazy Class: ítem es una clase Lazy. Pero no se puede modificar, así que no se puede corregir esto
Data Class: ítem también es solamente una ítem class


Refactoring:
En mi diseño de solución, la solución principal fue evitar el Feature Envy. Para lograrlo, lo ideal sería que
la clase ítem tuviera un método UpdateQuality y otro llamado UpdateSellIn. Como no puedo agregarlos por la
restricción a tocar la clase 'Item', agregué unas clases intermedias: IInventoryItem, todas las clases que
implementan esta interfaz e ItemManager, que vendría a ser quien maneja los diferentes IInventoryItem. Cada clase
que implemente la interfaz mencionada se encargará de actualizarse a sí misma.
La otra idea con esto era lograr invertir la cadena de dependencia. Al hacer ésto, la clase "Inventory" quedó
totalmente independiente. Cualquier arreglo, habría que modificar las clases ItemManager y todas aquellas que
implementan IInventoryItem.
Sospecho probablemente que ésta no era la solución esperada, porque al aplicar éste refactoring, se solucionaron
todos los problemas sin necesidad de aplicar otros refactors.