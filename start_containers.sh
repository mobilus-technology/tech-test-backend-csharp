#!/bin/bash

# Inicia contêineres para cada serviço individual, construindo a imagem se necessário
services=("sqlserver" "mongo")

for service in "${services[@]}"; do
    echo "Starting container for $service..."
    docker-compose up -d "$service"
done