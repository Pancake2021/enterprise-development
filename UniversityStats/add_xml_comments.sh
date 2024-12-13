#!/bin/bash

# Function to add XML comments to a C# file
add_xml_comments() {
    local file="$1"
    
    # Backup the original file
    cp "$file" "$file.bak"
    
    # Use sed to add XML comments
    sed -i '' '
    # Add class-level XML comment if not exists
    /^(public|internal|abstract|sealed)?\s*(class|interface|record|struct)\s*[A-Za-z0-9_]+/,/^{/ {
        /\/\/\/\s*<summary>/,/^{/ !{
            /^(public|internal|abstract|sealed)?\s*(class|interface|record|struct)\s*[A-Za-z0-9_]+/ i\
/// <summary>\
/// Represents a core component of the UniversityStats system.\
/// </summary>
        }
    }
    
    # Add method-level XML comments if not exists
    /^(public|private|protected|internal)?\s*[A-Za-z0-9_<>]+\s+[A-Za-z0-9_<>]+\s*\(.*\)\s*{/,/^{/ {
        /\/\/\/\s*<summary>/,/^{/ !{
            /^(public|private|protected|internal)?\s*[A-Za-z0-9_<>]+\s+[A-Za-z0-9_<>]+\s*\(.*\)\s*{/ i\
/// <summary>\
/// Performs a specific operation in the UniversityStats system.\
/// </summary>
        }
    }
    
    # Add parameter XML comments if not exists
    /\(.*\)/ {
        /\/\/\/\s*<param/ !{
            s/\(.*\)\s*{/\1 {\
/// <param name="[PARAM]">A parameter for the operation.</param>/
        }
    }
    
    # Add returns XML comment if not exists for methods with return type
    /^(public|private|protected|internal)?\s*[A-Za-z0-9_<>]+\s+[A-Za-z0-9_<>]+\s*\(.*\)\s*{/ {
        /\/\/\/\s*<returns>/ !{
            /void/ !{
                s/^(public|private|protected|internal)?\s*\([A-Za-z0-9_<>]+\)\s*[A-Za-z0-9_<>]+\s*\(.*\)\s*{/\1 \2 \3 {\
/// <returns>The result of the operation.</returns>/
            }
        }
    }
    ' "$file"
}

# Find and process all .cs files in the project
find /Users/glebpankeev/enterprise-development/UniversityStats -name "*.cs" -not -path "*/obj/*" -not -path "*/bin/*" | while read -r file; do
    echo "Processing $file"
    add_xml_comments "$file"
done

echo "XML comment generation complete!"
