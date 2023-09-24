# Система мониторинга на тракторном заводе

## Идея проекта

Создание системы мониторинга на тракторном заводе, содержащей информацию об инцидентах на станках и визуальное интерпретирование работы завода на табло. Главное табло содержит информацию о статусе каждого поста (идет работа, работа выполнена, работа остановлена в результате инцидента). Статус поста определяется нажатием кнопки, которая установлена на каждом рабочем посту, что переключает статус поста на табло. Разрабатываемое ПО должно предоставлять интерфейс для взаимодействия с базой данных с возможностью создания новых инцидентов и редактирования их описания. Требуется реализовать функциональность для разных категорий пользователей

## Предметная область

Предметной областью является тракторный завод.
Мастер может классифицировать инциденты, добавлять инциденты, администратор может настраивать систему и управлять доступом, гость может только просматривать табло.

## Аналогичные решения

На данный момент существует только одна подобная система у Петербурского тракторного завода, но она, к сожалению, является закрытой для внешнего пользования.

## Целесообразность и актуальность

В современном мире, где население растет, а площадь земельных угодий ограничена, тракторы играют важную роль в обеспечении продовольственной безопасности и экономического развития. С их помощью можно обрабатывать большие участки земли за короткий период времени, повышая при этом произво- дительность труда и сокращая затраты на рабочую силу. Кроме того, тракторы помогают в сохранении природных ресурсов, уменьшают вредные выбросы в окружающую среду и способствуют росту экологической ответственности в сельском хозяйстве и промышленности.

Учитывая все вышесказанное, можно сделать вывод, что тракторы играют важную роль в нашей жизни, а чтобы обеспечивать производство новых машин, нужна правильная система мониторинга, которая позволит автоматизировать процесс контроля за производственными процессами и обеспечить своевременное реагирование на возникающие проблемы.

## Use-Case - диаграмма

![Use-Case - диаграмма guest](docs/img/guest.png "use-case")

![Use-Case - диаграмма foreman](docs/img/foreman.png "use-case")

![Use-Case - диаграмма shop manager](docs/img/shop_manager.png "use-case")

![Use-Case - диаграмма admin](docs/img/admin.png "use-case")

## ER - диаграмма сущностей
![ER - диаграмма сущностей](docs/img/er.png "ER")

## Пользовательские сценарии
#### Гость:
1) Просмотр табло;
2) Выход из аккаунта.

#### Мастер:
1) Классификация происшествий;

    а) Выбор типа происшествия из предложенных.
2) Редактирование описаний происшествий;
3) Просмотр табло и истории происшествий;
4) Выход из аккаунта.

#### Начальник цеха:
1) Классификация происшествий;

    а) Добавление нового типа происшествий;

    б) Выбор типа происшествия из предложенных.

2) Редактирование описаний происшествий;
3) Просмотр табло и истории происшествий;
4) Выход из аккаунта.

#### Администратор:
1) Классификация происшествий;

    а) Добавление нового типа происшествий;

    б) Выбор типа происшествия из предложенных.

2) Редактирование описаний происшествий;
3) Просмотр табло и истории происшествий;
4) Управление доступом, создание удаление пользователей;
5) Выход из аккаунта.


## Формализация бизнес-правил
![Формализация бизнес-правил](docs/img/buisness_process.png "buisness_process")

## Тип приложения и выбранный технологический стек
 
**Тип приложения:** Web SPA.
 
**Технологический стек:**
 
* Backend: 
    * C#
    * ASP.NET Core
* Frontend: 
    * HTML
    * CSS
    * C#
* База данных: 
    * PostgreSQL
 
## Верхнеуровневое разбиение на компоненты
 
В процессе проектирования выделяются 3 основных компонента:
 
* компонент доступа к данным;
* компонент бизнес-логики;
* компонент реализации UI.
 
## UML-диаграмма классов компонента бизнес-логики и компонента доступа к данным
 
![UML диаграмма классов бизнес логики и доступа к данным](./docs/img/uml.png)

## Триггеры базы данных

При создании базы данных были определены два триггеры. Оба срабатывают после добавления в таблицу ButtonsEvents новой записи (нажатие кнопки), но один заносит запись в список происшествий, а второй обновляет цвета на постах (сущность ButtonsPosts) для отображения на табло.

### Схема работы триггеров

![Схема работы триггеров](./docs/img/triggers_scheme.png)

### Схема функции вставки нового происшествия в список

![Схема функции вставки нового происшествия в список](./docs/img/insert_in_events.png)

