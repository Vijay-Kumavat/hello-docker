# 🚀 Hello Docker for .NET Developers

A hands-on learning repository for understanding Docker from a .NET Developer's perspective.

This repository is inspired by the YouTube course **Docker Full Course For .NET Developers [Youtube_Video](https://www.youtube.com/watch?v=cWMztQwIQNs)** by Julio Casal and serves as a personal learning notebook and quick revision guide.

Free lab: [Docker - Kodeklound](https://kodekloud.com/studio/labs)

Hello Docker image: [Image](https://hub.docker.com/r/kumavatvijaykumar71195/hello-docker)


<img width="1300" height="514" alt="Screenshot 2026-08-27 113708" src="https://github.com/user-attachments/assets/683faf13-4a33-446c-b94d-18a4328e8c20" />
<img width="357" height="101" alt="image" src="https://github.com/user-attachments/assets/8f5b9056-9428-4a22-8419-23315c9c09df" />


---

# Table of Contents

1. What is Docker?
2. Why Docker?
3. Docker Architecture
4. Images vs Containers
5. Installing Docker
6. Docker Commands Explained
7. Dockerfile Explained
8. Port Mapping
9. Environment Variables
10. Docker Volumes
11. Docker Networking
12. Docker Compose
13. Running ASP.NET Applications in Docker
14. Useful Commands Cheat Sheet
15. Interview Questions
16. Learning Summary

---

# What is Docker?

Docker is a platform that allows developers to package applications along with all dependencies into lightweight units called **containers**.

The same container can run consistently on:

- Developer Machine
- Test Environment
- Production Server
- Cloud

Without Docker:

```text
Works on my machine ❌
Fails on server ❌
```

With Docker:

```text
Works on my machine ✅
Works on server ✅
Works everywhere ✅
```

---

# Why Docker?

Docker solves common development problems.

## Benefits

### Consistent Environment

Everyone runs exactly the same application configuration.

### Easy Deployment

Move containers between environments easily.

### Faster Setup

Instead of installing many tools manually, use a ready-made image.

### Lightweight

Containers share the host OS kernel and use fewer resources than VMs.

### Scalability

Applications can be scaled using multiple containers.

---

# Docker Architecture

Docker consists of three main components:

```text
+---------------------+
| Docker Client       |
| docker commands     |
+----------+----------+
           |
           v
+---------------------+
| Docker Daemon       |
| Builds & Runs       |
| Containers          |
+----------+----------+
           |
           v
+---------------------+
| Docker Images       |
| Docker Containers   |
+---------------------+
```

---

# Images vs Containers

## Docker Image

An image is a blueprint or template.

Example:

```bash
nginx
redis
mysql
```

### Easy Example

Think of an image like:

```text
Cake Recipe
```

The recipe itself is not the cake.

---

## Docker Container

A container is a running instance of an image.

### Easy Example

Think of a container like:

```text
Cake prepared using recipe
```

You can create multiple cakes from one recipe.

```text
Image = Recipe
Container = Actual Cake
```

---

# Installing Docker

Verify Docker Installation:

```bash
docker --version
```

Example Output:

```text
Docker version 28.x.x
```

---

# Docker Commands Explained

---

# 1. docker --version

## Definition

Displays the installed Docker version.

## Command

```bash
docker --version
```

## Example

```bash
docker --version
```

Output:

```text
Docker version 28.x.x
```

## Why Use It?

To verify Docker is installed successfully.

---

# 2. docker info

## Definition

Displays detailed information about Docker Engine.

## Command

```bash
docker info
```

## Information Shown

- Images Count
- Containers Count
- Storage Driver
- CPU Information
- Memory Information

## Example

```bash
docker info
```

Useful when troubleshooting Docker.

---

# 3. docker images

## Definition

Lists all images downloaded on your machine.

## Command

```bash
docker images
```

## Example Output

```text
REPOSITORY     TAG
nginx          latest
redis          latest
```

## Easy Example

Think of images as software installation packages.

```text
setup.exe
ubuntu.iso
```

They exist but are not running yet.

---

# 4. docker pull

## Definition

Downloads an image from Docker Hub.

## Command

```bash
docker pull nginx
```

## What Happens?

Docker downloads:

```text
nginx image
```

to your local machine.

## Verify

```bash
docker images
```

---

# 5. docker run

## Definition

Creates and starts a container from an image.

## Command

```bash
docker run nginx
```

## What Happens?

```text
1. Find image
2. Create container
3. Start container
```

## Easy Example

Recipe → Cake

```text
Image -> Container
```

---

# 6. docker run hello-world

## Definition

Runs Docker's test container.

## Command

```bash
docker run hello-world
```

## Purpose

Verify:

- Docker Engine
- Docker Hub Connection
- Container Execution

all work correctly.

---

# 7. docker ps

## Definition

Shows running containers.

## Command

```bash
docker ps
```

## Example Output

```text
CONTAINER ID   IMAGE
abcd1234       nginx
```

## Use Case

See what is currently running.

---

# 8. docker ps -a

## Definition

Shows all containers.

## Command

```bash
docker ps -a
```

## Includes

- Running Containers
- Stopped Containers

---

# 9. docker stop

## Definition

Stops a running container.

## Command

```bash
docker stop container-id
```

## Example

```bash
docker stop abcd1234
```

### Before

```text
Container Running
```

### After

```text
Container Stopped
```

---

# 10. docker start

## Definition

Restarts a stopped container.

## Command

```bash
docker start container-id
```

## Example

```bash
docker start abcd1234
```

---

# 11. docker rm

## Definition

Removes a container.

## Command

```bash
docker rm container-id
```

## Example

```bash
docker rm abcd1234
```

## Important

Container must be stopped first.

---

# 12. docker rmi

## Definition

Removes an image from local machine.

## Command

```bash
docker rmi nginx
```

## Example

```bash
docker rmi nginx
```

### Before

```text
nginx image exists
```

### After

```text
nginx image deleted
```

---

# 13. docker logs

## Definition

Displays container logs.

## Command

```bash
docker logs container-id
```

## Example

```bash
docker logs abcd1234
```

## Useful For

- Debugging
- Errors
- Application startup verification

---

# 14. docker logs -f

## Definition

Streams logs continuously.

## Command

```bash
docker logs -f container-id
```

## Example

```bash
docker logs -f webapp
```

### Similar To

```bash
tail -f logfile.log
```

---

# 15. docker exec

## Definition

Runs commands inside an existing container.

## Command

```bash
docker exec -it container-id bash
```

## Example

```bash
docker exec -it webapp bash
```

## What Happens?

You enter the container terminal.

```text
Host Machine
    ↓
Container Terminal
```

---

# Port Mapping

Containers are isolated.

To access an application:

```bash
docker run -p 8080:80 nginx
```

## Meaning

```text
Host Port      : 8080
Container Port : 80
```

### Access

```text
http://localhost:8080
```

### Easy Example

Apartment Building Example

```text
Building Gate = 8080
Flat Number   = 80
```

Gate forwards traffic to the correct flat.

---

# Dockerfile Explained

Dockerfile is a script used to build Docker images.

Example:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY . .

ENTRYPOINT ["dotnet","HelloDocker.dll"]
```

---

# Dockerfile Instructions

## FROM

Defines base image.

```dockerfile
FROM ubuntu
```

Example:

```text
Starting from Ubuntu Image
```

---

## WORKDIR

Sets working directory.

```dockerfile
WORKDIR /app
```

Like:

```bash
cd /app
```

---

## COPY

Copies files.

```dockerfile
COPY . .
```

Meaning:

```text
Current Folder
      ↓
Container Folder
```

---

## RUN

Executes commands during build.

```dockerfile
RUN dotnet restore
```

Example:

```dockerfile
RUN apt update
```

---

## EXPOSE

Documents port usage.

```dockerfile
EXPOSE 8080
```

---

## ENTRYPOINT

Defines startup command.

```dockerfile
ENTRYPOINT ["dotnet","HelloDocker.dll"]
```

Equivalent:

```bash
dotnet HelloDocker.dll
```

---

# Building Images

Build image:

```bash
docker build -t hello-docker .
```

## Meaning

```text
docker build
       ↓
Create image

-t
       ↓
Tag name

hello-docker
       ↓
Image Name

.
       ↓
Current Directory
```

### Verify

```bash
docker images
```

---

# Running Built Image

```bash
docker run -p 8080:8080 hello-docker
```

Browse:

```text
http://localhost:8080
```

---

# Environment Variables

## Definition

Pass configuration values without changing code.

### Example

```bash
docker run -e ASPNETCORE_ENVIRONMENT=Development hello-docker
```

### Common Values

```text
Development
Testing
Production
```

---

# Docker Volumes

## Problem

Container deleted →

Data deleted.

## Solution

Use Volumes.

### Create Volume

```bash
docker volume create myvolume
```

### Use Volume

```bash
docker run -v myvolume:/data nginx
```

### Easy Example

Think of volume as:

```text
External Hard Drive
```

Data remains even if container is removed.

---

# Docker Networking

Allows containers to communicate.

## Create Network

```bash
docker network create backend-network
```

## List Networks

```bash
docker network ls
```

## Run Container in Network

```bash
docker run --network backend-network nginx
```

### Example

```text
Web API
Database
Redis
```

All can communicate using the same network.

---

# Docker Compose

Used for managing multiple containers.

Instead of running many commands:

```bash
docker run ...
docker run ...
docker run ...
```

Use a single file.

---

## docker-compose.yml

```yaml
version: '3.9'

services:

  web:
    image: nginx

    ports:
      - "8080:80"

  redis:
    image: redis
```

---

## Start Services

```bash
docker compose up
```

### What Happens?

Starts:

- Nginx
- Redis

together.

---

## Stop Services

```bash
docker compose down
```

Stops and removes:

- Containers
- Network

created by Compose.

---

# ASP.NET Core Docker Workflow

## Step 1

Create ASP.NET Application

```bash
dotnet new webapi
```

## Step 2

Publish Application

```bash
dotnet publish -c Release
```

## Step 3

Build Docker Image

```bash
docker build -t hello-docker .
```

## Step 4

Run Container

```bash
docker run -p 8080:8080 hello-docker
```

## Step 5

Test Application

```text
http://localhost:8080
```

---

# Docker Cheat Sheet

```bash
docker --version
docker info

docker images
docker pull nginx

docker run nginx
docker run -d nginx

docker ps
docker ps -a

docker stop <id>
docker start <id>

docker rm <id>
docker rmi <image>

docker logs <id>
docker logs -f <id>

docker exec -it <id> bash

docker build -t hello-docker .

docker volume create myvolume

docker network create backend-network

docker compose up
docker compose down
```

---

# Docker Interview Questions

### What is Docker?

A platform for building, shipping, and running applications using containers.

### Difference Between Image and Container?

```text
Image     = Blueprint
Container = Running Instance
```

### Why Use Volumes?

To persist data beyond container lifecycle.

### Why Use Docker Compose?

To manage multiple containers easily.

### Difference Between VM and Container?

VM:

```text
Includes Full OS
Heavy
Slow Startup
```

Container:

```text
Shares Host OS
Lightweight
Fast Startup
```

---

# Learning Summary

✅ Docker packages applications in containers

✅ Images are blueprints

✅ Containers are running instances

✅ Dockerfile builds images

✅ Volumes persist data

✅ Networks connect containers

✅ Compose manages multiple containers

✅ Port mapping exposes applications

✅ Docker simplifies deployment

---

## Course Reference

Docker Full Course For .NET Developers  
Author: Julio Casal

Happy Learning and Happy Containerizing! 🚀
