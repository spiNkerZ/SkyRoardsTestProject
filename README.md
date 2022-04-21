# S![Screen16](https://user-images.githubusercontent.com/59829650/164462429-f284a254-ea43-46ac-a0af-970696fde12d.png)

- Бесконечная генерация уровня
 Реализована возможность настройки спавнящихся объектов через ScriptableObjcets 
 ![Screen17](https://user-images.githubusercontent.com/59829650/164463032-e98d861e-9137-4426-bd24-dcc26eb5e61f.png)
 В проекте есть два вида Entity - SpaceAsteroid и SpaceCat, для каждого из них можно настраивать свои параметры спавна
- За весь игровой цикл используется только 1 Instantiate(), далее работа идет с уже имеющимся массивом объектов для лучшей оптимизации
 и никаких Destroy().
- Настройка скорости игры и других параметров через ScriptableObjects![Screen19](https://user-images.githubusercontent.com/59829650/164464256-499a7700-addd-4508-bdb3-64920ab31929.png)
- Сбор статистики и хранение её в базе данных в зашифрованом виде в byte[]
- Настройка количества получаемых баллов через ScriptableObjects ![Screen18](https://user-images.githubusercontent.com/59829650/164463997-ae96ce81-06a4-4d6f-be6a-62a30ef61d04.png)
- Вывод их на экран посредством модульной системы.
- Космический корабль SpaceShip реализован из абстрактного класса SpaceTransport с базовой реализацией и далее дополненный модульной системой необходимых возможностей.
- SpaceTransport и все наследуемые от него компоненты имеют возможности своей уникальной настройки для каждого корабля.
- Архитектура проекта представляет собой модульную систему с каждым компонентом независищем от другого, за исключением сбора статистики, которая по соображениям оптимизации внердряется в другие классы.
- Эффекты комической пыли и реактивных двигаталей корабля которые взаимодействуют с ускорением.
- Полностью отсутствуют любые переборы компонентов и игровых объектов по типу GetComponent, GameObject.Find, FindOfType, вместо этого для максимальной производительности используется кэширование.

