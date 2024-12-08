# UniversityStats

UniversityStats - это веб-приложение для управления статистикой университетов, разработанное на платформе .NET 8.0.

## Описание

Приложение предоставляет API для управления данными о:
- Университетах
- Факультетах
- Кафедрах
- Специальностях
- Связях между кафедрами и специальностями

## Технологии

- .NET 8.0
- ASP.NET Core Web API
- AutoMapper для маппинга объектов
- xUnit для модульного тестирования
- Swagger для документации API

## Структура проекта

- `UniversityStats.Api` - Web API проект
- `UniversityStats.Domain` - Доменная модель и репозитории
- `UniversityStats.Test` - Модульные тесты

## Начало работы

1. Клонируйте репозиторий:
```bash
git clone https://github.com/yourusername/UniversityStats.git
```

2. Восстановите зависимости:
```bash
dotnet restore
```

3. Запустите приложение:
```bash
cd UniversityStats
dotnet run --project UniversityStats.Api
```

4. Откройте Swagger UI:
```
https://localhost:5001/swagger
```

## Тестирование

Для запуска тестов выполните:
```bash
dotnet test
```

## Лицензия

MIT

## Используемые классы:
University - класс, определяющий университет.
Основные поля:
1) RegistrationNumber - номер регистрирования;
2) Name - название университета;
3) Address - адрес университета;
4) PropertyType - собственность учреждения;
5) BuildingOwership - собственность зданий.
6) RectorFullName - ФИО директора.
7) Degree - степень.
8) Tittle - звание.

Faculty - класс, определяющий факультет.
Основные поля:
1) FacultyId - идентификатор факультета;
2) Name - название факультета;
3) RegistrationNumber - номер регистрирования.

Specialty - класс, определяющий специальностью.
Основные поля:
1) SpecialtyId - идентификатор специальности;
2) Name - название специальности;
3) NumberOfGroups - количество группы

DepartmentSpecialty - класс, определяющий связанностью между факультетами и специальностями.
Основные поля:
1) DepartmentId - идентификатор кафедры;
2) SpecialtyId - идентификатор специальности.


Department - класс, определяющий department of University.
Основные поля:
1) FacultyId - идентификатор факультета;
2) NameDep - название кафедры;
3) DepartmentId - идентификатор кафедры.

## Реализованные тесты
1) Вывести информацию о выбранном вузе.
2) Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
3) Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
4) Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
5) Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе. 
6) Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
