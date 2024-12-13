#!/bin/bash

# Переход в директорию проекта
cd "$(dirname "$0")"

# Цвета для вывода
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m' # No Color

# Очистка предыдущих сборок
echo "Очистка предыдущих сборок..."
dotnet clean UniversityStats.sln

# Восстановление зависимостей
echo "Восстановление зависимостей..."
dotnet restore UniversityStats.sln

# Сборка проекта
echo "Сборка проекта..."
dotnet build UniversityStats.sln -c Release

# Проверка успешности сборки
if [ $? -ne 0 ]; then
    echo "${RED}Ошибка сборки проекта!${NC}"
    exit 1
fi

# Запуск тестов
echo "Запуск тестов..."
dotnet test UniversityStats.sln --verbosity normal

# Проверка успешности тестов
if [ $? -ne 0 ]; then
    echo "${RED}Ошибка при выполнении тестов!${NC}"
    exit 1
fi

# Проверка стиля кода (если установлен StyleCop)
echo "Проверка стиля кода..."
dotnet format --verify-no-changes UniversityStats.sln

# Финальное сообщение
echo "${GREEN}Все проверки пройдены успешно!${NC}"
exit 0
