#!/bin/bash
docker rm -f webapp-dev
docker build -t webapp .
docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name webapp-dev webapp
echo "Container rebuilt and started."