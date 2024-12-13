#!/bin/bash

CONTROLLERS_DIR="/Users/glebpankeev/enterprise-development/UniversityStats/UniversityStats.API/Controllers"

echo "Checking primary constructors in controllers:"

for controller in "$CONTROLLERS_DIR"/*.cs; do
    echo "Analyzing $controller:"
    
    # Проверяем наличие primary конструктора
    if grep -E "public\s+[A-Za-z]+Controller\s*\(" "$controller" | grep -q "(.*service)"; then
        echo "✅ Primary constructor found in $(basename "$controller")"
    else
        echo "❌ No primary constructor in $(basename "$controller")"
    fi
done
