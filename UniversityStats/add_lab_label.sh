#!/bin/bash

# Функция для определения номера лабораторной и группы
parse_lab_info() {
    local last_commit_message=$(git log -1 --pretty=%B)
    
    # Определение номера лабораторной
    LAB_NUMBER=""
    for VAR in 1 2 3 4; do
        if echo "$last_commit_message" | grep -qiE "Лаб\.*\s*$VAR|Лабораторная\s*$VAR"; then
            LAB_NUMBER="Lab $VAR"
            break
        fi
    done

    # Определение номера группы (здесь используется статический номер)
    GROUP="6412"

    # Вывод результатов
    if [ -n "$LAB_NUMBER" ]; then
        echo "Определен номер лабораторной: $LAB_NUMBER"
        echo "Группа: $GROUP"
        
        # Добавление тегов
        git tag "$LAB_NUMBER"
        git push origin "$LAB_NUMBER"
        
        # Создание релиза (альтернатива лейблу)
        gh release create "$LAB_NUMBER" \
            --title "$LAB_NUMBER" \
            --notes "Автоматически созданный релиз для лабораторной работы"
    else
        echo "Не удалось определить номер лабораторной работы"
        exit 1
    fi
}

# Переход в директорию репозитория
cd "$(dirname "$0")"

# Проверка наличия GitHub CLI
if ! command -v gh &> /dev/null; then
    echo "Установите GitHub CLI (gh)"
    exit 1
fi

# Выполнение парсинга
parse_lab_info
