# 📋 Task Management App (Gestor de Tareas)

Aplicación web Full Stack desarrollada como proyecto para gestionar tareas de manera eficiente, construida con tecnologías modernas de la industria.

## 🚀 Tecnologías Utilizadas

- **Frontend:** Angular, TypeScript, HTML5, CSS3 / Framework de estilos.
- **Backend:** ASP.NET Core Web API (.NET 8), C#.
- **Base de Datos:** SQLite con Entity Framework Core (ORM).

## ✨ Características

- Interfaz limpia y responsiva para el manejo diario de tareas.
- Operaciones completas (CRUD): Listado, creación, actualización y marcado de tareas pendientes/completadas.
- Comunicación HTTP segura entre el cliente Angular y la API de .NET.
- Arquitectura escalable separada en capas (Controllers, Services, Data).

---

## 🛠️ Cómo ejecutar el proyecto localmente

Asegurate de tener instalado [.NET 8 SDK](https://dotnet.microsoft.com/) y [Node.js](https://nodejs.org/) con Angular CLI.

### 1. Clonar el repositorio
\`\`\`bash
git clone <URL_DE_TU_REPOSITORIO>
cd task-management
\`\`\`

### 2. Configurar y ejecutar el Backend
\`\`\`bash
cd backend/TaskManagement.Api
dotnet restore
dotnet ef database update
dotnet run
\`\`\`
*(La API correrá por defecto en `http://localhost:5171`)*

### 3. Configurar y ejecutar el Frontend
En otra terminal, andá a la carpeta del cliente:
\`\`\`bash
cd frontend/task-management-ui
npm install
ng serve
\`\`\`
*(Abrí tu navegador en `http://localhost:4200`)*