### Схема функции обновления блоков на табло

![Схема функции обновления блоков на табло](./docs/img/update_button_color.png)
 
## Диаграмма классов сущностей базы данных
 
![Диаграмма классов сущностей БД](./docs/img/db_ent.png)

## Тесты (Lab 3-4)

Unit-тесты для компонента бизнес-логики находятся в папке UnitDBL.

Интеграционные тесты для компонента доступа данных находятся в папке UnitDAL.

#### Результат прохождения Unit-тестов:

![Unit-тесты](./docs/img/Utests.png)

## Логгер, демонстрация работы приложения и покрытия всех use-case'ов (Lab 5-7)

Внедрена система логирования методов контроллеров с записью в лог-файл папки /db_cp/logs.

### Авторизация (общая)

![auth](./docs/img/auth.png)

### Регистрация (общая)

![reg](./docs/img/reg.png)



### Мониторинг для гостя

![guest_monitoring](./docs/img/guest_monitoring.png)

### Добавление типа происшествия для гостя

![guest_addEventType](./docs/img/guest_addEventType.png)

### Удаление типа происшествия для гостя

![guest_delEventType](./docs/img/guest_delEventType.png)

### Панель админа (добавление нового пользователя) для гостя

![guest_addNewUser](./docs/img/guest_addNewUser.png)

### Панель админа (изменения прав доступа пользователя) для гостя

![guest_updatePermission](./docs/img/guest_updatePermission.png)

### Редактирование таблицы происшествий (выставление типа происшествия и добавление описания) для гостя

![guest_editing](./docs/img/guest_editing.png)

### Мониторинг для мастера

![foreman_monitoring](./docs/img/foreman_monitoring.png)

### Добавление типа происшествия для мастера

![foreman_addEventType](./docs/img/foreman_addEventType.png)

### Удаление типа происшествия для мастера

![foreman_delEventType](./docs/img/foreman_delEventType.png)

### Панель админа (добавление нового пользователя) для мастера

![foreman_addNewUser](./docs/img/foreman_addNewUser.png)

### Панель админа (изменения прав доступа пользователя) для мастера

![foreman_updatePermission](./docs/img/foreman_updatePermission.png)

### Редактирование таблицы происшествий (выставление типа происшествия и добавление описания) для мастера

![foreman_editing](./docs/img/foreman_editing.png)


### Мониторинг для начальника цеха

![manager_monitoring](./docs/img/manager_monitoring.png)

### Добавление типа происшествия для начальника цеха

![manager_addEventType](./docs/img/manager_addEventType.png)

### Удаление типа происшествия для начальника цеха

![manager_delEventType](./docs/img/manager_delEventType.png)

### Панель админа (добавление нового пользователя) для начальника цеха

![manager_addNewUser](./docs/img/manager_addNewUser.png)

### Панель админа (изменения прав доступа пользователя) для начальника цеха

![manager_updatePermission](./docs/img/manager_updatePermission.png)

### Редактирование таблицы происшествий (выставление типа происшествия и добавление описания) для начальника цеха

![manager_editing](./docs/img/manager_editing.png)


### Мониторинг для администратора

![admin_monitoring](./docs/img/admin_monitoring.png)

### Добавление типа происшествия для администратора

![admin_addEventType](./docs/img/admin_addEventType.png)

### Удаление типа происшествия для администратора

![admin_delEventType](./docs/img/admin_delEventType.png)

### Панель админа (добавление нового пользователя) для администратора

![admin_addNewUser](./docs/img/admin_addNewUser.png)

### Панель админа (изменения прав доступа пользователя) для администратора

![admin_updatePermission](./docs/img/admin_updatePermission.png)

### Редактирование таблицы происшествий (выставление типа происшествия и добавление описания) для администратора

![admin_editing](./docs/img/admin_editing.png)

## Обновленная диаграмма классов сущностей базы данных (Lab 8)
 
Была добавлена новая сущность News

![Обновленная диаграмма классов сущностей БД](./docs/img/db_ent_update.png)

### Демонстрация работы за гостя

![newsGuest](./docs/img/newsGuest.png)

### Демонстрация работы за мастера

![newsForeman](./docs/img/newsForeman.png)

### Демонстрация работы за начальника цеха

![newsManager](./docs/img/newsManager.png)

### Демонстрация работы за администратора

![newsAdmin](./docs/img/newsAdmin.png)

## Поддержка новой СУБД (Lab 9)

Добавлена поддержка новой СУБД (MongoDB)
