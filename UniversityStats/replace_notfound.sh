#!/bin/bash

# Функция для замены NotFound() на NoContent()
replace_notfound() {
    local file="$1"
    sed -i '' 's/return NotFound()/return NoContent()/g' "$file"
}

# Найти и обработать все .cs файлы
find /Users/glebpankeev/enterprise-development/UniversityStats -type f -name "*.cs" -not -path "*/obj/*" -not -path "*/bin/*" | while read -r file; do
    if grep -q "return NotFound()" "$file"; then
        echo "Replacing NotFound() in $file"
        replace_notfound "$file"
    fi
done

echo "Replacement complete!"
